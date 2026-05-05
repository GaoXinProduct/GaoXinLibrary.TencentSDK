using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会报名配置响应</summary>
/// <remarks>doc path: /98874</remarks>
public class GetWebinarRegistrationConfigResponse : WecomBaseResponse
{
    /// <summary>报名配置信息</summary>
    [JsonPropertyName("registration_config")]
    public WebinarRegistrationConfigInfo? RegistrationConfig { get; set; }
}

/// <summary>网络研讨会报名配置信息</summary>
public class WebinarRegistrationConfigInfo
{
    /// <summary>是否开启报名</summary>
    [JsonPropertyName("enable_registration")]
    public bool EnableRegistration { get; set; }

    /// <summary>报名问题列表</summary>
    [JsonPropertyName("registration_questions")]
    public List<RegistrationQuestionInfo>? RegistrationQuestions { get; set; }

    /// <summary>是否开启报名审核</summary>
    [JsonPropertyName("need_approval")]
    public bool NeedApproval { get; set; }

    /// <summary>是否开启报名截止时间</summary>
    [JsonPropertyName("has_registration_deadline")]
    public bool HasRegistrationDeadline { get; set; }

    /// <summary>报名截止时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("registration_deadline")]
    public long RegistrationDeadline { get; set; }

    /// <summary>报名总人数</summary>
    [JsonPropertyName("registration_count")]
    public int RegistrationCount { get; set; }

    /// <summary>已报名人数</summary>
    [JsonPropertyName("registered_count")]
    public int RegisteredCount { get; set; }
}