using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 重新下单响应
/// </summary>
public sealed class ReOrderResponse : WechatBaseResponse
{
    /// <summary>新运单号</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; init; }
}