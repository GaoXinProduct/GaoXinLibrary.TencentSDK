using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

public class GetMomentsRuleGroupResponse : WecomBaseResponse
{
    [JsonPropertyName("strategy")]
    public RuleGroupInfo[]? Strategy { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}