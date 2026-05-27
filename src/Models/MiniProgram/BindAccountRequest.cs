using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 绑定/解绑物流账号请求（POST /cgi-bin/express/business/account/bind）
/// </summary>
public sealed class BindAccountRequest
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>用户OpenID</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
    /// <summary>操作类型（1绑定 2解绑）</summary>
    [JsonPropertyName("type")] public required int Type { get; set; }
    /// <summary>商户ID</summary>
    [JsonPropertyName("mch_id")] public string? MchId { get; set; }
}