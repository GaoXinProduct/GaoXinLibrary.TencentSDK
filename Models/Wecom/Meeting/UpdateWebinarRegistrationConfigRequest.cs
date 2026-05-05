using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改网络研讨会报名配置请求</summary>
/// <remarks>doc path: /98875</remarks>
public record UpdateWebinarRegistrationConfigRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>是否开启报名</summary>
    [JsonPropertyName("enable_registration")]
    public bool EnableRegistration { get; init; }

    /// <summary>报名问题列表</summary>
    [JsonPropertyName("registration_questions")]
    public List<RegistrationQuestion>? RegistrationQuestions { get; init; }

    /// <summary>是否开启报名审核</summary>
    [JsonPropertyName("need_approval")]
    public bool? NeedApproval { get; init; }

    /// <summary>是否开启报名截止时间</summary>
    [JsonPropertyName("has_registration_deadline")]
    public bool? HasRegistrationDeadline { get; init; }

    /// <summary>报名截止时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("registration_deadline")]
    public long? RegistrationDeadline { get; init; }
}