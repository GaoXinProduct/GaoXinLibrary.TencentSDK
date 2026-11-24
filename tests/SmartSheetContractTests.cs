using System.Net;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class SmartSheetContractTests
{
    [Fact]
    public async Task AutomationGroupChat_UsesDocumentIdAndOfficialWireFields()
    {
        using var handler = new RecordingHandler(
            """{"errcode":0,"has_more":true,"next_cursor":"next","chat_id_list":["chat"]}""",
            """{"errcode":0,"name":"群聊","owner":"owner","user_list":["member"]}""",
            """{"errcode":0}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var list = await client.SmartSheet.GetSmartSheetChatListAsync(
            new GetSmartSheetChatListRequest { DocId = "doc", Cursor = "first", Limit = 10 });
        var chat = await client.SmartSheet.GetSmartSheetChatAsync(new GetSmartSheetChatRequest { DocId = "doc", ChatId = "chat" });
        await client.SmartSheet.UpdateSmartSheetChatAsync(new UpdateSmartSheetChatRequest
        {
            DocId = "doc",
            ChatId = "chat",
            Owner = "new-owner",
            AddUserList = ["new-member"]
        });

        Assert.Equal("next", list.NextCursor);
        Assert.True(list.HasMore);
        Assert.Equal("chat", Assert.Single(list.ChatIdList!));
        Assert.Equal("群聊", chat.Name);
        Assert.Equal("chat", chat.ChatInfo!.ChatId);
        Assert.Equal("member", Assert.Single(chat.ChatInfo.UserList!));
        Assert.Collection(handler.Requests,
            request =>
            {
                CheckPost(request, "/cgi-bin/wedoc/smartsheet/groupchat/list");
                Assert.Equal("doc", request.Body.GetProperty("docid").GetString());
                Assert.Equal("first", request.Body.GetProperty("cursor").GetString());
                Assert.Equal(10, request.Body.GetProperty("limit").GetInt32());
                Assert.False(request.Body.TryGetProperty("offset", out _));
                Assert.False(request.Body.TryGetProperty("sheet_id", out _));
            },
            request =>
            {
                CheckPost(request, "/cgi-bin/wedoc/smartsheet/groupchat/get");
                Assert.Equal("doc", request.Body.GetProperty("docid").GetString());
                Assert.Equal("chat", request.Body.GetProperty("chat_id").GetString());
            },
            request =>
            {
                CheckPost(request, "/cgi-bin/wedoc/smartsheet/groupchat/update");
                Assert.Equal("doc", request.Body.GetProperty("docid").GetString());
                Assert.Equal("chat", request.Body.GetProperty("chat_id").GetString());
                Assert.Equal("new-owner", request.Body.GetProperty("owner").GetString());
                Assert.Equal("new-member", request.Body.GetProperty("add_user_list")[0].GetString());
                Assert.False(request.Body.TryGetProperty("chatid", out _));
            });
    }

    [Fact]
    public async Task ViewsPage_PreservesPaginationAndExistingArrayApi()
    {
        const string response = """
            {"errcode":0,"total":10,"has_more":true,"next":3,
             "views":[{"view_id":"view","view_title":"视图","view_type":"VIEW_TYPE_GRID","property":{"auto_sort":false}}]}
            """;
        using var handler = new RecordingHandler(response, response);
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);
        var request = new GetViewsRequest { DocId = "doc", SheetId = "sheet", Offset = 2, Limit = 1, ViewIds = ["view"] };

        var page = await client.SmartSheet.GetViewsPageAsync(request);
        var view = Assert.Single(await client.SmartSheet.GetViewsAsync(request));

        Assert.Equal(10u, page.Total);
        Assert.True(page.HasMore);
        Assert.Equal(3u, page.NextOffset);
        Assert.Equal("视图", view.Title);
        Assert.Equal("VIEW_TYPE_GRID", view.Type);
        Assert.False(view.Property!.Value.GetProperty("auto_sort").GetBoolean());
        Assert.All(handler.Requests, sent =>
        {
            CheckPost(sent, "/cgi-bin/wedoc/smartsheet/get_views");
            Assert.Equal(2, sent.Body.GetProperty("offset").GetInt32());
            Assert.Equal(1, sent.Body.GetProperty("limit").GetInt32());
            Assert.Equal("view", sent.Body.GetProperty("view_ids")[0].GetString());
        });
    }

    [Fact]
    public async Task AccountIdConversion_UsesSelfBuiltApplicationTokenAndBotOpenUserIdList()
    {
        using var handler = new RecordingHandler("""
            {"errcode":0,"userid_list":[{"open_userid":"openid","userid":"member"}],"invalid_open_userid_list":["invalid"]}
            """);
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var response = await client.AccountId.ConvertRobotOpenUserIdsAsync(
            new ConvertRobotOpenUserIdsRequest { OpenUserIds = ["openid", "invalid"] });

        Assert.Equal("member", Assert.Single(response.UserIds!).UserId);
        Assert.Equal("invalid", Assert.Single(response.InvalidOpenUserIds!));
        var request = Assert.Single(handler.Requests);
        CheckPost(request, "/cgi-bin/batch/openuserid_to_userid");
        Assert.Equal("openid", request.Body.GetProperty("open_userid_list")[0].GetString());
        Assert.False(request.Body.TryGetProperty("source_agentid", out _));
    }

    [Fact]
    public async Task ContentPermissions_UseOfficialRoutesAndPreserveRuleFields()
    {
        using var handler = new RecordingHandler(
            """{"errcode":0,"rule_list":[{"rule_id":7,"type":2,"priv_list":[{"sheet_id":"sheet","priv":"3"}]}]}""",
            """{"errcode":0}""",
            """{"errcode":0,"rule_id":8}""",
            """{"errcode":0}""",
            """{"errcode":0}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);
        var sheet = client.SmartSheet;

        var rules = await sheet.GetContentPermissionsAsync(new GetContentPermissionsRequest { DocId = "doc", Type = 2, RuleIds = [7] });
        await sheet.UpdateContentPermissionsAsync(new UpdateContentPermissionsRequest
        {
            DocId = "doc",
            Type = 2,
            RuleId = 7,
            Permissions = [new SheetContentPermission { SheetId = "sheet", Permission = 3, CanInsertRecord = false }]
        });
        var created = await sheet.CreateContentPermissionRuleAsync(new CreateContentPermissionRuleRequest { DocId = "doc", Name = "rule" });
        await sheet.UpdateContentPermissionMembersAsync(new UpdateContentPermissionMembersRequest
        {
            DocId = "doc",
            RuleId = created.RuleId,
            AddMembers = new ContentPermissionMemberRange { UserIds = ["member"] }
        });
        await sheet.DeleteContentPermissionRulesAsync(new DeleteContentPermissionRulesRequest { DocId = "doc", RuleIds = [created.RuleId] });

        Assert.Equal(3u, Assert.Single(Assert.Single(rules.Rules!).Permissions!).Permission);
        Assert.Equal(8u, created.RuleId);
        const string prefix = "/cgi-bin/wedoc/smartsheet/content_priv/";
        Assert.Collection(handler.Requests,
            request => CheckPost(request, prefix + "get_sheet_priv"),
            request =>
            {
                CheckPost(request, prefix + "update_sheet_priv");
                Assert.False(request.Body.GetProperty("priv_list")[0].GetProperty("can_insert_record").GetBoolean());
            },
            request => CheckPost(request, prefix + "create_rule"),
            request =>
            {
                CheckPost(request, prefix + "mod_rule_member");
                Assert.Equal("member", request.Body.GetProperty("add_member_range").GetProperty("userid_list")[0].GetString());
            },
            request =>
            {
                CheckPost(request, prefix + "delete_rule");
                Assert.Equal(8, request.Body.GetProperty("rule_id_list")[0].GetInt32());
            });
    }

    private static WecomClient CreateClient(HttpClient http)
    {
        var client = WecomClient.Create(new WecomOptions { CorpId = "corp", CorpSecret = "secret" }, http);
        client.SetAccessToken("token");
        return client;
    }

    private static void CheckPost(SentRequest request, string path)
    {
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal(path, request.Uri.AbsolutePath);
        Assert.Equal("?access_token=token", request.Uri.Query);
    }

    private sealed record SentRequest(HttpMethod Method, Uri Uri, JsonElement Body);

    private sealed class RecordingHandler(params string[] responses) : HttpMessageHandler
    {
        public List<SentRequest> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(cancellationToken));
            var response = responses[Requests.Count];
            Requests.Add(new SentRequest(request.Method, request.RequestUri!, body.RootElement.Clone()));
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(response) };
        }
    }
}
