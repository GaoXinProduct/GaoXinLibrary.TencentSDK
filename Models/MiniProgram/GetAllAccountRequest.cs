using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取所有绑定的物流账号请求（POST /cgi-bin/express/business/account/getall）
/// </summary>
public sealed class GetAllAccountRequest
{
    /// <summary>用户OpenID</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
}