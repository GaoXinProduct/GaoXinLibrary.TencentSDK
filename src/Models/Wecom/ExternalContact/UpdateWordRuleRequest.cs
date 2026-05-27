
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class UpdateWordRuleRequest
{
    [JsonPropertyName("rule_id")]
    public string RuleId { get; set; } = string.Empty;

    [JsonPropertyName("rule_name")]
    public string? RuleName { get; set; }

    [JsonPropertyName("word_list")]
    public string[]? WordList { get; set; }

    [JsonPropertyName("semantics_list")]
    public int[]? SemanticsList { get; set; }

    [JsonPropertyName("intercept_type")]
    public int? InterceptType { get; set; }

    [JsonPropertyName("applicable_range")]
    public WordRuleApplicableRange? ApplicableRange { get; set; }
}
