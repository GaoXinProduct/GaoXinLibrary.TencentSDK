using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 模拟更新配送单状态请求（POST /cgi-bin/express/delivery/open/realmock_update_order）
/// </summary>
public sealed class RealMockUpdateOrderRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>配送状态（102已取件 103配送中 104已完成 800取消）</summary>
    [JsonPropertyName("order_status")] public required int OrderStatus { get; set; }
}