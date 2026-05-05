using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 批量获取运单数据响应
/// </summary>
public sealed class BatchGetOrderResponse : WechatBaseResponse
{
    /// <summary>运单响应列表</summary>
    [JsonPropertyName("order_list")] public List<OrderDetail>? OrderList { get; init; }
}

/// <summary>
/// 订单详情
/// </summary>
public sealed class OrderDetail
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; init; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; init; }
    /// <summary>寄件人信息</summary>
    [JsonPropertyName("sender")] public ShippingContact? Sender { get; init; }
    /// <summary>收件人信息</summary>
    [JsonPropertyName("receiver")] public ShippingContact? Receiver { get; init; }
    /// <summary>订单状态（0正常 1取消 2超时）</summary>
    [JsonPropertyName("order_status")] public int OrderStatus { get; init; }
    /// <summary>运费（单位：分）</summary>
    [JsonPropertyName("delivery_amount")] public int DeliveryAmount { get; init; }
    /// <summary>保价金额（单位：分）</summary>
    [JsonPropertyName("insured_amount")] public int InsuredAmount { get; init; }
    /// <summary>运单轨迹</summary>
    [JsonPropertyName("waybill_data")] public List<WaybillDataItem>? WaybillData { get; init; }
    /// <summary>下单时间（Unix时间戳）</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
    /// <summary>最后更新时间（Unix时间戳）</summary>
    [JsonPropertyName("update_time")] public long UpdateTime { get; init; }
    /// <summary>预计送达时间（Unix时间戳）</summary>
    [JsonPropertyName("promise_time")] public long PromiseTime { get; init; }
}

/// <summary>
/// 运单数据项
/// </summary>
public sealed class WaybillDataItem
{
    /// <summary>运单数据键</summary>
    [JsonPropertyName("key")] public string? Key { get; init; }
    /// <summary>运单数据值</summary>
    [JsonPropertyName("value")] public string? Value { get; init; }
}