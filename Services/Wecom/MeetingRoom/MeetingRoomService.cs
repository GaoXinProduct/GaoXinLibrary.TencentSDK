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

    public async Task<MeetingRoomInfo[]> GetMeetingRoomListAsync(ListMeetingRoomRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetMeetingRoomListResponse>("/cgi-bin/oa/meetingroom/list", request, ct);
        return resp.MeetingRoomList ?? [];
    }

    public async Task EditMeetingRoomAsync(MeetingRoomInfo room, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/edit", room, ct);

    public async Task DeleteMeetingRoomAsync(DeleteMeetingRoomRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/del", request, ct);

    public async Task<BookingInfo[]> GetBookingInfoAsync(GetBookingInfoRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetBookingInfoResponse>("/cgi-bin/oa/meetingroom/get_booking_info", request, ct);
        return resp.BookingList ?? [];
    }

    public async Task BookMeetingRoomAsync(BookMeetingRoomRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/book", request, ct);

    public async Task CancelBookingAsync(CancelBookingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/oa/meetingroom/cancel_book", request, ct);
}
