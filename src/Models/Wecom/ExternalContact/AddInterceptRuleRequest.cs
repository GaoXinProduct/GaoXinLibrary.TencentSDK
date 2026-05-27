
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class AddInterceptRuleRequest
{
    [JsonPropertyName("rule_name")]
    public string RuleName { get; set; } = string.Empty;

    [JsonPropertyName("word_list")]
    public string[] WordList { get; set; } = [];

    [JsonPropertyName("semantics_list")]
    public int[]? SemanticsList { get; set; }

    [JsonPropertyName("intercept_type")]
    public int InterceptType { get; set; }

    [JsonPropertyName("applicable_range")]
    public InterceptRuleRange? ApplicableRange { get; set; }
}

public sealed class InterceptRuleRange
{
    [JsonPropertyName("user_list")]
    public string[]? UserList { get; set; }

    [JsonPropertyName("department_list")]
    public int[]? DepartmentList { get; set; }
}
