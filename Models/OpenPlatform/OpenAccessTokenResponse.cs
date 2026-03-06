using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OpenPlatform;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 通过 code 获取 access_token 响应
/// （GET /sns/oauth2/access_token）
/// </summary>
public class OpenAccessTokenResponse : WechatBaseResponse
{
    /// <summary>接口调用凭证</summary>
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    /// <summary>access_token 超时时间（秒）</summary>
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }

    /// <summary>用户刷新 access_token 的凭证</summary>
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }

    /// <summary>授权用户唯一标识</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>授权作用域（snsapi_login）</summary>
    [JsonPropertyName("scope")] public string? Scope { get; set; }

    /// <summary>用户统一标识（绑定开放平台时）</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}

