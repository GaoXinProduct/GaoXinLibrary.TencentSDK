using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 确认收货提醒请求（POST /wxa/sec/order/notify_confirm_receive）
/// </summary>
public sealed class NotifyConfirmReceiveRequest
{
    /// <summary>订单ID</summary>
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
}