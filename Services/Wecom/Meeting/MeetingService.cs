using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议服务实现</summary>
public class MeetingService : IMeetingService
{
    private readonly WecomHttpClient _http;

    public MeetingService(WecomHttpClient http) => _http = http;

    public async Task<CreateMeetingResponse> CreateMeetingAsync(string title, long meetingStart, long meetingEnd, string adminUserId, string? description = null, CancellationToken ct = default)
        => await _http.PostAsync<CreateMeetingResponse>("/cgi-bin/meeting/create",
            new { title, meeting_start = meetingStart, meeting_end = meetingEnd, admin_userid = adminUserId, description }, ct);

    public async Task UpdateMeetingAsync(string meetingId, string? title = null, long? meetingStart = null, long? meetingEnd = null, string? description = null, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update",
            new { meetingid = meetingId, title, meeting_start = meetingStart, meeting_end = meetingEnd, description }, ct);

    public async Task CancelMeetingAsync(string meetingId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/cancel",
            new { meetingid = meetingId }, ct);

    public async Task<MeetingInfo?> GetMeetingAsync(string meetingId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetMeetingResponse>("/cgi-bin/meeting/get_info",
            new { meetingid = meetingId }, ct);
        return resp.MeetingInfo;
    }

    public async Task<GetUserMeetingIdResponse> GetUserMeetingIdAsync(string userId, string? cursor = null, int limit = 20, CancellationToken ct = default)
        => await _http.PostAsync<GetUserMeetingIdResponse>("/cgi-bin/meeting/get_user_meetingid",
            new { userid = userId, cursor = cursor ?? "", limit }, ct);
}
