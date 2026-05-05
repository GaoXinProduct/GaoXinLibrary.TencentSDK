using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取用户布局请求</summary>
/// <remarks>doc path: /98865</remarks>
public record GetUserLayoutRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;
}