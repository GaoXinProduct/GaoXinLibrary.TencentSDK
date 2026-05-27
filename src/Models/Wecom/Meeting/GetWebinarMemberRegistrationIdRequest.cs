using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会成员报名ID请求</summary>
/// <remarks>doc path: /98873</remarks>
public record GetWebinarMemberRegistrationIdRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;
}