using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>取消网络研讨会请求</summary>
/// <remarks>doc path: /98870</remarks>
public record CancelWebinarRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;
}