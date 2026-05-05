using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>添加会议背景请求</summary>
/// <remarks>doc path: /98851</remarks>
public record AddMeetingBackgroundRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>背景类型：1-图片，2-视频</summary>
    [JsonPropertyName("background_type")]
    public int BackgroundType { get; init; }

    /// <summary>背景URL</summary>
    [JsonPropertyName("background_url")]
    public string BackgroundUrl { get; init; } = string.Empty;

    /// <summary>背景名称</summary>
    [JsonPropertyName("background_name")]
    public string? BackgroundName { get; init; }
}