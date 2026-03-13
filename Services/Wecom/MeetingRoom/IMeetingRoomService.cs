using GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议室服务接口</summary>
public interface IMeetingRoomService
{
    /// <summary>添加会议室</summary>
    Task AddMeetingRoomAsync(MeetingRoomInfo room, CancellationToken ct = default);

    /// <summary>查询会议室列表</summary>
    Task<MeetingRoomInfo[]> GetMeetingRoomListAsync(ListMeetingRoomRequest request, CancellationToken ct = default);

    /// <summary>编辑会议室</summary>
    Task EditMeetingRoomAsync(MeetingRoomInfo room, CancellationToken ct = default);

    /// <summary>删除会议室</summary>
    Task DeleteMeetingRoomAsync(DeleteMeetingRoomRequest request, CancellationToken ct = default);

    /// <summary>查询预定信息</summary>
    Task<BookingInfo[]> GetBookingInfoAsync(GetBookingInfoRequest request, CancellationToken ct = default);

    /// <summary>预定会议室</summary>
    Task BookMeetingRoomAsync(BookMeetingRoomRequest request, CancellationToken ct = default);

    /// <summary>取消预定</summary>
    Task CancelBookingAsync(CancelBookingRequest request, CancellationToken ct = default);
}
