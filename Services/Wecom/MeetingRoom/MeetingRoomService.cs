using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>会议室服务实现</summary>
public class MeetingRoomService : IMeetingRoomService
{
    private readonly WecomHttpClient _http;

    public MeetingRoomService(WecomHttpClient http) => _http = http;

    public async Task AddMeetingRoomAsync(MeetingRoomInfo room, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/add", room, ct);

    public async Task<MeetingRoomInfo[]> GetMeetingRoomListAsync(string? city = null, string? building = null, string? floor = null, int? equipment = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetMeetingRoomListResponse>("/cgi-bin/oa/meetingroom/list",
            new { city, building, floor, equipment }, ct);
        return resp.MeetingRoomList ?? [];
    }

    public async Task EditMeetingRoomAsync(MeetingRoomInfo room, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/edit", room, ct);

    public async Task DeleteMeetingRoomAsync(int meetingRoomId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/del",
            new { meetingroom_id = meetingRoomId }, ct);

    public async Task<BookingInfo[]> GetBookingInfoAsync(int meetingRoomId, long startTime, long endTime, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetBookingInfoResponse>("/cgi-bin/oa/meetingroom/get_booking_info",
            new { meetingroom_id = meetingRoomId, start_time = startTime, end_time = endTime }, ct);
        return resp.BookingList ?? [];
    }

    public async Task BookMeetingRoomAsync(int meetingRoomId, long startTime, long endTime, string booker, string? title = null, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/book",
            new { meetingroom_id = meetingRoomId, start_time = startTime, end_time = endTime, booker, title }, ct);

    public async Task CancelBookingAsync(int meetingRoomId, string bookingId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/cancel_book",
            new { meetingroom_id = meetingRoomId, booking_id = bookingId }, ct);
}
