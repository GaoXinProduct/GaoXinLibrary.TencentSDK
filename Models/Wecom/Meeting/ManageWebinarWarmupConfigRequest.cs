using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>管理网络研讨会暖场配置请求</summary>
/// <remarks>doc path: /98882</remarks>
public record ManageWebinarWarmupConfigRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>是否开启暖场</summary>
    [JsonPropertyName("enable_warmup")]
    public bool EnableWarmup { get; init; }

    /// <summary>暖场视频URL</summary>
    [JsonPropertyName("warmup_video_url")]
    public string? WarmupVideoUrl { get; init; }

    /// <summary>暖场视频时长（秒）</summary>
    [JsonPropertyName("warmup_video_duration")]
    public int? WarmupVideoDuration { get; init; }
}