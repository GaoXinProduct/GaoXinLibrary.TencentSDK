using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 取消运单请求（POST /cgi-bin/express/business/order/cancel）
/// </summary>
public sealed class CancelOrderRequest
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>用户OpenID</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    /// <summary>取消原因</summary>
    [JsonPropertyName("cancel_reason")] public string? CancelReason { get; set; }
    /// <summary>商家备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }
}