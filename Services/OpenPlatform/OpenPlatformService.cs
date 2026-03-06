using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OpenPlatform;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>微信开放平台网站应用登录服务实现</summary>
public class OpenPlatformService : IOpenPlatformService
{
    private readonly WechatHttpClient _http;
    private readonly string _appId;
    private readonly string _appSecret;
    private readonly string _baseUrl;

    public OpenPlatformService(WechatHttpClient http, WechatOptions options)
    {
        _http = http;
        _appId = options.AppId;
        _appSecret = options.AppSecret;
        _baseUrl = options.BaseUrl.TrimEnd('/');
    }

    /// <inheritdoc/>
    public string BuildAuthUrl(string redirectUri, string state = "")
    {
        var encodedUri = Uri.EscapeDataString(redirectUri);
        return $"{TencentConstants.OpenBaseUrl}/connect/qrconnect?appid={_appId}&redirect_uri={encodedUri}&response_type=code&scope=snsapi_login&state={Uri.EscapeDataString(state)}#wechat_redirect";
    }

    /// <inheritdoc/>
    public Task<OpenAccessTokenResponse> GetAccessTokenAsync(string code, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/oauth2/access_token?appid={Uri.EscapeDataString(_appId)}&secret={Uri.EscapeDataString(_appSecret)}&code={Uri.EscapeDataString(code)}&grant_type=authorization_code";
        return _http.GetWithoutTokenAsync<OpenAccessTokenResponse>(url, ct);
    }

    /// <inheritdoc/>
    public Task<OpenRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/oauth2/refresh_token?appid={Uri.EscapeDataString(_appId)}&grant_type=refresh_token&refresh_token={Uri.EscapeDataString(refreshToken)}";
        return _http.GetWithoutTokenAsync<OpenRefreshTokenResponse>(url, ct);
    }

    /// <inheritdoc/>
    public Task<OpenUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, string lang = "zh_CN", CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/userinfo?access_token={Uri.EscapeDataString(accessToken)}&openid={Uri.EscapeDataString(openId)}&lang={lang}";
        return _http.GetWithoutTokenAsync<OpenUserInfoResponse>(url, ct);
    }

    /// <inheritdoc/>
    public Task<CheckAccessTokenResponse> CheckAccessTokenAsync(string accessToken, string openId, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/auth?access_token={Uri.EscapeDataString(accessToken)}&openid={Uri.EscapeDataString(openId)}";
        return _http.GetWithoutTokenAsync<CheckAccessTokenResponse>(url, ct);
    }

    /// <inheritdoc/>
    public Task<GetPcOpenSdkTicketResponse> GetPcOpenSdkTicketAsync(CancellationToken ct = default)
        => _http.PostAsync<GetPcOpenSdkTicketResponse>(
            "/cgi-bin/pcopensdk/ticket",
            new GetPcOpenSdkTicketRequest(), ct);
}
