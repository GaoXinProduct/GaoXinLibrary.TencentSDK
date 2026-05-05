using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetHitKeywordRuleRequest
{
    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 10;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    [JsonPropertyName("begin_time")]
    public long? BeginTime { get; set; }

    [JsonPropertyName("end_time")]
    public long? EndTime { get; set; }
}