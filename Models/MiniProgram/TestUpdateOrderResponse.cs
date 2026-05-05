using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 模拟更新订单状态响应
/// </summary>
public sealed class TestUpdateOrderResponse : WechatBaseResponse
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; init; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; init; }
    /// <summary>更新结果</summary>
    [JsonPropertyName("result")] public string? Result { get; init; }
}