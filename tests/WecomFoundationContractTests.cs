using System.Net;
using System.Text;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.ContactRule;
using GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;
using GaoXinLibrary.TencentSDK.Wecom.Models.Todo;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomFoundationContractTests
{
    [Fact]
    public async Task Todo_GetUsesPostAndDeserializesDetails()
    {
        using var handler = new ContractHandler(new ExpectedPost(
            "/cgi-bin/todo/get",
            """{"todo_id":"todo-123"}""",
            """
            {
                "errcode": 0,
                "content": "提交报表",
                "creator": "creator",
                "status": 1,
                "create_time": 177777777,
                "end_time": 177888888,
                "attendees": [{"userid": "member", "status": 0}],
                "reminders": [{"remind_time": 177800000}]
            }
            """));
        using var http = new HttpClient(handler);
        var service = new TodoService(CreateWecomHttpClient(http));

        var todo = await service.GetTodoAsync("todo-123");

        Assert.Equal("提交报表", todo.Content);
        Assert.Equal("creator", todo.CreatorUserId);
        Assert.Equal(TodoStatus.InProgress, todo.Status);
        Assert.Equal(177777777, todo.CreateTime);
        Assert.Equal(177888888, todo.EndTime);
        var attendee = Assert.Single(todo.Attendees!);
        Assert.Equal("member", attendee.UserId);
        Assert.Equal(TodoStatus.Completed, attendee.Status);
        Assert.Equal(177800000, Assert.Single(todo.Reminders!).RemindTime);
        handler.AssertCompleted();
    }

    [Fact]
    public async Task Todo_UpdateKeepsOverallStatusAndAttendeesIndependent()
    {
        using var handler = new ContractHandler(
            new ExpectedPost("/cgi-bin/todo/update", """{"todo_id":"todo-123","status":0}"""),
            new ExpectedPost("/cgi-bin/todo/update", """{"todo_id":"todo-123","attendees":[{"userid":"member","status":2}]}"""));
        using var http = new HttpClient(handler);
        var service = new TodoService(CreateWecomHttpClient(http));

        await service.UpdateTodoAsync(new UpdateTodoRequest { TodoId = "todo-123", Status = TodoStatus.Completed });
        await service.UpdateTodoAsync(new UpdateTodoRequest
        {
            TodoId = "todo-123",
            Attendees = [new TodoAttendee { UserId = "member", Status = (TodoStatus)2 }]
        });

        handler.AssertCompleted();
    }

    [Fact]
    public async Task ContactRules_UsesDocumentedBatchPayloadsAndReturnsUpdatedRules()
    {
        const string rulesResponse = """
            {
                "errcode": 0,
                "rules": [{
                    "rule_id": 10001,
                    "rule_type": 2,
                    "range": {"userid": ["member"], "partyid": [4], "tagid": [5]},
                    "whitelist": {"userid": ["manager"]},
                    "exclude": {"tagid": []},
                    "is_allowed_search": false,
                    "is_allowed_conversation": true
                }]
            }
            """;

        using var handler = new ContractHandler(
            new ExpectedPost("/cgi-bin/contactrule/create",
                """
                {"rules":[{"rule_type":2,"range":{"userid":["member"],"partyid":[4],"tagid":[5]},
                    "whitelist":{"userid":["manager"]},"exclude":{"tagid":[]},
                    "is_allowed_search":false,"is_allowed_conversation":true}]}
                """,
                """{"errcode":0,"rule_ids":[10001]}"""),
            new ExpectedPost("/cgi-bin/contactrule/list", null, rulesResponse),
            new ExpectedPost("/cgi-bin/contactrule/update",
                """
                {"rules":[{"rule_id":10001,"rule_type":2,"range":{"userid":["member"],"partyid":[4],"tagid":[5]},
                    "whitelist":{"userid":["manager"]},"exclude":{"tagid":[]},
                    "is_allowed_search":false,"is_allowed_conversation":true}]}
                """, rulesResponse),
            new ExpectedPost("/cgi-bin/contactrule/delete", """{"rule_ids":[10001]}"""));
        using var http = new HttpClient(handler);
        var service = new ContactRuleService(CreateWecomHttpClient(http));

        var rule = new ContactVisibilityRule
        {
            RuleType = ContactRuleType.RestrictOtherDepartments,
            Range = new ContactRuleRange { UserIds = ["member"], DepartmentIds = [4], TagIds = [5] },
            Whitelist = new ContactRuleRange { UserIds = ["manager"] },
            Exclude = new ContactRuleRange { TagIds = [] },
            IsAllowedSearch = false,
            IsAllowedConversation = true
        };

        var created = await service.CreateRulesAsync([rule]);
        Assert.Equal(10001, Assert.Single(created.RuleIds!));

        var listed = Assert.Single((await service.GetRuleListAsync()).Rules!);
        Assert.Equal(10001, listed.RuleId);
        Assert.Equal(ContactRuleType.RestrictOtherDepartments, listed.RuleType);
        Assert.Equal("member", Assert.Single(listed.Range.UserIds!));
        Assert.False(listed.IsAllowedSearch);

        var updated = Assert.Single((await service.UpdateRulesAsync([listed])).Rules!);
        Assert.Equal("manager", Assert.Single(updated.Whitelist!.UserIds!));
        Assert.Empty(updated.Exclude!.TagIds!);
        Assert.True(updated.IsAllowedConversation);

        await service.DeleteRulesAsync([10001]);
        handler.AssertCompleted();
    }

    [Fact]
    public async Task StrategyTags_UsesDedicatedRoutesAndPreservesUnsignedOrder()
    {
        using var handler = new ContractHandler(
            new ExpectedPost("/cgi-bin/externalcontact/get_strategy_tag_list",
                """{"strategy_id":2,"tag_id":["tag"],"group_id":["group"]}""",
                """
                {"errcode":0,"tag_group":[{"strategy_id":2,"group_id":"group","order":4294967295,
                    "tag":[{"id":"tag","name":"目标客户","order":4294967295}]}]}
                """),
            new ExpectedPost("/cgi-bin/externalcontact/add_strategy_tag",
                """{"strategy_id":2,"group_id":"group","tag":[{"name":"潜在客户","order":4294967295}]}""",
                """{"errcode":0,"tag_group":{"group_id":"group","tag":[{"id":"new-tag","name":"潜在客户"}]}}"""),
            new ExpectedPost("/cgi-bin/externalcontact/edit_strategy_tag",
                """{"id":"new-tag","order":4294967295}"""),
            new ExpectedPost("/cgi-bin/externalcontact/del_strategy_tag",
                """{"tag_id":["new-tag"]}"""));
        using var http = new HttpClient(handler);
        var service = new ExternalContactService(CreateWecomHttpClient(http));

        var tags = await service.GetStrategyTagListAsync(new GetStrategyTagListRequest
        {
            StrategyId = 2,
            TagIds = ["tag"],
            GroupIds = ["group"]
        });

        var group = Assert.Single(tags.TagGroup!);
        Assert.Equal(2, group.StrategyId);
        Assert.Equal(uint.MaxValue, group.Order);
        Assert.Equal(uint.MaxValue, Assert.Single(group.Tag!).Order);

        var created = await service.AddStrategyTagAsync(new AddStrategyTagRequest
        {
            StrategyId = 2,
            GroupId = "group",
            Tags = [new CorpTagAddItem { Name = "潜在客户", Order = uint.MaxValue }]
        });
        Assert.Equal("new-tag", Assert.Single(created.TagGroup!.Tag!).Id);

        await service.UpdateStrategyTagAsync(new UpdateStrategyTagRequest { Id = "new-tag", Order = uint.MaxValue });
        await service.DeleteStrategyTagAsync(new DeleteStrategyTagRequest { TagIds = ["new-tag"] });
        handler.AssertCompleted();
    }

    private static WecomHttpClient CreateWecomHttpClient(HttpClient http)
    {
        var options = new WecomOptions { BaseUrl = "https://wecom.example.test" };
        var token = new AccessTokenProvider(options, http);
        token.SetToken("access-token");
        return new WecomHttpClient(http, token, options);
    }

    private sealed record ExpectedPost(string Path, string? Body, string Response = """{"errcode":0}""");

    private sealed class ContractHandler(params ExpectedPost[] expectedPosts) : HttpMessageHandler
    {
        private int _calls;

        public void AssertCompleted() => Assert.Equal(expectedPosts.Length, _calls);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.InRange(_calls, 0, expectedPosts.Length - 1);
            var call = expectedPosts[_calls++];
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal(call.Path, request.RequestUri!.AbsolutePath);
            Assert.Equal("?access_token=access-token", request.RequestUri.Query);
            if (call.Body is null)
            {
                Assert.Null(request.Content);
            }
            else
            {
                using var expected = JsonDocument.Parse(call.Body);
                using var actual = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(cancellationToken));
                Assert.True(JsonElement.DeepEquals(expected.RootElement, actual.RootElement),
                    $"Expected JSON {expected.RootElement}, got {actual.RootElement}.");
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(call.Response, Encoding.UTF8, "application/json")
            };
        }
    }
}
