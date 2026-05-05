using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>释放Rooms会议室请求</summary>
/// <remarks>doc path: /98792</remarks>
public record ReleaseRoomsRequest
{
    /// <summary>会议室ID列表</summary>
    [JsonPropertyName("room_ids")]
    public List<string> RoomIds { get; init; } = new();

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; init; }
}