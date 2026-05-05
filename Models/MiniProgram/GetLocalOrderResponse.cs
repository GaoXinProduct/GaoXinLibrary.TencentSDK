using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 拉取配送单信息响应
/// </summary>
public sealed class GetLocalOrderResponse : WechatBaseResponse
{
    /// <summary>订单状态</summary>
    [JsonPropertyName("order_status")] public int OrderStatus { get; init; }
    /// <summary>配送员信息</summary>
    [JsonPropertyName("deliverer")] public DeliveryDeliverer? Deliverer { get; init; }
    /// <summary>下单时间</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
    /// <summary>更新时间</summary>
    [JsonPropertyName("update_time")] public long UpdateTime { get; init; }
}