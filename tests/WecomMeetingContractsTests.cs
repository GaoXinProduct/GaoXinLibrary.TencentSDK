using System.Net;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomMeetingContractsTests
{
    [Fact]
    public async Task CreateMeeting_ConvertsLegacyEndTimeToDuration()
    {
        var (response, body) = await InvokeAsync("/cgi-bin/meeting/create",
            """{"errcode":0,"meetingid":"meeting-1","excess_users":["guest"]}""",
            service => service.CreateMeetingAsync(new()
            {
                AdminUserId = "host",
                Title = "Weekly meeting",
                MeetingStart = 1600000000,
                MeetingEnd = 1600003600
            }));

        Assert.Equal("meeting-1", response.MeetingId);
        Assert.Equal("guest", Assert.Single(response.ExcessUsers!));
        Assert.Equal(3600, body.GetProperty("meeting_duration").GetInt64());
        Assert.False(body.TryGetProperty("meeting_end", out _));
    }

    [Fact]
    public async Task UpdateMeeting_UsesExplicitDuration()
    {
        var (_, body) = await InvokeAsync("/cgi-bin/meeting/update", """{"errcode":0}""",
            async service =>
            {
                await service.UpdateMeetingAsync(new()
                {
                    MeetingId = "meeting-1",
                    MeetingStart = 1600000000,
                    MeetingDuration = 1800
                });
                return true;
            });

        Assert.Equal("meeting-1", body.GetProperty("meetingid").GetString());
        Assert.Equal(1600000000, body.GetProperty("meeting_start").GetInt64());
        Assert.Equal(1800, body.GetProperty("meeting_duration").GetInt64());
        Assert.False(body.TryGetProperty("meeting_end", out _));
    }

    [Theory]
    [InlineData("""{"errcode":0,"title":"Weekly meeting","meeting_start":1600000000,"meeting_duration":1800}""")]
    [InlineData("""{"errcode":0,"meeting_info":{"title":"Weekly meeting","meeting_start":1600000000,"meeting_end":1600001800}}""")]
    public async Task GetMeeting_ReturnsDetailsWithEndTime(string responseJson)
    {
        var (response, body) = await InvokeAsync("/cgi-bin/meeting/get_info", responseJson,
            service => service.GetMeetingAsync(new() { MeetingId = "meeting-1" }));

        Assert.NotNull(response);
        Assert.Equal("meeting-1", response.MeetingId);
        Assert.Equal("Weekly meeting", response.Title);
        Assert.Equal(1600001800, response.MeetingEnd);
        Assert.Equal("meeting-1", body.GetProperty("meetingid").GetString());
    }

    [Fact]
    public async Task GetUserMeetingId_UsesDocumentedFields()
    {
        var (response, body) = await InvokeAsync("/cgi-bin/meeting/get_user_meetingid",
            """{"errcode":0,"meetingid_list":["meeting-1","meeting-2"],"next_cursor":"next"}""",
            service => service.GetUserMeetingIdAsync(new()
            {
                UserId = "host",
                BeginTime = 1586136317,
                EndTime = 1586236317,
                Cursor = "previous",
                Limit = 100
            }));

        Assert.Equal(1586136317, body.GetProperty("begin_time").GetInt64());
        Assert.Equal(1586236317, body.GetProperty("end_time").GetInt64());
        Assert.Equal("previous", body.GetProperty("cursor").GetString());
        Assert.NotNull(response.MeetingIdList);
        Assert.Equal(["meeting-1", "meeting-2"], response.MeetingIdList);
        Assert.Equal("next", response.NextCursor);
    }

    [Fact]
    public async Task GetRealTimeParticipants_ReadsAttendeesAndPagination()
    {
        const string responseJson = """
            {
              "errcode":0, "status":"1", "has_more":true, "next_cursor":"next",
              "attendees":[{
                "userid":"host", "tmp_openid":"temporary", "join_time":"166666666",
                "instance_id":1, "role":2, "join_type":1, "audio_state":true,
                "video_state":false, "screen_shared_state":true
              }]
            }
            """;

        var (response, body) = await InvokeAsync("/cgi-bin/meeting/get_realtime_attendee_list", responseJson,
            service => service.GetRealTimeParticipantsAsync(new()
            {
                MeetingId = "meeting-1",
                SubMeetingId = "occurrence-1",
                Cursor = "previous",
                Limit = 50
            }));

        Assert.Equal("occurrence-1", body.GetProperty("sub_meetingid").GetString());
        Assert.Equal("previous", body.GetProperty("cursor").GetString());
        Assert.Equal(50, body.GetProperty("limit").GetInt32());
        Assert.False(body.TryGetProperty("need_room_info", out _));
        Assert.True(response.HasMore);
        Assert.Equal("next", response.NextCursor);
        Assert.Equal("1", response.Status);
        var attendee = Assert.Single(response.Participants!);
        Assert.Equal("host", attendee.UserId);
        Assert.Equal("temporary", attendee.TemporaryOpenId);
        Assert.Equal(166666666, attendee.JoinTime);
        Assert.Equal(1, attendee.InstanceId);
        Assert.Equal(2, attendee.Role);
        Assert.True(attendee.IsHost);
        Assert.False(attendee.IsCohost);
        Assert.False(attendee.IsMuted);
        Assert.True(attendee.AudioState);
        Assert.False(attendee.VideoState);
        Assert.True(attendee.ScreenSharedState);
    }

    [Theory]
    [InlineData("record_meetings", "record_files")]
    [InlineData("record_list", "record_file_list")]
    public async Task GetRecordingList_ReadsDocumentedListAndFileKeys(string recordListKey, string fileListKey)
    {
        var responseJson = $$"""
            {
              "errcode":0, "has_more":true, "next_cursor":"next",
              "{{recordListKey}}":[{
                "meeting_record_id":"record-1", "meetingid":"meeting-1", "title":"Weekly meeting",
                "meeting_start_time":1600000000000, "state":3,
                "{{fileListKey}}":[{"record_file_id":"file-1","record_size":1024,"allow_download":false}]
              }]
            }
            """;

        var (response, body) = await InvokeAsync("/cgi-bin/meeting/record/list", responseJson,
            service => service.GetRecordingListAsync(new()
            {
                UserId = "host",
                StartTime = 1600000000,
                EndTime = 1600001800,
                Cursor = "previous",
                PageSize = 15
            }));

        Assert.Equal(15, body.GetProperty("limit").GetInt32());
        Assert.Equal("host", body.GetProperty("userid").GetString());
        Assert.False(body.TryGetProperty("meetingid", out _));
        Assert.False(body.TryGetProperty("page_size", out _));
        Assert.True(response.HasMore);
        Assert.Equal("next", response.NextCursor);
        var recording = Assert.Single(response.RecordingList!);
        Assert.Equal("record-1", recording.MeetingRecordId);
        Assert.Equal(1600000000000, recording.StartTime);
        var file = Assert.Single(recording.RecordFiles!);
        Assert.Equal("file-1", file.RecordFileId);
        Assert.Equal(1024, file.Size);
        Assert.False(file.AllowDownload);
    }

    [Fact]
    public async Task GetRecordingDownloadUrl_ReturnsPerFileAddresses()
    {
        const string responseJson = """
            {
              "errcode":0, "meeting_record_id":"record-1", "meetingid":"meeting-1",
              "record_files":[{
                "record_file_id":"file-1", "download_address":"https://download.example/video",
                "download_address_file_type":"mp4",
                "meeting_summary":[{"download_address":"https://download.example/summary","file_type":"txt"}]
              }]
            }
            """;

        var (response, body) = await InvokeAsync("/cgi-bin/meeting/record/get_file_list", responseJson,
            service => service.GetRecordingDownloadUrlAsync(new() { MeetingId = "meeting-1", MeetingRecordId = "record-1" }));

        Assert.Equal("record-1", body.GetProperty("meeting_record_id").GetString());
        Assert.Equal("meeting-1", body.GetProperty("meetingid").GetString());
        Assert.False(body.TryGetProperty("download_type", out _));
        var file = Assert.Single(response.RecordFiles!);
        Assert.Equal("https://download.example/video", file.DownloadUrl);
        Assert.Equal("mp4", file.DownloadFileType);
        Assert.Equal("txt", Assert.Single(file.MeetingSummaries!).FileType);
    }

    [Fact]
    public async Task GetRecordingAccessStat_DecodesDailySummaries()
    {
        var (response, body) = await InvokeAsync("/cgi-bin/meeting/record/get_statistics",
            """{"errcode":0,"summaries":[{"date":"2033-01-01","view_count":12,"download_count":6}]}""",
            service => service.GetRecordingAccessStatAsync(new() { MeetingId = "meeting-1", MeetingRecordId = "record-1" }));

        Assert.Equal("record-1", body.GetProperty("meeting_record_id").GetString());
        Assert.False(body.TryGetProperty("start_time", out _));
        var day = Assert.Single(response.AccessStats!);
        Assert.Equal("2033-01-01", day.Date);
        Assert.Equal(12, day.ViewCount);
        Assert.Equal(6, day.DownloadCount);
    }

    [Fact]
    public async Task ModifyRecordingShare_NestsSharingConfiguration()
    {
        var (_, body) = await InvokeAsync("/cgi-bin/meeting/record/update_sharing_config", """{"errcode":0}""",
            service => service.ModifyRecordingShareAsync(new()
            {
                MeetingId = "meeting-1",
                MeetingRecordId = "record-1",
                SharingConfig = new() { EnableSharing = true, SharingAuthType = 2, AllowDownload = false }
            }));

        Assert.Equal("record-1", body.GetProperty("meeting_record_id").GetString());
        Assert.False(body.TryGetProperty("allow_download", out _));
        var sharing = body.GetProperty("sharing_config");
        Assert.True(sharing.GetProperty("enable_sharing").GetBoolean());
        Assert.Equal(2, sharing.GetProperty("sharing_auth_type").GetInt32());
        Assert.False(sharing.GetProperty("allow_download").GetBoolean());
    }

    [Fact]
    public async Task DeleteRecordingAndDeleteFile_UseDifferentIdentifiers()
    {
        var (_, recordBody) = await InvokeAsync("/cgi-bin/meeting/record/delete", """{"errcode":0}""",
            service => service.DeleteRecordingAsync(new() { MeetingId = "meeting-1", MeetingRecordId = "record-1" }));
        var (_, fileBody) = await InvokeAsync("/cgi-bin/meeting/record/delete_file", """{"errcode":0}""",
            service => service.DeleteRecordingFileAsync(new() { MeetingId = "meeting-1", RecordFileId = "file-1" }));

        Assert.Equal("record-1", recordBody.GetProperty("meeting_record_id").GetString());
        Assert.False(recordBody.TryGetProperty("record_file_id", out _));
        Assert.Equal("file-1", fileBody.GetProperty("record_file_id").GetString());
        Assert.False(fileBody.TryGetProperty("meeting_record_id", out _));
    }

    [Fact]
    public async Task CreateWebinar_UsesStringTimestampsAndAdmissionMode()
    {
        var (response, body) = await InvokeAsync("/cgi-bin/meeting/create_webinars",
            """{"errcode":0,"meetingid":"webinar-1","meeting_code":"123","start_time":"1700000000","audience_join_link":"https://join.example/"}""",
            service => service.CreateWebinarAsync(new()
            {
                UserId = "host",
                Subject = "Webinar",
                WebinarStart = 1700000000,
                WebinarEnd = 1700001800,
                EnableRegistration = true,
                OrgName = "Organizer",
                Hosts = [new() { UserId = "host" }]
            }));

        Assert.Equal("1700000000", body.GetProperty("start_time").GetString());
        Assert.Equal("1700001800", body.GetProperty("end_time").GetString());
        Assert.Equal(1, body.GetProperty("admission_type").GetInt32());
        Assert.Equal("Organizer", body.GetProperty("sponsor").GetString());
        Assert.Equal("host", body.GetProperty("hosts")[0].GetProperty("userid").GetString());
        Assert.False(body.TryGetProperty("enable_registration", out _));
        Assert.Equal("webinar-1", response.WebinarId);
        Assert.Equal("123", response.WebinarCode);
        Assert.Equal(1700000000, response.WebinarStart);
        Assert.Equal("https://join.example/", response.JoinUrl);
    }

    [Fact]
    public async Task ModifyAndCancelWebinar_UseMeetingIdAndCancelReason()
    {
        var (_, updateBody) = await InvokeAsync("/cgi-bin/meeting/update_webinars", """{"errcode":0}""",
            service => service.ModifyWebinarAsync(new()
            {
                WebinarId = "webinar-1",
                UserId = "host",
                Subject = "Webinar",
                WebinarStart = 1700000000,
                WebinarEnd = 1700001800,
                AdmissionType = 2,
                Password = "1234"
            }));
        var (_, cancelBody) = await InvokeAsync("/cgi-bin/meeting/cancel_webinars", """{"errcode":0}""",
            service => service.CancelWebinarAsync(new()
            {
                WebinarId = "webinar-1",
                UserId = "host",
                ReasonCode = 7,
                ReasonDetail = "Cancelled by organizer"
            }));

        Assert.Equal("webinar-1", updateBody.GetProperty("meetingid").GetString());
        Assert.Equal("1700001800", updateBody.GetProperty("end_time").GetString());
        Assert.Equal(2, updateBody.GetProperty("admission_type").GetInt32());
        Assert.Equal("webinar-1", cancelBody.GetProperty("meetingid").GetString());
        Assert.Equal(7, cancelBody.GetProperty("reason_code").GetInt32());
    }

    [Fact]
    public async Task GetWebinarDetail_QueriesByCodeAndReadsFlatResponse()
    {
        var (response, body) = await InvokeAsync("/cgi-bin/meeting/get_webinars",
            """{"meetingid":"webinar-1","subject":"Webinar","status":"MEETING_STATE_STARTED","start_time":"1700000000","display_number_of_participants":"1"}""",
            service => service.GetWebinarDetailAsync(new() { MeetingCode = "123" }));

        Assert.Equal("123", body.GetProperty("meeting_code").GetString());
        Assert.False(body.TryGetProperty("meetingid", out _));
        Assert.Equal("webinar-1", response.WebinarId);
        Assert.Equal("MEETING_STATE_STARTED", response.State);
        Assert.Equal(1700000000, response.WebinarStart);
        Assert.Equal(1, response.DisplayParticipantCount);
    }

    private static async Task<(T Response, JsonElement Body)> InvokeAsync<T>(
        string path, string responseJson, Func<MeetingService, Task<T>> invoke)
    {
        using var handler = new ContractHandler(path, responseJson);
        using var http = new HttpClient(handler);
        using var client = WecomClient.Create(new WecomOptions { CorpId = "corp", CorpSecret = "secret" }, http);
        client.SetAccessToken("test-token");

        var response = await invoke(client.Meeting);
        return (response, handler.Body);
    }

    private sealed class ContractHandler(string path, string responseJson) : HttpMessageHandler
    {
        public JsonElement Body { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal(path, request.RequestUri!.AbsolutePath);
            Assert.Equal("?access_token=test-token", request.RequestUri.Query);
            Assert.Equal("application/json", request.Content!.Headers.ContentType!.MediaType);
            using var body = JsonDocument.Parse(await request.Content.ReadAsStringAsync(cancellationToken));
            Body = body.RootElement.Clone();
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(responseJson) };
        }
    }
}
