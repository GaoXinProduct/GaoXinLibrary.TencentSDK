using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 刷新 access_token 响应（GET /sns/oauth2/refresh_token）
/// </summary>
public class OAuthRefreshTokenResponse : WechatBaseResponse
{
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    [JsonPropertyName("scope")] public string? Scope { get; set; }
}

