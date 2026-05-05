using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会报名配置请求</summary>
/// <remarks>doc path: /98874</remarks>
public record GetWebinarRegistrationConfigRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;
}