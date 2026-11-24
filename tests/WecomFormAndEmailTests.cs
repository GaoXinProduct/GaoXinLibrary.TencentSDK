using System.Net;
using System.Text;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;
using GaoXinLibrary.TencentSDK.Wecom.Models.Email;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomFormAndEmailTests
{
    [Fact]
    public async Task CreateForm_UsesOfficialQuestionSchemaAndKeepsLegacyInputs()
    {
        using var handler = new WecomHandler("""{"errcode":0,"formid":"form-1"}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);
        var question = new CollectQuestion
        {
            QuestionId = 1,
            Title = "Location",
            QuestionType = 1,
            IsRequired = true,
            OptionList = [new CollectOption { OptionId = 1, Text = "Taipei" }]
        };

        var result = await client.CollectForm.CreateCollectFormAsync(new CollectFormOperationRequest
        {
            SpaceId = "space",
            ParentFolderId = "folder",
            FormInfo = new CollectFormInfo
            {
                Title = "Attendance",
                FormId = "ignored-response-field",
                QuestionList = [question]
            }
        });

        Assert.Equal("form-1", result.FormId);
        var body = AssertPost(Assert.Single(handler.Requests), "/cgi-bin/wedoc/create_form").ReadBody();
        Assert.Equal("space", body.GetProperty("spaceid").GetString());
        Assert.Equal("folder", body.GetProperty("fatherid").GetString());
        var info = body.GetProperty("form_info");
        Assert.Equal("Attendance", info.GetProperty("form_title").GetString());
        Assert.False(info.TryGetProperty("formid", out _));
        var item = info.GetProperty("form_question").GetProperty("items")[0];
        Assert.Equal(1, item.GetProperty("pos").GetInt32());
        Assert.Equal(1, item.GetProperty("status").GetInt32());
        Assert.Equal(2, item.GetProperty("reply_type").GetInt32());
        Assert.True(item.GetProperty("must_reply").GetBoolean());
        var option = item.GetProperty("option_item")[0];
        Assert.Equal(1, option.GetProperty("key").GetInt32());
        Assert.Equal("Taipei", option.GetProperty("value").GetString());
        Assert.Equal(0, question.Position);
    }

    [Fact]
    public async Task EditForm_SeparatesQuestionAndSettingsOperations()
    {
        using var handler = new WecomHandler("""{"errcode":0}""", """{"errcode":0}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);
        var form = new CollectFormInfo
        {
            FormId = "form-1",
            Title = "Updated title",
            Settings = new CollectFormSettings { FillOutAuth = 1, TimedFinish = 1_700_000_000 }
        };

        await client.CollectForm.EditCollectFormAsync(new EditCollectFormRequest
        {
            FormId = "form-1",
            Operation = CollectFormEditOperation.Questions,
            FormInfo = form
        });
        await client.CollectForm.ModifyCollectFormAsync(new CollectFormOperationRequest
        {
            FormInfo = new CollectFormInfo { FormId = "form-1", Settings = form.Settings }
        });

        Assert.Collection(handler.Requests,
            request =>
            {
                var body = AssertPost(request, "/cgi-bin/wedoc/modify_form").ReadBody();
                Assert.Equal("form-1", body.GetProperty("formid").GetString());
                Assert.Equal(1, body.GetProperty("oper").GetInt32());
                var info = body.GetProperty("form_info");
                Assert.Equal("Updated title", info.GetProperty("form_title").GetString());
                Assert.False(info.TryGetProperty("form_setting", out _));
            },
            request =>
            {
                var body = AssertPost(request, "/cgi-bin/wedoc/modify_form").ReadBody();
                Assert.Equal("form-1", body.GetProperty("formid").GetString());
                Assert.Equal(2, body.GetProperty("oper").GetInt32());
                var info = body.GetProperty("form_info");
                Assert.False(info.TryGetProperty("form_title", out _));
                Assert.Equal(1, info.GetProperty("form_setting").GetProperty("fill_out_auth").GetInt32());
                Assert.Equal(1_700_000_000, info.GetProperty("form_setting").GetProperty("timed_finish").GetInt32());
            });
    }

    [Fact]
    public async Task ReadForm_ExposesCycleIdsAndQuestionDetails()
    {
        using var handler = new WecomHandler("""
            {"errcode":0,"form_info":{"formid":"form-1","form_title":"Attendance","form_desc":"One entry",
                "repeated_id":["cycle-1","cycle-2"],"form_question":{"items":[
                  {"question_id":1,"title":"Comments","pos":1,"status":1,"reply_type":1,"must_reply":true}
                ]},"form_setting":{"timed_finish":1700000000}}}
            """);
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var result = await client.CollectForm.GetCollectFormAsync(new GetCollectFormRequest { FormId = "form-1" });

        Assert.NotNull(result);
        Assert.Equal("Attendance", result.Title);
        Assert.NotNull(result.RepeatedIds);
        Assert.Equal(["cycle-1", "cycle-2"], result.RepeatedIds);
        Assert.True(Assert.Single(result.QuestionList!).IsRequired);
        Assert.Equal(1_700_000_000L, result.EndTime);
        var body = AssertPost(Assert.Single(handler.Requests), "/cgi-bin/wedoc/get_form_info").ReadBody();
        Assert.Equal("form-1", body.GetProperty("formid").GetString());
    }

    [Fact]
    public async Task QueryFormStatisticsAndAnswers_UseCycleIdsAndNumericAnswerIds()
    {
        using var handler = new WecomHandler(
            """
            {"errcode":0,"fill_cnt":3,"fill_user_cnt":2,"unfill_user_cnt":5,
                "submit_users":[{"userid":"employee","submit_time":1700000000,"answer_id":18446744073709551615}],
                "has_more":true,"cursor":22}
            """,
            """
            {"errcode":0,"answer":{"answer_list":[{"answer_id":18446744073709551615,"userid":"employee",
                "ctime":1700000000,"mtime":1700001000,"reply":{"items":[
                    {"question_id":1,"text_reply":"Remote"},
                    {"question_id":2,"option_reply":[3],"file_extend_reply":[{"name":"report.pdf","fileid":"document"}]}
                ]}}]}}
            """);
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var stats = await client.CollectForm.GetCollectFormStatAsync(new GetCollectFormStatRequest
        {
            RepeatedId = "cycle",
            RequestType = CollectFormStatisticType.Submitted,
            StartTime = 1_700_000_000,
            EndTime = 1_700_086_399,
            Limit = 10,
            Cursor = 11
        });
        var answerId = Assert.Single(stats.SubmittedUsers!).AnswerId;
        var response = await client.CollectForm.GetCollectAnswerAsync(new GetCollectAnswerRequest
        {
            RepeatedId = "cycle",
            AnswerIds = [answerId]
        });

        Assert.Equal(3UL, stats.FillCount);
        Assert.Equal(2UL, stats.FilledUserCount);
        Assert.Equal(5UL, stats.UnfilledUserCount);
        Assert.True(stats.HasMore);
        Assert.Equal(22UL, stats.Cursor);
        var answer = Assert.Single(response.AnswerList!);
        Assert.Equal(ulong.MaxValue, answer.AnswerId);
        Assert.Equal("Remote", answer.AnswerList![0].TextAnswer);
        var optionIds = answer.AnswerList[1].OptionIds;
        Assert.NotNull(optionIds);
        Assert.Equal([3U], optionIds);
        Assert.Equal("document", Assert.Single(answer.AnswerList[1].FileReplies!).FileId);
        Assert.Collection(handler.Requests,
            request =>
            {
                var body = AssertPost(request, "/cgi-bin/wedoc/get_form_statistic").ReadBody();
                Assert.Equal("cycle", body.GetProperty("repeated_id").GetString());
                Assert.Equal(2, body.GetProperty("req_type").GetInt32());
                Assert.Equal(1_700_000_000UL, body.GetProperty("start_time").GetUInt64());
                Assert.Equal(11UL, body.GetProperty("cursor").GetUInt64());
            },
            request =>
            {
                var body = AssertPost(request, "/cgi-bin/wedoc/get_form_answer").ReadBody();
                Assert.Equal("cycle", body.GetProperty("repeated_id").GetString());
                Assert.Equal(ulong.MaxValue, body.GetProperty("answer_ids")[0].GetUInt64());
                Assert.False(body.TryGetProperty("formid", out _));
                Assert.False(body.TryGetProperty("cursor", out _));
            });
    }

    [Fact]
    public async Task MailAliases_UpdateSendsNewEmailAndQueryHasNoBody()
    {
        using var handler = new WecomHandler(
            """{"errcode":0}""",
            """{"errcode":0,"email":"new@corp.test","alias_list":["old@corp.test"]}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        await client.Email.UpdateEmailAccountAsync(new UpdateEmailAccountRequest { Email = "new@corp.test" });
        var account = await client.Email.GetEmailAccountAsync(new GetEmailAccountRequest());

        Assert.Equal("new@corp.test", account.Email);
        Assert.NotNull(account.AliasList);
        Assert.Equal(["old@corp.test"], account.AliasList);
        Assert.Collection(handler.Requests,
            request =>
            {
                var body = AssertPost(request, "/cgi-bin/exmail/app/update_email_alias").ReadBody();
                Assert.Equal("new@corp.test", body.GetProperty("new_email").GetString());
                Assert.Single(body.EnumerateObject());
            },
            request => Assert.Null(AssertPost(request, "/cgi-bin/exmail/app/get_email_alias").Body));
    }

    [Fact]
    public async Task Inbox_UsesCursorAndPassesMailIdToRead()
    {
        using var handler = new WecomHandler(
            """{"errcode":0,"next_cursor":"next","has_more":1,"mail_list":[{"mail_id":"mail-1"}]}""",
            """{"errcode":0,"has_more":0,"mail_list":[{"mail_id":"mail-2"}]}""",
            """{"errcode":0,"mail_data":"Content-Type: text/plain\r\n\r\nBody"}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);
        var request = new GetMailListRequest { BeginTime = 1_700_000_000, EndTime = 1_700_086_399, Limit = 20 };

        var firstPage = await client.Email.GetMailListAsync(request);
        request.Cursor = firstPage.NextCursor;
        var secondPage = await client.Email.GetMailListAsync(request);
        var mail = await client.Email.ReadMailAsync(new ReadMailRequest { MailId = Assert.Single(secondPage.MailList!).MailId! });

        Assert.Equal(1U, firstPage.HasMore);
        Assert.Equal("mail-1", Assert.Single(firstPage.MailList!).MailId);
        Assert.Equal(0U, secondPage.HasMore);
        Assert.Equal("Content-Type: text/plain\r\n\r\nBody", mail.MailData);
        Assert.Collection(handler.Requests,
            sent =>
            {
                var body = AssertPost(sent, "/cgi-bin/exmail/app/get_mail_list").ReadBody();
                Assert.Equal(1_700_000_000U, body.GetProperty("begin_time").GetUInt32());
                Assert.Equal(1_700_086_399U, body.GetProperty("end_time").GetUInt32());
                Assert.Equal(20U, body.GetProperty("limit").GetUInt32());
                Assert.False(body.TryGetProperty("cursor", out _));
            },
            sent => Assert.Equal("next", AssertPost(sent, "/cgi-bin/exmail/app/get_mail_list").ReadBody().GetProperty("cursor").GetString()),
            sent => Assert.Equal("mail-2", AssertPost(sent, "/cgi-bin/exmail/app/read_mail").ReadBody().GetProperty("mail_id").GetString()));
    }

    [Fact]
    public async Task SendMail_UsesRecipientObjectsAndBase64Attachments()
    {
        using var handler = new WecomHandler("""{"errcode":0}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);
        var request = new SendMailRequest
        {
            To = [new EmailAddress { Addr = "legacy@corp.test" }],
            Recipients = new MailRecipients { Emails = ["new@corp.test"], UserIds = ["employee"] },
            CopyRecipients = new MailRecipients { UserIds = ["copy"] },
            Subject = "Report",
            Content = "Attached",
            ContentType = "text",
            Attachments = [new MailAttachment { FileName = "report.txt", Content = [1, 2, 3] }]
        };

        var mailId = await client.Email.SendMailAsync(request);

        Assert.Null(mailId);
        var body = AssertPost(Assert.Single(handler.Requests), "/cgi-bin/exmail/app/compose_send").ReadBody();
        var to = body.GetProperty("to");
        Assert.Equal("new@corp.test", to.GetProperty("emails")[0].GetString());
        Assert.Equal("legacy@corp.test", to.GetProperty("emails")[1].GetString());
        Assert.Equal("employee", to.GetProperty("userids")[0].GetString());
        Assert.Equal("copy", body.GetProperty("cc").GetProperty("userids")[0].GetString());
        Assert.Equal("AQID", body.GetProperty("attachment_list")[0].GetProperty("content").GetString());
        Assert.Equal(["new@corp.test"], request.Recipients.Emails);
    }

    [Fact]
    public async Task UnreadCount_UsesMemberInboxEndpointInBothEntryPoints()
    {
        using var handler = new WecomHandler("""{"errcode":0,"count":5}""", """{"errcode":0,"count":7}""");
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var count = await client.Email.GetUnreadCountAsync(new GetMailUnreadCountRequest { UserId = "employee" });
        var response = await client.Email.GetEmailUnreadCountAsync(new GetEmailUnreadCountRequest { UserId = "employee" });

        Assert.Equal(5, count);
        Assert.Equal(7, response.UnreadCount);
        Assert.Equal(2, handler.Requests.Count);
        Assert.All(handler.Requests, request => Assert.Equal(
            "employee", AssertPost(request, "/cgi-bin/exmail/mail/get_newcount").ReadBody().GetProperty("userid").GetString()));
    }

    private static WecomClient CreateClient(HttpClient http)
        => WecomClient.Create(new WecomOptions
        {
            CorpId = "test-corp",
            CorpSecret = "test-secret",
            AgentId = 1,
            BaseUrl = "https://wecom.test",
            RetryOptions = null
        }, http);

    private static CapturedRequest AssertPost(CapturedRequest request, string path)
    {
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal(path, request.Path);
        Assert.Equal("?access_token=test-token", request.Query);
        return request;
    }

    private sealed record CapturedRequest(HttpMethod Method, string Path, string Query, string? Body)
    {
        public JsonElement ReadBody()
        {
            using var json = JsonDocument.Parse(Assert.IsType<string>(Body));
            return json.RootElement.Clone();
        }
    }

    private sealed class WecomHandler(params string[] responses) : HttpMessageHandler
    {
        private readonly Queue<string> _responses = new(responses);
        public List<CapturedRequest> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uri = request.RequestUri!;
            if (uri.AbsolutePath == "/cgi-bin/gettoken")
                return JsonResponse("""{"errcode":0,"access_token":"test-token","expires_in":7200}""");

            var body = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
            Requests.Add(new CapturedRequest(request.Method, uri.AbsolutePath, uri.Query, body));
            return JsonResponse(_responses.Dequeue());
        }

        private static HttpResponseMessage JsonResponse(string body)
            => new(HttpStatusCode.OK) { Content = new StringContent(body, Encoding.UTF8, "application/json") };
    }
}
