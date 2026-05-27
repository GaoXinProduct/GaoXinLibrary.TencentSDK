using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 批量获取运单数据请求（POST /cgi-bin/express/business/order/batchget）
/// </summary>
public sealed class BatchGetOrderRequest
{
    /// <summary>订单列表（最多同时查询100个订单）</summary>
    [JsonPropertyName("order_list")] public required List<BatchGetOrderKey> OrderList { get; set; }
}

/// <summary>
/// 批量查询订单键
/// </summary>
public sealed class BatchGetOrderKey
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
}