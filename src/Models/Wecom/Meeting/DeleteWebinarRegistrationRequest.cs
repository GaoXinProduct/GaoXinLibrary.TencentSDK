using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>删除网络研讨会报名信息请求</summary>
/// <remarks>doc path: /98881</remarks>
public record DeleteWebinarRegistrationRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>报名ID列表</summary>
    [JsonPropertyName("registration_id_list")]
    public List<string> RegistrationIdList { get; init; } = new();
}