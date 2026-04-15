using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OpenPlatform;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>微信开放平台网站应用登录服务实现</summary>
public class OpenPlatformService
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

    /// <summary>
    /// 构造微信开放平台扫码登录 URL
    /// </summary>
    /// <param name="redirectUri">授权后重定向的回调 URL</param>
    /// <param name="state">自定义状态参数，防止 CSRF 攻击</param>
    /// <returns>完整的扫码登录 URL</returns>
    public string BuildAuthUrl(string redirectUri, string state = "")
    {
        var encodedUri = Uri.EscapeDataString(redirectUri);
        return $"{TencentConstants.OpenBaseUrl}/connect/qrconnect?appid={_appId}&redirect_uri={encodedUri}&response_type=code&scope=snsapi_login&state={Uri.EscapeDataString(state)}#wechat_redirect";
    }

    /// <summary>
    /// 通过 code 获取 access_token
    /// </summary>
    /// <param name="code">授权回调中的 code 参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<OpenAccessTokenResponse> GetAccessTokenAsync(string code, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/oauth2/access_token?appid={Uri.EscapeDataString(_appId)}&secret={Uri.EscapeDataString(_appSecret)}&code={Uri.EscapeDataString(code)}&grant_type=authorization_code";
        return _http.GetWithoutTokenAsync<OpenAccessTokenResponse>(url, ct);
    }

    /// <summary>
    /// 刷新 access_token
    /// </summary>
    /// <param name="refreshToken">上次获取的 refresh_token</param>
    /// <param name="ct">取消令牌</param>
    public Task<OpenRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/oauth2/refresh_token?appid={Uri.EscapeDataString(_appId)}&grant_type=refresh_token&refresh_token={Uri.EscapeDataString(refreshToken)}";
        return _http.GetWithoutTokenAsync<OpenRefreshTokenResponse>(url, ct);
    }

    /// <summary>
    /// 获取用户个人信息
    /// </summary>
    /// <param name="accessToken">网页授权 access_token</param>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="lang">语言（zh_CN/zh_TW/en），默认 zh_CN</param>
    /// <param name="ct">取消令牌</param>
    public Task<OpenUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, string lang = "zh_CN", CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/userinfo?access_token={Uri.EscapeDataString(accessToken)}&openid={Uri.EscapeDataString(openId)}&lang={lang}";
        return _http.GetWithoutTokenAsync<OpenUserInfoResponse>(url, ct);
    }

    /// <summary>
    /// 检验授权凭证是否有效
    /// </summary>
    /// <param name="accessToken">网页授权 access_token</param>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="ct">取消令牌</param>
    public Task<CheckAccessTokenResponse> CheckAccessTokenAsync(string accessToken, string openId, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/auth?access_token={Uri.EscapeDataString(accessToken)}&openid={Uri.EscapeDataString(openId)}";
        return _http.GetWithoutTokenAsync<CheckAccessTokenResponse>(url, ct);
    }

    /// <summary>
    /// 获取 PC OpenSDK ticket
    /// <para>
    /// 用于网站应用调用 PC 微信能力（如拉起/分享 PC 小程序、微信分享等）。<br/>
    /// ticket 5 分钟内有效，仅可调用一次网站应用接口。<br/>
    /// 调用前需先获取普通 access_token（通过 /cgi-bin/token 接口）。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<GetPcOpenSdkTicketResponse> GetPcOpenSdkTicketAsync(CancellationToken ct = default)
        => _http.PostAsync<GetPcOpenSdkTicketResponse>(
            "/cgi-bin/pcopensdk/ticket",
            new GetPcOpenSdkTicketRequest(), ct);
}
