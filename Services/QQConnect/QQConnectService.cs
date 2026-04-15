using System.Text.Json;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>QQ 互联登录服务实现</summary>
public class QQConnectService
{
    private readonly HttpClient _httpClient;
    private readonly string _appId;
    private readonly string _appSecret;
    private readonly string _baseUrl;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public QQConnectService(HttpClient httpClient, QQConnectOptions options)
    {
        _httpClient = httpClient;
        _appId = options.AppId;
        _appSecret = options.AppSecret;
        _baseUrl = options.BaseUrl.TrimEnd('/');
    }

    /// <summary>
    /// 构造 QQ 登录授权页面 URL
    /// </summary>
    /// <param name="redirectUri">授权后重定向的回调 URL</param>
    /// <param name="state">自定义状态参数，防止 CSRF 攻击</param>
    /// <param name="scope">请求的权限范围，默认 get_user_info</param>
    /// <param name="display">PC 网页登录时为空，移动端可传 mobile</param>
    /// <returns>完整的授权页面 URL</returns>
    public string BuildAuthUrl(string redirectUri, string state = "", string scope = "get_user_info", string display = "")
    {
        var encodedUri = Uri.EscapeDataString(redirectUri);
        var url = $"{_baseUrl}/oauth2.0/authorize?response_type=code&client_id={Uri.EscapeDataString(_appId)}&redirect_uri={encodedUri}&scope={Uri.EscapeDataString(scope)}&state={Uri.EscapeDataString(state)}";
        if (!string.IsNullOrEmpty(display))
            url += $"&display={Uri.EscapeDataString(display)}";
        return url;
    }

    /// <summary>
    /// 使用 Authorization Code 获取 Access Token
    /// </summary>
    /// <param name="code">授权回调中的 code 参数</param>
    /// <param name="redirectUri">与请求授权时传入的 redirect_uri 一致</param>
    /// <param name="ct">取消令牌</param>
    public async Task<QQAccessTokenResponse> GetAccessTokenAsync(string code, string redirectUri, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/oauth2.0/token?grant_type=authorization_code&client_id={Uri.EscapeDataString(_appId)}&client_secret={Uri.EscapeDataString(_appSecret)}&code={Uri.EscapeDataString(code)}&redirect_uri={Uri.EscapeDataString(redirectUri)}&fmt=json&need_openid=1";
        return await GetQQResponseAsync<QQAccessTokenResponse>(url, ct);
    }

    /// <summary>
    /// 刷新 Access Token
    /// </summary>
    /// <param name="refreshToken">上次获取的 refresh_token</param>
    /// <param name="ct">取消令牌</param>
    public async Task<QQRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/oauth2.0/token?grant_type=refresh_token&client_id={Uri.EscapeDataString(_appId)}&client_secret={Uri.EscapeDataString(_appSecret)}&refresh_token={Uri.EscapeDataString(refreshToken)}&fmt=json";
        return await GetQQResponseAsync<QQRefreshTokenResponse>(url, ct);
    }

    /// <summary>
    /// 获取用户 OpenID
    /// </summary>
    /// <param name="accessToken">授权令牌</param>
    /// <param name="ct">取消令牌</param>
    public async Task<QQOpenIdResponse> GetOpenIdAsync(string accessToken, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/oauth2.0/me?access_token={Uri.EscapeDataString(accessToken)}&fmt=json";
        return await GetQQResponseAsync<QQOpenIdResponse>(url, ct);
    }

    /// <summary>
    /// 获取 QQ 用户信息
    /// </summary>
    /// <param name="accessToken">授权令牌</param>
    /// <param name="openId">用户 OpenID</param>
    /// <param name="ct">取消令牌</param>
    public async Task<QQUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/user/get_user_info?access_token={Uri.EscapeDataString(accessToken)}&oauth_consumer_key={Uri.EscapeDataString(_appId)}&openid={Uri.EscapeDataString(openId)}";
        var json = await _httpClient.GetStringAsync(url, ct);
        var result = JsonSerializer.Deserialize<QQUserInfoResponse>(json, JsonOptions)
                     ?? throw new TencentException("QQ API 响应反序列化失败");

        if (result.Ret != 0)
            throw new TencentException(result.Ret, result.Msg ?? "QQ OpenAPI 调用失败", "QQ 互联");

        return result;
    }

    private async Task<T> GetQQResponseAsync<T>(string url, CancellationToken ct) where T : QQBaseResponse
    {
        var json = await _httpClient.GetStringAsync(url, ct);
        var result = JsonSerializer.Deserialize<T>(json, JsonOptions)
                     ?? throw new TencentException("QQ API 响应反序列化失败");

        if (result.Error != 0)
            throw new TencentException(result.Error, result.ErrorDescription ?? "QQ OAuth 调用失败", "QQ 互联");

        return result;
    }
}
