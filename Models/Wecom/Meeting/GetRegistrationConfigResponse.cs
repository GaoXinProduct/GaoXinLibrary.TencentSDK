using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议报名配置响应</summary>
/// <remarks>doc path: /98800</remarks>
public class GetRegistrationConfigResponse : WecomBaseResponse
{
    /// <summary>报名配置信息</summary>
    [JsonPropertyName("registration_config")]
    public RegistrationConfigInfo? RegistrationConfig { get; set; }
}

/// <summary>报名配置信息</summary>
public class RegistrationConfigInfo
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

/// <summary>报名问题信息</summary>
public class RegistrationQuestionInfo
{
    /// <summary>问题ID</summary>
    [JsonPropertyName("question_id")]
    public string QuestionId { get; set; } = string.Empty;

    /// <summary>问题内容</summary>
    [JsonPropertyName("question_content")]
    public string QuestionContent { get; set; } = string.Empty;

    /// <summary>问题类型：1-单行文本，2-多行文本，3-单选，4-多选</summary>
    [JsonPropertyName("question_type")]
    public int QuestionType { get; set; }

    /// <summary>是否为必填</summary>
    [JsonPropertyName("is_required")]
    public bool IsRequired { get; set; }

    /// <summary>选项列表</summary>
    [JsonPropertyName("options")]
    public List<string>? Options { get; set; }
}