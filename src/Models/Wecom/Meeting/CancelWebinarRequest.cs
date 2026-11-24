using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>取消网络研讨会请求</summary>
/// <remarks>doc path: /98870</remarks>
public record CancelWebinarRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("meetingid")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>取消原因代码，由调用方定义。</summary>
    [JsonPropertyName("reason_code")]
    public int ReasonCode { get; init; }

    [JsonPropertyName("reason_detail")]
    public string? ReasonDetail { get; init; }
}
