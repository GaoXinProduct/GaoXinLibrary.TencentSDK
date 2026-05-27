using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>审批网络研讨会报名信息请求</summary>
/// <remarks>doc path: /98877</remarks>
public record ApproveWebinarRegistrationRequest
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

    /// <summary>审批操作：1-通过，2-拒绝</summary>
    [JsonPropertyName("approval_action")]
    public int ApprovalAction { get; init; }
}