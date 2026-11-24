using System.Net;
using System.Text.Json.Nodes;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.ClassPayment;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Department;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.HealthReport;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Living;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Parent;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Student;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class HomeSchoolContractTests
{
    [Fact]
    public async Task FamilyMemberReads_UseGetQueriesAndBindDocumentedFields()
    {
        var handler = new ContractHandler(
            Get("/cgi-bin/school/user/get", "userid=student%26a%2B",
                """{"errcode":0,"user_type":1,"student":{"student_userid":"student&a+","name":"示例学生","department":[5],"parents":[{"parent_userid":"P1","relation":"家长","is_subscribe":1,"external_userid":"E1"}]}}"""),
            Get("/cgi-bin/school/user/get", "userid=P1",
                """{"errcode":0,"user_type":2,"parent":{"parent_userid":"P1","children":[{"student_userid":"student&a+","relation":"家长"}]}}"""),
            Get("/cgi-bin/school/user/list", "department_id=5",
                """{"errcode":0,"students":[{"student_userid":"S1"}]}"""),
            Get("/cgi-bin/school/user/list_parent", "department_id=5",
                """{"errcode":0,"parents":[{"parent_userid":"P1","children":[{"student_userid":"S1","name":"示例学生"}]}]}"""),
            Get("/cgi-bin/school/department/list", "id=5",
                """{"errcode":0,"departments":[{"id":5,"open_group_chat":1,"group_chat_id":"G1"}]}"""));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var student = await client.HomeSchool.GetStudentAsync(new GetStudentRequest { StudentUserid = "student&a+" });
        var parent = await client.HomeSchool.GetParentAsync(new GetParentRequest { ParentUserid = "P1" });
        var students = await client.HomeSchool.GetDepartmentStudentsDetailAsync(new GetDepartmentStudentsDetailRequest { DepartmentId = 5 });
        var parents = await client.HomeSchool.GetDepartmentParentsDetailAsync(new GetDepartmentParentsDetailRequest { DepartmentId = 5 });
        var departments = await client.HomeSchool.GetDepartmentListAsync(new GetDepartmentListRequest { Id = 5 });

        Assert.Equal(1, student.UserType);
        Assert.Equal("E1", Assert.Single(student.StudentInfo!.Parents!).ExternalUserid);
        Assert.Equal(2, parent.UserType);
        Assert.Equal("student&a+", Assert.Single(parent.ParentInfo!.Children!).StudentUserid);
        Assert.Equal("S1", Assert.Single(students.Students!).StudentUserid);
        Assert.Equal("示例学生", Assert.Single(Assert.Single(parents.ParentList!).Children!).StudentName);
        Assert.Equal("G1", Assert.Single(departments.Department!).GroupChatId);
        handler.AssertCompleted();
    }

    [Theory]
    [InlineData("user/delete_student", "userid=S1")]
    [InlineData("user/delete_parent", "userid=P1")]
    [InlineData("department/delete", "id=5")]
    public async Task FamilyDeletion_UsesGetWithoutTransientReplay(string path, string query)
    {
        var handler = new ContractHandler(Get("/cgi-bin/school/" + path, query, "{}") with { Status = HttpStatusCode.BadGateway });
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var error = await Assert.ThrowsAsync<HttpRequestException>(() => path switch
        {
            "user/delete_student" => client.HomeSchool.DeleteStudentAsync(new DeleteStudentRequest { StudentUserid = "S1" }),
            "user/delete_parent" => client.HomeSchool.DeleteParentAsync(new DeleteParentRequest { ParentUserid = "P1" }),
            _ => client.HomeSchool.DeleteDepartmentAsync(new DeleteDepartmentRequest { Id = 5 })
        });

        Assert.Equal(HttpStatusCode.BadGateway, error.StatusCode);
        handler.AssertCompleted();
    }

    [Fact]
    public async Task FamilyWrites_UseDocumentedChildrenAndBatchUserIdFields()
    {
        var handler = new ContractHandler(
            Post("/cgi-bin/school/user/create_parent",
                """{"parent_userid":"P1","to_invite":false,"children":[{"student_userid":"S1","relation":"家长"}]}"""),
            Post("/cgi-bin/school/user/batch_update_student",
                """{"students":[{"student_userid":"S1","new_student_userid":"S2"}]}"""),
            Post("/cgi-bin/school/user/batch_delete_parent", """{"useridlist":["P1"]}"""),
            Post("/cgi-bin/school/user/batch_delete_student", """{"useridlist":["S2"]}"""));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        await client.HomeSchool.CreateParentAsync(new CreateParentRequest
        {
            ParentUserid = "P1",
            ToInvite = false,
            Children = new() { StudentUserid = "S1", Relation = "家长" }
        });
        await client.HomeSchool.BatchUpdateStudentAsync(new BatchUpdateStudentRequest
        {
            Students = [new() { StudentUserid = "S1", NewStudentUserid = "S2", StudentNumber = "学校内部编号" }]
        });
        await client.HomeSchool.BatchDeleteParentAsync(new BatchDeleteParentRequest { ParentUserids = ["P1"] });
        await client.HomeSchool.BatchDeleteStudentAsync(new BatchDeleteStudentRequest { StudentUserids = ["S2"] });

        handler.AssertCompleted();
    }

    [Fact]
    public async Task HealthReportQueries_UseDatesOffsetsAndTypedAnswers()
    {
        var handler = new ContractHandler(
            Post("/cgi-bin/health/get_health_report_stat", """{"date":"2026-11-20"}""",
                """{"errcode":0,"pv":18,"uv":10}"""),
            Post("/cgi-bin/health/get_report_jobids", """{"offset":2,"limit":5}""",
                """{"errcode":0,"ending":0,"jobids":["job3"]}"""),
            Post("/cgi-bin/health/get_report_job_info", """{"jobid":"job3","date":"2026-11-20"}""",
                """{"errcode":0,"job_info":{"title":"示例问卷","finish_cnt":7,"apply_range":{"partyids":[5]},"question_templates":[{"question_id":2,"option_list":[{"option_id":3,"option_text":"已完成"}]}]}}"""),
            Post("/cgi-bin/health/get_report_answer", """{"jobid":"job3","date":"2026-11-20","offset":2,"limit":5}""",
                """{"errcode":0,"answers":[{"id_type":2,"student_userid":"S1","parent_userid":"P1","report_time":1234,"report_values":[{"question_id":2,"single_choice":3}]}]}"""));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var stat = await client.HomeSchool.GetHealthReportStatAsync(new GetHealthReportStatRequest { Date = "2026-11-20" });
        var jobs = await client.HomeSchool.GetHealthReportTaskIdListAsync(new GetHealthReportTaskIdListRequest { Offset = 2, Limit = 5 });
        var job = await client.HomeSchool.GetHealthReportTaskDetailAsync(new GetHealthReportTaskDetailRequest { TaskId = "job3", Date = "2026-11-20" });
        var answers = await client.HomeSchool.GetHealthReportAnswersAsync(new GetHealthReportAnswersRequest
        {
            TaskId = "job3",
            Date = "2026-11-20",
            Offset = 2,
            Limit = 5
        });

        Assert.Equal(18, stat.PageViews);
        Assert.Equal(10, stat.UniqueUsers);
        Assert.Equal("job3", Assert.Single(jobs.JobIds!));
        Assert.Equal("job3", Assert.Single(jobs.TaskIdList!).TaskId);
        Assert.Equal(1, jobs.HasMore);
        Assert.Equal("job3", job.TaskInfo!.TaskId);
        Assert.Equal(7, job.TaskInfo.FinishedCount);
        Assert.Equal("已完成", Assert.Single(Assert.Single(job.TaskInfo.QuestionTemplates!).Options!).OptionText);
        var answer = Assert.Single(answers.AnswerList!);
        Assert.Equal("P1", answer.ParentUserid);
        Assert.Equal(3, Assert.Single(answer.ReportValues!).SingleChoice);
        handler.AssertCompleted();
    }

    [Fact]
    public async Task InvalidHealthDate_FailsBeforeSending()
    {
        var handler = new ContractHandler();
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        await Assert.ThrowsAsync<ArgumentException>(() => client.HomeSchool.GetHealthReportStatAsync(new GetHealthReportStatRequest { Date = "2026-02-30" }));

        handler.AssertCompleted();
    }

    [Fact]
    public async Task SchoolLivingListDetailAndReplay_UseTheirOwnRoutes()
    {
        var handler = new ContractHandler(
            Post("/cgi-bin/living/get_user_all_livingid", """{"userid":"teacher","cursor":"page1","limit":5}""",
                """{"errcode":0,"livingid_list":["L1"],"next_cursor":"page2"}"""),
            Get("/cgi-bin/school/living/get_living_info", "livingid=L1",
                """{"errcode":0,"living_info":{"theme":"公开课","living_start":15000,"living_duration":1800,"anchor_userid":"teacher","living_range":{"partyids":[5]},"viewer_num":20}}"""),
            Post("/cgi-bin/living/delete_replay_data", """{"livingid":"L1"}"""));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var list = await client.HomeSchool.GetLivingIdListAsync(new GetLivingIdListRequest { TeacherUserid = "teacher", Cursor = "page1", Limit = 5 });
        var detail = await client.HomeSchool.GetLivingDetailAsync(new GetLivingDetailRequest { Livingid = "L1" });
        await client.HomeSchool.DeleteReplayDataAsync(new DeleteReplayDataRequest { Livingid = "L1" });

        Assert.Equal("L1", Assert.Single(list.LivingidList!).Livingid);
        Assert.Equal("page2", list.NextCursor);
        Assert.Equal("L1", detail.LivingInfo!.Livingid);
        Assert.Equal("公开课", detail.LivingInfo.Title);
        Assert.Equal(1800L, detail.LivingInfo.Duration);
        Assert.Equal(5, Assert.Single(detail.LivingInfo.LivingRange!.PartyIds!));
        handler.AssertCompleted();
    }

    [Fact]
    public async Task SchoolLivingStats_UseVersionedPaginationAndParticipantGroups()
    {
        var handler = new ContractHandler(
            Post("/cgi-bin/school/living/get_watch_stat", """{"livingid":"L1","next_key":"one"}""",
                """{"errcode":0,"ending":0,"next_key":"two","stat_infoes":{"students":[{"student_userid":"S1","watch_time":30}]}}"""),
            Post("/cgi-bin/school/living/get_unwatch_stat", """{"livingid":"L1","next_key":"one"}""",
                """{"errcode":0,"ending":1,"stat_info":{"students":[{"student_userid":"S2","parent_userid":"P2"}]}}"""),
            Post("/cgi-bin/school/living/get_watch_stat_v2", """{"livingid":"L1","next_cursor":"one"}""",
                """{"errcode":0,"has_more":1,"next_cursor":"two","stat_info":{"parents":[{"student_userid":"S1","parent_userid":"P1","watch_time":30}]}}"""),
            Post("/cgi-bin/school/living/get_unwatch_stat_v2", """{"livingid":"L1","next_cursor":"one"}""",
                """{"errcode":0,"has_more":0,"stat_info":{"students":[{"student_userid":"S2"}],"parents":[{"student_userid":"S2","parent_userid":"P2"}]}}"""));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var watch = await client.HomeSchool.GetLivingWatchStatAsync(new GetLivingWatchStatRequest { Livingid = "L1", Cursor = "one" });
        var unwatch = await client.HomeSchool.GetLivingNotWatchStatAsync(new GetLivingNotWatchStatRequest { Livingid = "L1", NextKey = "one" });
        var watchV2 = await client.HomeSchool.GetLivingWatchStatV2Async(new GetLivingWatchStatV2Request { Livingid = "L1", NextCursor = "one" });
        var unwatchV2 = await client.HomeSchool.GetLivingNotWatchStatV2Async(new GetLivingNotWatchStatV2Request { Livingid = "L1", Cursor = "one" });

        Assert.Equal("two", watch.NextCursor);
        Assert.Equal(1, watch.HasMore);
        Assert.Equal(30L, Assert.Single(watch.StatInfo!.Students!).WatchTime);
        Assert.Equal(0, unwatch.HasMore);
        Assert.Equal("P2", Assert.Single(unwatch.StatInfo!.Students!).ParentUserid);
        Assert.Equal("two", watchV2.NextCursor);
        Assert.Equal("P1", Assert.Single(watchV2.StatInfo!.Parents!).ParentUserid);
        Assert.Equal(0, unwatchV2.HasMore);
        Assert.Equal("S2", Assert.Single(unwatchV2.StatInfo!.Parents!).StudentUserid);
        handler.AssertCompleted();
    }

    [Fact]
    public async Task ClassPayment_UsesProjectAndTradeIdsAndFiltersOnlyLocally()
    {
        var handler = new ContractHandler(
            Post("/cgi-bin/school/get_payment_result", """{"payment_id":"PAY"}""",
                """{"errcode":0,"project_name":"班费","amount":998,"payment_result":[{"student_userid":"S1","trade_state":1,"trade_no":"TRADE","payer_parent_userid":"P1"},{"student_userid":"S2","trade_state":0}]}"""),
            Post("/cgi-bin/school/get_trade", """{"payment_id":"PAY","trade_no":"TRADE"}""",
                """{"errcode":0,"transaction_id":"WECHAT-TXN","pay_time":12345}"""));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var result = await client.HomeSchool.GetStudentPaymentResultAsync(new GetStudentPaymentResultRequest { PaymentId = "PAY", StudentUserid = "s1" });
        var order = await client.HomeSchool.GetOrderDetailAsync(new GetOrderDetailRequest { PaymentId = "PAY", OrderId = "TRADE" });

        Assert.Equal(998, result.Amount);
        Assert.Equal(1, result.PayStatus);
        Assert.Equal("TRADE", Assert.Single(result.PaymentResult!).TradeNo);
        Assert.Equal("WECHAT-TXN", order.TransactionId);
        Assert.Equal(12345L, order.PayTime);
        handler.AssertCompleted();
    }

    private static WecomClient CreateClient(HttpClient http)
    {
        var client = WecomClient.Create(new WecomOptions
        {
            CorpId = "example",
            CorpSecret = "unused",
            BaseUrl = "https://example.test",
            RetryOptions = new TencentRetryOptions { MaxRetries = 2, InitialDelay = TimeSpan.Zero, MaxDelay = TimeSpan.Zero }
        }, http);
        client.SetAccessToken("test-token");
        return client;
    }

    private static ExpectedRequest Get(string path, string query, string response)
        => new(HttpMethod.Get, path, query, null, response);

    private static ExpectedRequest Post(string path, string json, string response = """{"errcode":0}""")
        => new(HttpMethod.Post, path, null, json, response);

    private sealed record ExpectedRequest(HttpMethod Method, string Path, string? Query, string? Json, string Response,
        HttpStatusCode Status = HttpStatusCode.OK);

    private sealed class ContractHandler(params ExpectedRequest[] expected) : HttpMessageHandler
    {
        private int _index;

        public void AssertCompleted() => Assert.Equal(expected.Length, _index);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.True(_index < expected.Length, $"Unexpected request: {request.Method} {request.RequestUri}");
            var entry = expected[_index++];
            Assert.Equal(entry.Method, request.Method);
            Assert.Equal(entry.Path, request.RequestUri!.AbsolutePath);
            var query = request.RequestUri.Query.TrimStart('?').Split('&');
            Assert.Contains("access_token=test-token", query);
            if (entry.Query is not null)
                Assert.Contains(entry.Query, query);
            Assert.Equal(entry.Query is null ? 1 : 2, query.Length);

            if (entry.Json is null)
            {
                Assert.Null(request.Content);
            }
            else
            {
                Assert.NotNull(request.Content);
                Assert.Equal("application/json", request.Content.Headers.ContentType?.MediaType);
                var json = await request.Content.ReadAsStringAsync(cancellationToken);
                Assert.True(JsonNode.DeepEquals(JsonNode.Parse(entry.Json), JsonNode.Parse(json)),
                    $"Expected {entry.Json}, got {json}");
            }
            return new HttpResponseMessage(entry.Status) { Content = new StringContent(entry.Response) };
        }
    }
}
