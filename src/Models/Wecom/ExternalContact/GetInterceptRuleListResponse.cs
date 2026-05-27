using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetInterceptRuleListResponse : WecomBaseResponse
{
    [JsonPropertyName("rule_list")]
    public InterceptRuleInfo[]? RuleList { get; set; }
}
