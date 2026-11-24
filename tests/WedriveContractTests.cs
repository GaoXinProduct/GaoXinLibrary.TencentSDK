using System.Net;
using System.Text;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WedriveContractTests
{
    [Fact]
    public async Task SpaceMemberEndpointsSendTypedAuthInfo()
    {
        using var handler = new WedriveHandler(
            new("space_acl_add", """{"errcode":0}""", body =>
            {
                Assert.Equal("space", body.GetProperty("spaceid").GetString());
                Assert.False(body.TryGetProperty("auth_list", out _));
                var members = body.GetProperty("auth_info");
                Assert.Equal("alice", members[0].GetProperty("userid").GetString());
                Assert.Equal(7, members[0].GetProperty("auth").GetInt32());
                Assert.Equal("4294967295", members[1].GetProperty("departmentid").GetString());
                Assert.False(members[1].TryGetProperty("id", out _));
            }),
            new("space_acl_del", """{"errcode":0}""", body =>
            {
                var members = body.GetProperty("auth_info");
                Assert.Equal("alice", members[0].GetProperty("userid").GetString());
                Assert.Equal("8", members[1].GetProperty("departmentid").GetString());
                Assert.False(members[0].TryGetProperty("auth", out _));
            }),
            new("space_acl_del", """{"errcode":0}""", body =>
            {
                Assert.False(body.TryGetProperty("auth_id_list", out _));
                var member = body.GetProperty("auth_info")[0];
                Assert.Equal(2, member.GetProperty("type").GetInt32());
                Assert.Equal("9", member.GetProperty("departmentid").GetString());
            }));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        await client.Wedrive.AddSpaceMembersAsync(new AddSpaceMemberRequest
        {
            SpaceId = "space",
            AuthList =
            [
                new SpaceMemberAuth { Type = 1, UserId = "alice", Auth = 7 },
                new SpaceMemberAuth { Type = 2, Id = "4294967295", Auth = 1 }
            ]
        });
        await client.Wedrive.RemoveSpaceMembersAsync(new RemoveSpaceMemberRequest
        {
            SpaceId = "space",
            AuthInfo =
            [
                new SpaceMemberIdentity { Type = 1, UserId = "alice" },
                new SpaceMemberIdentity { Type = 2, DepartmentId = 8 }
            ]
        });
        var legacy = new RemoveSpaceMemberRequest { SpaceId = "space", Type = 2, AuthIdList = ["9"] };
        await client.Wedrive.RemoveSpaceMembersAsync(legacy);

        Assert.Null(legacy.AuthInfo);
        Assert.Equal(3, handler.CallCount);
    }

    [Fact]
    public async Task SpacePermissionsPreserveFalseValuesAndReadInvitesAndDepartmentIds()
    {
        using var handler = new WedriveHandler(
            new("space_setting", """{"errcode":0}""", body =>
            {
                Assert.Equal("space", body.GetProperty("spaceid").GetString());
                Assert.False(body.GetProperty("enable_share_url").GetBoolean());
                Assert.True(body.GetProperty("enable_watermark").GetBoolean());
                Assert.False(body.TryGetProperty("share_url_no_approve", out _));
                Assert.False(body.TryGetProperty("security_mode", out _));
            }),
            new("space_share", """{"errcode":0,"space_share_url":"https://example.test/invite"}""",
                body => Assert.Equal("space", body.GetProperty("spaceid").GetString())),
            new("space_info",
                """
                {"errcode":0,"space_info":{"spaceid":"space","auth_list":{
                  "auth_info":[
                    {"type":2,"departmentid":"4294967295","auth":1},
                    {"type":2,"departmentid":42,"auth":1}],
                  "quit_userid":["bob"]
                }}}
                """,
                body => Assert.Equal("space", body.GetProperty("spaceid").GetString())));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        await client.Wedrive.UpdateSpaceSecurityAsync(new UpdateSpaceSecurityRequest
        {
            SpaceId = "space",
            EnableShareUrl = false,
            EnableWatermark = true
        });
        var invitation = await client.Wedrive.GetSpaceInviteLinkAsync(new GetSpaceInviteLinkRequest { SpaceId = "space" });
        var space = await client.Wedrive.GetSpaceInfoAsync(new SpaceIdRequest { SpaceId = "space" });

        Assert.Equal("https://example.test/invite", invitation.ShareUrl);
        var permissions = Assert.IsType<SpaceAuthList>(space?.AuthList);
        Assert.Collection(permissions.AuthInfo!,
            item => Assert.Equal(uint.MaxValue, item.DepartmentIdValue),
            item => Assert.Equal(42, item.DepartmentId));
        Assert.Equal("bob", Assert.Single(permissions.QuitUserIds!));
        Assert.Equal(3, handler.CallCount);
    }

    [Fact]
    public async Task FileTransfersSendBase64AndReturnDownloadCredentials()
    {
        using var handler = new WedriveHandler(
            new("file_upload", """{"errcode":0,"fileid":"file"}""", body =>
            {
                Assert.Equal("space", body.GetProperty("spaceid").GetString());
                Assert.Equal("folder", body.GetProperty("fatherid").GetString());
                Assert.Equal("sample.bin", body.GetProperty("file_name").GetString());
                Assert.Equal("AH//", body.GetProperty("file_base64_content").GetString());
                Assert.False(body.TryGetProperty("selected_ticket", out _));
            }),
            new("file_download",
                """
                {"errcode":0,"download_url":"https://example.test/download","cookie_name":"key","cookie_value":"value"}
                """, body =>
                {
                    Assert.Equal("file-selection", body.GetProperty("selected_ticket").GetString());
                    Assert.False(body.TryGetProperty("fileid", out _));
                    Assert.False(body.TryGetProperty("download_type", out _));
                }));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var uploaded = await client.Wedrive.UploadFileAsync(new UploadFileRequest
        {
            SpaceId = "space",
            FatherId = "folder",
            FileName = "sample.bin",
            FileContent = [0x00, 0x7f, 0xff]
        });
        var download = await client.Wedrive.DownloadFileAsync(new DownloadFileRequest { SelectedTicket = "file-selection" });

        Assert.Equal("file", uploaded.FileId);
        Assert.Equal("https://example.test/download", download.Url);
        Assert.Equal("key", download.CookieName);
        Assert.Equal("value", download.CookieValue);
        Assert.Equal(2, handler.CallCount);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ChunkedUploadUsesServerKeyOrPreexistingFileId(bool alreadyExists)
    {
        const string blockSha = "a9993e364706816aba3e25717850c26c9cd0d89d";
        var initialize = new ExpectedRequest(
            "file_upload_init",
            alreadyExists
                ? """{"errcode":0,"hit_exist":true,"fileid":"existing"}"""
                : """{"errcode":0,"hit_exist":false,"upload_key":"key"}""",
            body =>
            {
                Assert.Equal("folder-selection", body.GetProperty("selected_ticket").GetString());
                Assert.Equal(3, body.GetProperty("size").GetInt64());
                Assert.Equal(blockSha, body.GetProperty("block_sha")[0].GetString());
                Assert.False(body.GetProperty("skip_push_card").GetBoolean());
                Assert.False(body.TryGetProperty("file_size", out _));
                Assert.False(body.TryGetProperty("file_hash", out _));
            });
        using var handler = alreadyExists
            ? new WedriveHandler(initialize)
            : new WedriveHandler(
                initialize,
                new("file_upload_part", """{"errcode":0}""", body =>
                {
                    Assert.Equal("key", body.GetProperty("upload_key").GetString());
                    Assert.Equal(1, body.GetProperty("index").GetInt32());
                    Assert.Equal("YWJj", body.GetProperty("file_base64_content").GetString());
                    Assert.False(body.TryGetProperty("jobid", out _));
                }),
                new("file_upload_finish", """{"errcode":0,"fileid":"new-file"}""",
                    body => Assert.Equal("key", body.GetProperty("upload_key").GetString())));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var initialized = await client.Wedrive.InitializeChunkedUploadAsync(new ChunkedUploadInitRequest
        {
            SelectedTicket = "folder-selection",
            FileName = "data.txt",
            FileSize = 3,
            BlockSha = [blockSha],
            SkipPushCard = false
        });

        Assert.Equal(alreadyExists, initialized.AlreadyExists);
        if (alreadyExists)
        {
            Assert.Equal("existing", initialized.FileId);
            Assert.Null(initialized.UploadKey);
            Assert.Equal(1, handler.CallCount);
            return;
        }

        Assert.Equal("key", initialized.UploadKey);
        await client.Wedrive.UploadChunkAsync(new ChunkedUploadChunkRequest
        {
            JobId = initialized.JobId,
            ChunkSeq = 0,
            FileContent = Encoding.UTF8.GetBytes("abc")
        });
        var finished = await client.Wedrive.FinishChunkedUploadAsync(new ChunkedUploadFinishRequest
        {
            UploadKey = initialized.UploadKey
        });
        Assert.Equal("new-file", finished.FileId);
        Assert.Equal(3, handler.CallCount);
    }

    [Fact]
    public void InvalidSelectionAndDigestCountFailBeforeSending()
    {
        using var handler = new WedriveHandler();
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        Assert.Throws<ArgumentException>(() =>
        {
            _ = client.Wedrive.DownloadFileAsync(new DownloadFileRequest
            {
                FileId = "file",
                SelectedTicket = "file-selection"
            });
        });
        Assert.Throws<ArgumentException>(() =>
        {
            _ = client.Wedrive.InitializeChunkedUploadAsync(new ChunkedUploadInitRequest
            {
                SelectedTicket = "folder-selection",
                FileName = "data.txt",
                FileSize = ChunkedUploadChunkRequest.BlockSizeBytes + 1,
                BlockSha = ["a9993e364706816aba3e25717850c26c9cd0d89d"]
            });
        });
        Assert.Equal(0, handler.CallCount);
    }

    private static WecomClient CreateClient(HttpClient http)
    {
        var client = WecomClient.Create(new WecomOptions
        {
            CorpId = "corp",
            CorpSecret = "secret",
            BaseUrl = "https://example.test"
        }, http);
        client.SetAccessToken("token");
        return client;
    }

    private sealed record ExpectedRequest(string Endpoint, string Response, Action<JsonElement> VerifyBody);

    private sealed class WedriveHandler(params ExpectedRequest[] expected) : HttpMessageHandler
    {
        public int CallCount { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.True(CallCount < expected.Length, $"Unexpected request: {request.RequestUri}");
            var next = expected[CallCount++];
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal($"/cgi-bin/wedrive/{next.Endpoint}", request.RequestUri!.AbsolutePath);
            Assert.Equal("?access_token=token", request.RequestUri.Query);
            Assert.Equal("application/json", request.Content!.Headers.ContentType!.MediaType);
            using var document = JsonDocument.Parse(await request.Content.ReadAsStringAsync(cancellationToken));
            next.VerifyBody(document.RootElement);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(next.Response, Encoding.UTF8, "application/json")
            };
        }
    }
}
