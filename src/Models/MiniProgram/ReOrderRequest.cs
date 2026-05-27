using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 重新下单请求（POST /cgi-bin/express/delivery/open/re_order）
/// </summary>
public sealed class ReOrderRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>原运单号</summary>
    [JsonPropertyName("original_waybill_id")] public required string OriginalWaybillId { get; set; }
    /// <summary>收货人信息</summary>
    [JsonPropertyName("receiver")] public required DeliveryReceiver Receiver { get; set; }
    /// <summary>商家信息</summary>
    [JsonPropertyName("sender")] public required DeliverySender Sender { get; set; }
    /// <summary>订单ID</summary>
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
}