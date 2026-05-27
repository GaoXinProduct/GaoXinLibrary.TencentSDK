using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改会议报名配置请求</summary>
/// <remarks>doc path: /98797</remarks>
public record UpdateRegistrationConfigRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>是否开启报名：true-开启，false-关闭</summary>
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

/// <summary>报名问题</summary>
public class RegistrationQuestion
{
    /// <summary>问题ID</summary>
    [JsonPropertyName("question_id")]
    public string QuestionId { get; init; } = string.Empty;

    /// <summary>问题内容</summary>
    [JsonPropertyName("question_content")]
    public string QuestionContent { get; init; } = string.Empty;

    /// <summary>问题类型：1-单行文本，2-多行文本，3-单选，4-多选</summary>
    [JsonPropertyName("question_type")]
    public int QuestionType { get; init; }

    /// <summary>是否为必填：true-必填，false-选填</summary>
    [JsonPropertyName("is_required")]
    public bool IsRequired { get; init; }

    /// <summary>选项列表（单选/多选题）</summary>
    [JsonPropertyName("options")]
    public List<string>? Options { get; init; }
}