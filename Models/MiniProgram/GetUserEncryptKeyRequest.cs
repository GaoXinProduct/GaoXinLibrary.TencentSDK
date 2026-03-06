using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取用户 encryptKey 请求（POST /wxa/business/getuserencryptkey）
/// </summary>
public class GetUserEncryptKeyRequest
{
    /// <summary>用户 OpenId</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }

    /// <summary>用户的 session_key</summary>
    [JsonPropertyName("session_key")] public required string SessionKey { get; set; }
}

