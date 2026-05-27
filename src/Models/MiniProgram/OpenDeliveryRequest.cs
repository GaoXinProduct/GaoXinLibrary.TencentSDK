using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 申请开通即时配送请求（POST /cgi-bin/express/delivery/open/open_delivery）
/// </summary>
public sealed class OpenDeliveryRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>商户门店ID</summary>
    [JsonPropertyName("store_id")] public required string StoreId { get; set; }
}