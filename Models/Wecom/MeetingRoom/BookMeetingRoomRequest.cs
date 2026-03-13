using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>预定会议室请求</summary>
public class BookMeetingRoomRequest
{
    /// <summary>会议室 ID</summary>
    [JsonPropertyName("meetingroom_id")]
    public int MeetingRoomId { get; set; }

    /// <summary>预定开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>预定结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>预定人的 userid</summary>
    [JsonPropertyName("booker")]
    public string Booker { get; set; } = string.Empty;

    /// <summary>会议主题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
