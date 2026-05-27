using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>预定Rooms会议室请求</summary>
/// <remarks>doc path: /98791</remarks>
public record ReserveRoomsRequest
{
    /// <summary>会议室ID列表</summary>
    [JsonPropertyName("room_ids")]
    public List<string> RoomIds { get; init; } = new();

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>会议主题</summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long MeetingStart { get; init; }

    /// <summary>会议结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_end")]
    public long MeetingEnd { get; init; }

    /// <summary>是否在Rooms上展示日程</summary>
    [JsonPropertyName("show_on_device")]
    public bool? ShowOnDevice { get; init; }

    /// <summary>是否通过 Rooms 入会</summary>
    [JsonPropertyName("join_meeting_from_room")]
    public bool? JoinMeetingFromRoom { get; init; }
}