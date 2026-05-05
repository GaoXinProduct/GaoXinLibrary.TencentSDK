using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>关闭成员屏幕共享请求</summary>
/// <remarks>doc path: /98185</remarks>
public record StopScreenShareRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid（主持人）</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>被关闭屏幕共享的成员userid</summary>
    [JsonPropertyName("target_userid")]
    public string? TargetUserId { get; init; }
}