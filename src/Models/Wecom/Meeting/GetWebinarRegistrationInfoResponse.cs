using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会报名信息响应</summary>
/// <remarks>doc path: /98876</remarks>
public class GetWebinarRegistrationInfoResponse : WecomBaseResponse
{
    /// <summary>报名信息列表</summary>
    [JsonPropertyName("registration_list")]
    public List<WebinarRegistrationInfo>? RegistrationList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>网络研讨会报名信息</summary>
public class WebinarRegistrationInfo
{
    /// <summary>报名ID</summary>
    [JsonPropertyName("registration_id")]
    public string? RegistrationId { get; set; }

    /// <summary>报名人名称</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>报名人手机号</summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>报名人邮箱</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>审批状态：1-待审批，2-已通过，3-已拒绝</summary>
    [JsonPropertyName("approval_status")]
    public int ApprovalStatus { get; set; }

    /// <summary>报名时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("registration_time")]
    public long RegistrationTime { get; set; }

    /// <summary>报名问题答案列表</summary>
    [JsonPropertyName("answers")]
    public List<RegistrationAnswer>? Answers { get; set; }
}