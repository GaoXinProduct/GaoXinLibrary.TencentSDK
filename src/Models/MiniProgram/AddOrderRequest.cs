using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 生成运单请求（POST /cgi-bin/express/business/order/add）
/// </summary>
public sealed class AddOrderRequest
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>用户OpenID</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    /// <summary>订单ID</summary>
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    /// <summary>下单时间（Unix时间戳）</summary>
    [JsonPropertyName("order_type")] public int OrderType { get; set; }
    /// <summary>快递公司运单号</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; set; }
    /// <summary>寄件人信息</summary>
    [JsonPropertyName("sender")] public required AddOrderSender Sender { get; set; }
    /// <summary>收件人信息</summary>
    [JsonPropertyName("receiver")] public required AddOrderReceiver Receiver { get; set; }
    /// <summary>包裹信息</summary>
    [JsonPropertyName("package_info")] public AddOrderPackage? PackageInfo { get; set; }
    /// <summary>保价金额（单位：分）</summary>
    [JsonPropertyName("insured")] public int Insured { get; set; }
    /// <summary>备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }
}

/// <summary>
/// 生成运单寄件人
/// </summary>
public sealed class AddOrderSender
{
    /// <summary>寄件人姓名</summary>
    [JsonPropertyName("name")] public required string Name { get; set; }
    /// <summary>寄件人电话</summary>
    [JsonPropertyName("tel")] public required string Tel { get; set; }
    /// <summary>寄件人公司</summary>
    [JsonPropertyName("company")] public string? Company { get; set; }
    /// <summary>寄件人地址</summary>
    [JsonPropertyName("address")] public required AddOrderAddress Address { get; set; }
}

/// <summary>
/// 生成运单收件人
/// </summary>
public sealed class AddOrderReceiver
{
    /// <summary>收件人姓名</summary>
    [JsonPropertyName("name")] public required string Name { get; set; }
    /// <summary>收件人电话</summary>
    [JsonPropertyName("tel")] public required string Tel { get; set; }
    /// <summary>收件人公司</summary>
    [JsonPropertyName("company")] public string? Company { get; set; }
    /// <summary>收件人地址</summary>
    [JsonPropertyName("address")] public required AddOrderAddress Address { get; set; }
}

/// <summary>
/// 生成运单地址
/// </summary>
public sealed class AddOrderAddress
{
    /// <summary>省</summary>
    [JsonPropertyName("province")] public required string Province { get; set; }
    /// <summary>市</summary>
    [JsonPropertyName("city")] public required string City { get; set; }
    /// <summary>区</summary>
    [JsonPropertyName("district")] public required string District { get; set; }
    /// <summary>详细地址</summary>
    [JsonPropertyName("address")] public required string Address { get; set; }
}

/// <summary>
/// 生成运单包裹信息
/// </summary>
public sealed class AddOrderPackage
{
    /// <summary>商品名称</summary>
    [JsonPropertyName("goods")] public required List<AddOrderGoods> Goods { get; set; }
    /// <summary>包裹重量（单位：kg）</summary>
    [JsonPropertyName("weight")] public int Weight { get; set; }
    /// <summary>商品数量</summary>
    [JsonPropertyName("count")] public int Count { get; set; }
}

/// <summary>
/// 生成运单商品
/// </summary>
public sealed class AddOrderGoods
{
    /// <summary>商品名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
    /// <summary>商品数量</summary>
    [JsonPropertyName("count")] public int Count { get; set; }
}