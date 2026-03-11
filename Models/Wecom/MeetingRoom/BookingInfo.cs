using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>会议室预定信息</summary>
public class BookingInfo
{
    /// <summary>预定ID</summary>
    [JsonPropertyName("booking_id")] public string? BookingId { get; set; }

    /// <summary>会议室ID</summary>
    [JsonPropertyName("meetingroom_id")] public int MeetingRoomId { get; set; }

    /// <summary>预定人userid</summary>
    [JsonPropertyName("booker")] public string? Booker { get; set; }

    /// <summary>预定开始时间</summary>
    [JsonPropertyName("start_time")] public long StartTime { get; set; }

    /// <summary>预定结束时间</summary>
    [JsonPropertyName("end_time")] public long EndTime { get; set; }

    /// <summary>预定主题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>预定状态，0-待审批，1-预定中，2-已取消，3-已释放，4-已过期</summary>
    [JsonPropertyName("status")] public int Status { get; set; }
}
