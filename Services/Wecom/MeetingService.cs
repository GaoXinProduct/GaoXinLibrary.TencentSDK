using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议服务实现</summary>
public class MeetingService
{
    private readonly WecomHttpClient _http;

    public MeetingService(WecomHttpClient http) => _http = http;

    /// <summary>创建预约会议</summary>
    public async Task<CreateMeetingResponse> CreateMeetingAsync(CreateMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateMeetingResponse>("/cgi-bin/meeting/create", request, ct);

    /// <summary>修改预约会议</summary>
    public async Task UpdateMeetingAsync(UpdateMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/update", request, ct);

    /// <summary>取消预约会议</summary>
    public async Task CancelMeetingAsync(CancelMeetingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/meeting/cancel", request, ct);

    /// <summary>获取会议详情</summary>
    public async Task<MeetingInfo?> GetMeetingAsync(GetMeetingRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetMeetingResponse>("/cgi-bin/meeting/get_info", request, ct);
        return resp.MeetingInfo;
    }

    /// <summary>获取成员会议ID列表</summary>
    public async Task<GetUserMeetingIdResponse> GetUserMeetingIdAsync(GetUserMeetingIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserMeetingIdResponse>("/cgi-bin/meeting/get_user_meetingid", request, ct);
}
