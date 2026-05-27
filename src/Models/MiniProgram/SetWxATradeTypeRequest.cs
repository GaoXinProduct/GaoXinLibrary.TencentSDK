using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 交易类型变更申请请求（POST /wxa/sec/order/set_trade_type）
/// </summary>
public sealed class SetWxATradeTypeRequest
{
    /// <summary>交易类型（1-实物 2-虚拟）</summary>
    [JsonPropertyName("trade_type")] public required int TradeType { get; set; }
}