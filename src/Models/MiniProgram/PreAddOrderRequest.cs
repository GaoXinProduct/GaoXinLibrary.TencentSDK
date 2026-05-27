using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 预下配送单请求（POST /cgi-bin/express/delivery/open/preadd）
/// </summary>
public sealed class PreAddOrderRequest
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
}

/// <summary>
/// 收货人信息
/// </summary>
public sealed class DeliveryReceiver
{
    /// <summary>收货人姓名</summary>
    [JsonPropertyName("name")] public required string Name { get; set; }
    /// <summary>收货人电话</summary>
    [JsonPropertyName("phone")] public required string Phone { get; set; }
    /// <summary>收货人地址</summary>
    [JsonPropertyName("address")] public required string Address { get; set; }
    /// <summary>收货人经度</summary>
    [JsonPropertyName("lng")] public double Lng { get; set; }
    /// <summary>收货人纬度</summary>
    [JsonPropertyName("lat")] public double Lat { get; set; }
}

/// <summary>
/// 商家信息
/// </summary>
public sealed class DeliverySender
{
    /// <summary>商家姓名</summary>
    [JsonPropertyName("name")] public required string Name { get; set; }
    /// <summary>商家电话</summary>
    [JsonPropertyName("phone")] public required string Phone { get; set; }
    /// <summary>商家地址</summary>
    [JsonPropertyName("address")] public required string Address { get; set; }
    /// <summary>商家经度</summary>
    [JsonPropertyName("lng")] public double Lng { get; set; }
    /// <summary>商家纬度</summary>
    [JsonPropertyName("lat")] public double Lat { get; set; }
}

/// <summary>
/// 订单商品详情
/// </summary>
public sealed class DeliveryGoods
{
    /// <summary>商品类型</summary>
    [JsonPropertyName("goods_type")] public int GoodsType { get; set; }
    /// <summary>商品数量</summary>
    [JsonPropertyName("goods_count")] public int GoodsCount { get; set; }
    /// <summary>商品名称</summary>
    [JsonPropertyName("goods_name")] public string? GoodsName { get; set; }
}