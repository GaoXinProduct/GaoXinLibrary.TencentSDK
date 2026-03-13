using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议服务接口</summary>
public interface IMeetingService
{
    /// <summary>创建预约会议</summary>
    Task<CreateMeetingResponse> CreateMeetingAsync(CreateMeetingRequest request, CancellationToken ct = default);

    /// <summary>修改预约会议</summary>
    Task UpdateMeetingAsync(UpdateMeetingRequest request, CancellationToken ct = default);

    /// <summary>取消预约会议</summary>
    Task CancelMeetingAsync(CancelMeetingRequest request, CancellationToken ct = default);

    /// <summary>获取会议详情</summary>
    Task<MeetingInfo?> GetMeetingAsync(GetMeetingRequest request, CancellationToken ct = default);

    /// <summary>获取成员会议ID列表</summary>
    Task<GetUserMeetingIdResponse> GetUserMeetingIdAsync(GetUserMeetingIdRequest request, CancellationToken ct = default);
}
