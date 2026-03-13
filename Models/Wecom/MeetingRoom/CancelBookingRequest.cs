using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>取消预定会议室请求</summary>
public class CancelBookingRequest
{
    /// <summary>会议室 ID</summary>
    [JsonPropertyName("meetingroom_id")]
    public int MeetingRoomId { get; set; }

    /// <summary>预定 ID</summary>
    [JsonPropertyName("booking_id")]
    public string BookingId { get; set; } = string.Empty;
}
