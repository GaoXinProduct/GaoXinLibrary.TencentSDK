using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>文件防泄漏规则</summary>
public class FileLeakPreventionRule
{
    /// <summary>规则id</summary>
    [JsonPropertyName("rule_id")] public int RuleId { get; set; }

    /// <summary>规则名称</summary>
    [JsonPropertyName("rule_name")] public string? RuleName { get; set; }

    /// <summary>规则说明</summary>
    [JsonPropertyName("rule_desc")] public string? RuleDesc { get; set; }
}
