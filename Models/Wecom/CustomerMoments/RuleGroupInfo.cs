using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

/// <summary>
/// 规则组信息
/// </summary>
public record RuleGroupInfo
{
    /// <summary>规则组id</summary>
    [JsonPropertyName("strategy_id")]
    public int StrategyId { get; set; }
}