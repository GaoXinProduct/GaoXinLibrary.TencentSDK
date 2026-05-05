using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 生成运单响应
/// </summary>
public sealed class AddOrderResponse : WechatBaseResponse
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; init; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; init; }
    /// <summary>运单价格（单位：分）</summary>
    [JsonPropertyName("delivery_amount")] public int DeliveryAmount { get; init; }
    /// <summary>保价金额（单位：分）</summary>
    [JsonPropertyName("insured_amount")] public int InsuredAmount { get; init; }
    /// <summary>预计送达时间（Unix时间戳）</summary>
    [JsonPropertyName("promise_time")] public long PromiseTime { get; init; }
}