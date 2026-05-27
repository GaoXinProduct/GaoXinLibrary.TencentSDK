using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 模拟配送公司更新配送单状态请求（POST /cgi-bin/express/delivery/open/mock_update_order）
/// </summary>
public sealed class MockUpdateOrderRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>配送状态</summary>
    [JsonPropertyName("order_status")] public required int OrderStatus { get; set; }
    /// <summary>配送员信息</summary>
    [JsonPropertyName("deliverer")] public DeliveryDeliverer? Deliverer { get; set; }
}

/// <summary>
/// 配送员信息
/// </summary>
public sealed class DeliveryDeliverer
{
    /// <summary>配送员姓名</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
    /// <summary>配送员电话</summary>
    [JsonPropertyName("phone")] public string? Phone { get; set; }
}