
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class InterceptRuleInfo
{
    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }

    [JsonPropertyName("rule_name")]
    public string? RuleName { get; set; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    [JsonPropertyName("word_list")]
    public string[]? WordList { get; set; }

    [JsonPropertyName("semantics_list")]
    public int[]? SemanticsList { get; set; }

    [JsonPropertyName("intercept_type")]
    public int InterceptType { get; set; }

    [JsonPropertyName("applicable_range")]
    public InterceptRuleRange? ApplicableRange { get; set; }
}
