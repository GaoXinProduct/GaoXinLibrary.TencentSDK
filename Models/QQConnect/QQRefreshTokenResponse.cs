using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

#region 刷新 Access Token

/// <summary>
/// 刷新 Access Token 响应
/// <para>
/// 对应接口：GET https://graph.qq.com/oauth2.0/token<br/>
/// 参数 grant_type=refresh_token
/// </para>
/// </summary>
public class QQRefreshTokenResponse : QQBaseResponse
{
    /// <summary>授权令牌</summary>
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    /// <summary>access_token 的有效期（秒）</summary>
    [JsonPropertyName("expires_in")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int ExpiresIn { get; set; }

    /// <summary>用于刷新 access_token 的凭证</summary>
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
}

#endregion
