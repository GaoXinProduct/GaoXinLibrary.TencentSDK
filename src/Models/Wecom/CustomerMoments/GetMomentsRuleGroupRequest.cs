using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

/// <summary>
/// 获取朋友圈规则组列表请求
/// </summary>
public record GetMomentsRuleGroupRequest
{
    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>分页大小（最大1000）</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}