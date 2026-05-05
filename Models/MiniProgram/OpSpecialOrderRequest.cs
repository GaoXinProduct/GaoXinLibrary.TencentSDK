using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 特殊发货报备请求（POST /wxa/sec/order/op_special_order）
/// </summary>
public sealed class OpSpecialOrderRequest
{
    /// <summary>订单ID</summary>
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    /// <summary>特殊发货原因</summary>
    [JsonPropertyName("reason")] public required string Reason { get; set; }
    /// <summary>发货时间</summary>
    [JsonPropertyName("shipping_time")] public long ShippingTime { get; set; }
}