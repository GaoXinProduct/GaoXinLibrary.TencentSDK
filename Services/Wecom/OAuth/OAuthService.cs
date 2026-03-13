using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>网页授权登录服务实现</summary>
public class OAuthService : IOAuthService
{
    private readonly WecomHttpClient _http;
    private readonly WecomOptions _options;

    /// <summary>
    /// 初始化 <see cref="OAuthService"/>
    /// </summary>
    /// <param name="http">HTTP 封装客户端</param>
    /// <param name="options">企业微信配置</param>
    public OAuthService(WecomHttpClient http, WecomOptions options)
    {
        _http = http;
        _options = options;
    }

    /// <inheritdoc/>
    public string BuildAuthUrl(string redirectUri, int agentId = 0, string scope = OAuthScope.Base, string state = "")
    {
        var effectiveAgentId = agentId > 0 ? agentId : _options.AgentId;
        var encodedUri = Uri.EscapeDataString(redirectUri);
        var encodedState = Uri.EscapeDataString(state);
        return $"https://open.weixin.qq.com/connect/oauth2/authorize" +
               $"?appid={_options.CorpId}" +
               $"&redirect_uri={encodedUri}" +
               $"&response_type=code" +
               $"&scope={scope}" +
               $"&agentid={effectiveAgentId}" +
               $"&state={encodedState}" +
               $"#wechat_redirect";
    }

    /// <inheritdoc/>
    public string BuildWebLoginUrl(string redirectUri, int agentId = 0, string state = "", string loginType = "CorpApp")
    {
        var effectiveAgentId = agentId > 0 ? agentId : _options.AgentId;
        var encodedUri = Uri.EscapeDataString(redirectUri);
        var encodedState = Uri.EscapeDataString(state);
        return $"https://login.work.weixin.qq.com/wwlogin/sso/login" +
               $"?login_type={loginType}" +
               $"&appid={_options.CorpId}" +
               $"&agentid={effectiveAgentId}" +
               $"&redirect_uri={encodedUri}" +
               $"&state={encodedState}";
    }

    /// <inheritdoc/>
    public Task<OAuthUserInfoResponse> GetUserInfoAsync(string code, CancellationToken ct = default)
        => _http.GetAsync<OAuthUserInfoResponse>("/cgi-bin/auth/getuserinfo",
            new() { ["code"] = code }, ct);

    /// <inheritdoc/>
    public Task<WebLoginUserInfoResponse> GetWebLoginUserInfoAsync(string code, CancellationToken ct = default)
        => _http.GetAsync<WebLoginUserInfoResponse>("/cgi-bin/auth/getuserinfo",
            new() { ["code"] = code }, ct);

    /// <inheritdoc/>
    public Task<OAuthUserDetailResponse> GetUserDetailAsync(string userTicket, CancellationToken ct = default)
        => _http.PostAsync<OAuthUserDetailResponse>("/cgi-bin/auth/getuserdetail",
            new OAuthUserDetailRequest { UserTicket = userTicket }, ct);
}
