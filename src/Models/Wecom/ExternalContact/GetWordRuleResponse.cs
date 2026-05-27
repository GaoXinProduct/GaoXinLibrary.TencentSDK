using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取敏感词规则详情响应</summary>
public sealed class GetWordRuleResponse : WecomBaseResponse
{
    /// <summary>规则 ID</summary>
    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }

    /// <summary>规则名称</summary>
    [JsonPropertyName("rule_name")]
    public string? RuleName { get; set; }

    /// <summary>敏感词列表</summary>
    [JsonPropertyName("word_list")]
    public string[]? WordList { get; set; }

    /// <summary>语义规则列表</summary>
    [JsonPropertyName("semantics_list")]
    public int[]? SemanticsList { get; set; }

    /// <summary>适用范围</summary>
    [JsonPropertyName("applicable_range")]
    public JsonElement? ApplicableRange { get; set; }

    /// <summary>创建时间</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    /// <summary>更新时间</summary>
    [JsonPropertyName("update_time")]
    public long UpdateTime { get; set; }
}
