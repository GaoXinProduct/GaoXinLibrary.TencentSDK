using GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议室服务接口</summary>
public interface IMeetingRoomService
{
    /// <summary>添加会议室</summary>
    Task AddMeetingRoomAsync(MeetingRoomInfo room, CancellationToken ct = default);

    /// <summary>查询会议室列表</summary>
    Task<MeetingRoomInfo[]> GetMeetingRoomListAsync(string? city = null, string? building = null, string? floor = null, int? equipment = null, CancellationToken ct = default);

    /// <summary>编辑会议室</summary>
    Task EditMeetingRoomAsync(MeetingRoomInfo room, CancellationToken ct = default);

    /// <summary>删除会议室</summary>
    Task DeleteMeetingRoomAsync(int meetingRoomId, CancellationToken ct = default);

    /// <summary>查询预定信息</summary>
    Task<BookingInfo[]> GetBookingInfoAsync(int meetingRoomId, long startTime, long endTime, CancellationToken ct = default);

    /// <summary>预定会议室</summary>
    Task BookMeetingRoomAsync(int meetingRoomId, long startTime, long endTime, string booker, string? title = null, CancellationToken ct = default);

    /// <summary>取消预定</summary>
    Task CancelBookingAsync(int meetingRoomId, string bookingId, CancellationToken ct = default);
}
