using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号 OAuth 服务实现</summary>
public class OfficialOAuthService
{
    private readonly WechatHttpClient _http;
    private readonly WechatOptions _options;

    public OfficialOAuthService(WechatHttpClient http, WechatOptions options)
    {
        _http = http;
        _options = options;
    }

    /// <summary>
    /// 构造网页授权 URL
    /// </summary>
    /// <param name="redirectUri">授权后重定向的回调 URL</param>
    /// <param name="scope">授权作用域（snsapi_base / snsapi_userinfo）</param>
    /// <param name="state">自定义状态参数（最长 128 字节）</param>
    /// <returns>完整的授权跳转 URL</returns>
    public string BuildAuthUrl(string redirectUri, string scope = OfficialOAuthScope.Base, string state = "")
    {
        var encodedUri = Uri.EscapeDataString(redirectUri);
        return $"{TencentConstants.OfficialOAuthBaseUrl}/connect/oauth2/authorize?appid={_options.AppId}&redirect_uri={encodedUri}&response_type=code&scope={scope}&state={Uri.EscapeDataString(state)}#wechat_redirect";
    }

    /// <summary>
    /// 通过 code 换取网页授权 access_token
    /// </summary>
    /// <param name="code">授权回调中的 code 参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<OAuthAccessTokenResponse> GetAccessTokenAsync(string code, CancellationToken ct = default)
    {
        var baseUrl = _options.BaseUrl.TrimEnd('/');
        var url = $"{baseUrl}/sns/oauth2/access_token?appid={Uri.EscapeDataString(_options.AppId)}&secret={Uri.EscapeDataString(_options.AppSecret)}&code={Uri.EscapeDataString(code)}&grant_type=authorization_code";
        return _http.GetWithoutTokenAsync<OAuthAccessTokenResponse>(url, ct);
    }

    /// <summary>
    /// 刷新 access_token
    /// </summary>
    /// <param name="refreshToken">上次获取的 refresh_token</param>
    /// <param name="ct">取消令牌</param>
    public Task<OAuthRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        var baseUrl = _options.BaseUrl.TrimEnd('/');
        var url = $"{baseUrl}/sns/oauth2/refresh_token?appid={Uri.EscapeDataString(_options.AppId)}&grant_type=refresh_token&refresh_token={Uri.EscapeDataString(refreshToken)}";
        return _http.GetWithoutTokenAsync<OAuthRefreshTokenResponse>(url, ct);
    }

    /// <summary>
    /// 拉取用户信息（需 scope 为 snsapi_userinfo）
    /// </summary>
    /// <param name="accessToken">网页授权 access_token</param>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="lang">语言（zh_CN/zh_TW/en），默认 zh_CN</param>
    /// <param name="ct">取消令牌</param>
    public Task<OAuthUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, string lang = "zh_CN", CancellationToken ct = default)
    {
        var baseUrl = _options.BaseUrl.TrimEnd('/');
        var url = $"{baseUrl}/sns/userinfo?access_token={Uri.EscapeDataString(accessToken)}&openid={Uri.EscapeDataString(openId)}&lang={lang}";
        return _http.GetWithoutTokenAsync<OAuthUserInfoResponse>(url, ct);
    }
}
