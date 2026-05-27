using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>导入网络研讨会报名信息请求</summary>
/// <remarks>doc path: /98880</remarks>
public record ImportWebinarRegistrationRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>报名信息列表</summary>
    [JsonPropertyName("registration_list")]
    public List<ImportRegistrationItem>? RegistrationList { get; init; }
}