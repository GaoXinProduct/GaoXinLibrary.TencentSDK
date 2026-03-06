using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

// ─── 获取 Access Token ──────────────────────────────────────────────────

/// <summary>
/// 使用 Authorization Code 获取 Access Token 响应
/// <para>
/// 对应接口：GET https://graph.qq.com/oauth2.0/token<br/>
/// 参数 grant_type=authorization_code
/// </para>
/// </summary>
public class QQAccessTokenResponse : QQBaseResponse
{
    /// <summary>授权令牌</summary>
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    /// <summary>access_token 的有效期（秒）</summary>
    [JsonPropertyName("expires_in")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int ExpiresIn { get; set; }

    /// <summary>用于刷新 access_token 的凭证</summary>
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }

    /// <summary>用户 OpenID（当 need_openid=1 时返回）</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
}

