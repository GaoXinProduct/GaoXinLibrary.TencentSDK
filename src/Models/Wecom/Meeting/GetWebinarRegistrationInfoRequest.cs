using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会报名信息请求</summary>
/// <remarks>doc path: /98876</remarks>
public record GetWebinarRegistrationInfoRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>返回的最大记录数，最大1000，默认100</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    /// <summary>审批状态筛选：0-全部，1-待审批，2-已通过，3-已拒绝</summary>
    [JsonPropertyName("approval_status")]
    public int? ApprovalStatus { get; init; }
}