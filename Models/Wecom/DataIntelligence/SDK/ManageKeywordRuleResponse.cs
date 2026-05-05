using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class ManageKeywordRuleResponse : WecomBaseResponse
{
    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }
}