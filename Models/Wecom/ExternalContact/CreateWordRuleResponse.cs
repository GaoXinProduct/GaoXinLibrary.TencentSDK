using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class CreateWordRuleResponse : WecomBaseResponse
{
    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }
}
