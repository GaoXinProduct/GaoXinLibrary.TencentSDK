using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class ManageKeywordRuleRequest
{
    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }

    [JsonPropertyName("rule_type")]
    public int RuleType { get; set; }

    [JsonPropertyName("rule_name")]
    public string? RuleName { get; set; }

    [JsonPropertyName("keyword_list")]
    public string[]? KeywordList { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }
}