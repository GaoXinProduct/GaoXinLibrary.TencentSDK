using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 模拟更新订单状态请求（POST /cgi-bin/express/business/testupdateorder）
/// </summary>
public sealed class TestUpdateOrderRequest
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>用户OpenID</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    /// <summary>运单状态（快递公司侧订单状态）</summary>
    [JsonPropertyName("order_status")] public required int OrderStatus { get; set; }
    /// <summary>状态变更时间（Unix时间戳）</summary>
    [JsonPropertyName("status_update_time")] public required long StatusUpdateTime { get; set; }
    /// <summary>状态描述</summary>
    [JsonPropertyName("status_desc")] public string? StatusDesc { get; set; }
    /// <summary>预计送达时间（Unix时间戳）</summary>
    [JsonPropertyName("promise_time")] public long? PromiseTime { get; set; }
}