using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 添加配送单请求（POST /cgi-bin/express/delivery/open/add_local_order）
/// </summary>
public sealed class AddLocalOrderRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>下单商户身份ID</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
    /// <summary>收货人信息</summary>
    [JsonPropertyName("receiver")] public required DeliveryReceiver Receiver { get; set; }
    /// <summary>商家信息</summary>
    [JsonPropertyName("sender")] public required DeliverySender Sender { get; set; }
    /// <summary>订单ID</summary>
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    /// <summary>订单商品详情</summary>
    [JsonPropertyName("goods")] public DeliveryGoods? Goods { get; set; }
    /// <summary>备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }
}