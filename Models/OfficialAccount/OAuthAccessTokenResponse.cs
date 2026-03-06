using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 通过 code 换取网页授权 access_token 响应
/// （GET /sns/oauth2/access_token）
/// </summary>
public class OAuthAccessTokenResponse : WechatBaseResponse
{
    /// <summary>网页授权接口调用凭证</summary>
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    /// <summary>access_token 接口调用凭证超时时间（秒）</summary>
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }

    /// <summary>用户刷新 access_token 用的凭证</summary>
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }

    /// <summary>用户唯一标识</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>授权作用域</summary>
    [JsonPropertyName("scope")] public string? Scope { get; set; }

    /// <summary>当且仅当该公众号已绑定到微信开放平台时才有</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}

