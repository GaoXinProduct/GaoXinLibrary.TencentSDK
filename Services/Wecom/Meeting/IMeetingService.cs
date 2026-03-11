using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议服务接口</summary>
public interface IMeetingService
{
    /// <summary>创建预约会议</summary>
    Task<CreateMeetingResponse> CreateMeetingAsync(string title, long meetingStart, long meetingEnd, string adminUserId, string? description = null, CancellationToken ct = default);

    /// <summary>修改预约会议</summary>
    Task UpdateMeetingAsync(string meetingId, string? title = null, long? meetingStart = null, long? meetingEnd = null, string? description = null, CancellationToken ct = default);

    /// <summary>取消预约会议</summary>
    Task CancelMeetingAsync(string meetingId, CancellationToken ct = default);

    /// <summary>获取会议详情</summary>
    Task<MeetingInfo?> GetMeetingAsync(string meetingId, CancellationToken ct = default);

    /// <summary>获取成员会议ID列表</summary>
    Task<GetUserMeetingIdResponse> GetUserMeetingIdAsync(string userId, string? cursor = null, int limit = 20, CancellationToken ct = default);
}
