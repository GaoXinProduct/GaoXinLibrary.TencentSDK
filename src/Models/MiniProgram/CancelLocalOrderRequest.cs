using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 取消配送单请求（POST /cgi-bin/express/delivery/open/cancel_local_order）
/// </summary>
public sealed class CancelLocalOrderRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>取消原因</summary>
    [JsonPropertyName("cancel_reason")] public string? CancelReason { get; set; }
}