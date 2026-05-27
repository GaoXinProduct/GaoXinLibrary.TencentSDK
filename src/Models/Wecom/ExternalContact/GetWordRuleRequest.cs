
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取敏感词规则详情请求</summary>
public sealed class GetWordRuleRequest
{
    /// <summary>规则 ID</summary>
    [JsonPropertyName("rule_id")]
    public string RuleId { get; set; } = string.Empty;
}
