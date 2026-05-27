using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会详情请求</summary>
/// <remarks>doc path: /98860</remarks>
public record GetWebinarDetailRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>返回的直播链接</summary>
    [JsonPropertyName("with_live_url")]
    public bool? WithLiveUrl { get; init; }
}