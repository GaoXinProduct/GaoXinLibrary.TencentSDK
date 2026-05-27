using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 预下配送单响应
/// </summary>
public sealed class PreAddOrderResponse : WechatBaseResponse
{
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; init; }
    /// <summary>配送状态</summary>
    [JsonPropertyName("order_status")] public int OrderStatus { get; init; }
}