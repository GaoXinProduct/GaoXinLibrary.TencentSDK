using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号 OAuth 服务实现</summary>
public class OfficialOAuthService : IOfficialOAuthService
{
    private readonly WechatHttpClient _http;
    private readonly WechatOptions _options;

    public OfficialOAuthService(WechatHttpClient http, WechatOptions options)
    {
        _http = http;
        _options = options;
    }

    /// <inheritdoc/>
    public string BuildAuthUrl(string redirectUri, string scope = OfficialOAuthScope.Base, string state = "")
    {
        var encodedUri = Uri.EscapeDataString(redirectUri);
        return $"{TencentConstants.OfficialOAuthBaseUrl}/connect/oauth2/authorize?appid={_options.AppId}&redirect_uri={encodedUri}&response_type=code&scope={scope}&state={Uri.EscapeDataString(state)}#wechat_redirect";
    }

    /// <inheritdoc/>
    public Task<OAuthAccessTokenResponse> GetAccessTokenAsync(string code, CancellationToken ct = default)
    {
        var baseUrl = _options.BaseUrl.TrimEnd('/');
        var url = $"{baseUrl}/sns/oauth2/access_token?appid={Uri.EscapeDataString(_options.AppId)}&secret={Uri.EscapeDataString(_options.AppSecret)}&code={Uri.EscapeDataString(code)}&grant_type=authorization_code";
        return _http.GetWithoutTokenAsync<OAuthAccessTokenResponse>(url, ct);
    }

    /// <inheritdoc/>
    public Task<OAuthRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        var baseUrl = _options.BaseUrl.TrimEnd('/');
        var url = $"{baseUrl}/sns/oauth2/refresh_token?appid={Uri.EscapeDataString(_options.AppId)}&grant_type=refresh_token&refresh_token={Uri.EscapeDataString(refreshToken)}";
        return _http.GetWithoutTokenAsync<OAuthRefreshTokenResponse>(url, ct);
    }

    /// <inheritdoc/>
    public Task<OAuthUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, string lang = "zh_CN", CancellationToken ct = default)
    {
        var baseUrl = _options.BaseUrl.TrimEnd('/');
        var url = $"{baseUrl}/sns/userinfo?access_token={Uri.EscapeDataString(accessToken)}&openid={Uri.EscapeDataString(openId)}&lang={lang}";
        return _http.GetWithoutTokenAsync<OAuthUserInfoResponse>(url, ct);
    }
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号菜单服务

