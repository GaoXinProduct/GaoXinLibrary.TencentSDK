using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetHitKeywordRuleResponse : WecomBaseResponse
{
    [JsonPropertyName("hit_list")]
    public HitKeywordRule[]? HitList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public class HitKeywordRule
{
    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }

    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }

    [JsonPropertyName("hit_keyword")]
    public string? HitKeyword { get; set; }

    [JsonPropertyName("hit_time")]
    public long HitTime { get; set; }
}