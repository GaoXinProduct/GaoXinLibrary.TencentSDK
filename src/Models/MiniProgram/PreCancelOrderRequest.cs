using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 预取消配送单请求（POST /cgi-bin/express/delivery/open/precancel）
/// </summary>
public sealed class PreCancelOrderRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>取消原因</summary>
    [JsonPropertyName("cancel_reason")] public string? CancelReason { get; set; }
}