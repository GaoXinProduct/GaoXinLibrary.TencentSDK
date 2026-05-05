using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>设置会议默认背景请求</summary>
/// <remarks>doc path: /98852</remarks>
public record SetDefaultBackgroundRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>背景ID</summary>
    [JsonPropertyName("background_id")]
    public string BackgroundId { get; init; } = string.Empty;
}