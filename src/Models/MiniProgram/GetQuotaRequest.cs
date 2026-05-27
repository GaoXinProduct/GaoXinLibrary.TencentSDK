using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取电子面单余额请求（POST /cgi-bin/express/business/delivery/getquota）
/// </summary>
public sealed class GetQuotaRequest
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>用户OpenID</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
}