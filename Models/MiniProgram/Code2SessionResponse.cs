using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序登录凭证校验响应（GET /sns/jscode2session）
/// </summary>
public class Code2SessionResponse : WechatBaseResponse
{
    /// <summary>用户唯一标识</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>会话密钥</summary>
    [JsonPropertyName("session_key")] public string? SessionKey { get; set; }

    /// <summary>用户在开放平台的唯一标识符（需绑定开放平台）</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}

