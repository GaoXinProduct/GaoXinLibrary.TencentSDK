using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 取消运单响应
/// </summary>
public sealed class CancelOrderResponse : WechatBaseResponse
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; init; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; init; }
    /// <summary>取消状态（0取消中 1已取消）</summary>
    [JsonPropertyName("cancel_status")] public int CancelStatus { get; init; }
}