using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>网页授权登录服务实现</summary>
public class OAuthService
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

    /// <summary>
    /// 构造网页授权 URL（适用于企业微信客户端内打开的页面）
    /// </summary>
    /// <param name="redirectUri">授权后重定向的回调 URL，需经过 UrlEncode 处理前的原始地址</param>
    /// <param name="agentId">
    /// 应用 AgentId；传 0 时使用构造服务时注入的默认 AgentId
    /// </param>
    /// <param name="scope">
    /// 授权作用域；使用 <see cref="OAuthScope.Base"/>（静默）或
    /// <see cref="OAuthScope.PrivateInfo"/>（手动授权获取敏感信息），默认静默授权
    /// </param>
    /// <param name="state">
    /// 自定义状态参数，用于防止 CSRF 攻击，建议使用随机字符串；最长128字节
    /// </param>
    /// <returns>完整的授权跳转 URL，在浏览器中打开以引导用户授权</returns>
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

    /// <summary>
    /// 构造企业微信 Web 登录 URL（适用于在外部浏览器中进行扫码 / 桌面端快捷登录）
    /// <para>
    /// 用户在浏览器中打开此链接后，可通过手机企业微信扫码或桌面端企业微信快速确认来完成登录。<br/>
    /// 登录成功后，企业微信会重定向到 <paramref name="redirectUri"/> 并附带 <c>code</c> 与 <c>state</c> 参数，
    /// 服务端再通过 <see cref="GetWebLoginUserInfoAsync"/> 换取用户登录身份。<br/>
    /// 参见：<see href="https://developer.work.weixin.qq.com/document/path/98151"/>
    /// </para>
    /// </summary>
    /// <param name="redirectUri">登录成功后的回调 URL（原始地址，无需预先 UrlEncode）</param>
    /// <param name="agentId">
    /// 应用 AgentId；传 0 时使用构造服务时注入的默认 AgentId
    /// </param>
    /// <param name="state">
    /// 自定义状态参数，用于防止 CSRF 攻击；最长128字节
    /// </param>
    /// <param name="loginType">
    /// 登录类型，默认 <c>CorpApp</c>（企业自建应用）
    /// </param>
    /// <returns>完整的 SSO 登录 URL，可直接在外部浏览器中打开或嵌入 Web 登录组件</returns>
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

    /// <summary>
    /// 根据 OAuth2 code 获取访问用户身份
    /// <para>
    /// 对应企业微信接口：GET /cgi-bin/auth/getuserinfo<br/>
    /// code 有效期为5分钟，且只能使用一次。
    /// </para>
    /// </summary>
    /// <param name="code">授权回调中携带的 code 参数</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>
    /// 用户身份信息；若为企业成员，返回 <see cref="OAuthUserInfoResponse.UserId"/>；
    /// 若 scope 为 snsapi_privateinfo，还会返回 <see cref="OAuthUserInfoResponse.UserTicket"/>
    /// </returns>
    public Task<OAuthUserInfoResponse> GetUserInfoAsync(string code, CancellationToken ct = default)
        => _http.GetAsync<OAuthUserInfoResponse>("/cgi-bin/auth/getuserinfo",
            new() { ["code"] = code }, ct);

    /// <summary>
    /// 根据 Web 登录回调 code 获取用户登录身份
    /// <para>
    /// 对应企业微信接口：GET /cgi-bin/auth/getuserinfo（Web 登录场景）<br/>
    /// 与 <see cref="GetUserInfoAsync"/> 使用相同接口地址，但返回字段不同：
    /// 仅返回 <c>userid</c>（企业成员）或 <c>openid</c> + <c>external_userid</c>（非企业成员），
    /// 不包含 <c>user_ticket</c>、<c>open_userid</c>、<c>deviceid</c> 等字段。<br/>
    /// 参见：<see href="https://developer.work.weixin.qq.com/document/path/98176"/>
    /// </para>
    /// </summary>
    /// <param name="code">Web 登录回调中携带的 code 参数</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>
    /// 用户登录身份；若为企业成员，返回 <see cref="WebLoginUserInfoResponse.UserId"/>；
    /// 若为非企业成员，返回 <see cref="WebLoginUserInfoResponse.OpenId"/> 和
    /// <see cref="WebLoginUserInfoResponse.ExternalUserId"/>
    /// </returns>
    public Task<WebLoginUserInfoResponse> GetWebLoginUserInfoAsync(string code, CancellationToken ct = default)
        => _http.GetAsync<WebLoginUserInfoResponse>("/cgi-bin/auth/getuserinfo",
            new() { ["code"] = code }, ct);

    /// <summary>
    /// 根据 user_ticket 获取用户敏感信息
    /// <para>
    /// 对应企业微信接口：POST /cgi-bin/auth/getuserdetail<br/>
    /// 仅当 scope 为 <see cref="OAuthScope.PrivateInfo"/> 时才能获取到 <c>user_ticket</c>，
    /// 有效期5分钟。
    /// </para>
    /// </summary>
    /// <param name="userTicket">由 <see cref="GetUserInfoAsync"/> 返回的 user_ticket</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>包含姓名、手机、邮箱、头像等敏感字段的用户详情</returns>
    public Task<OAuthUserDetailResponse> GetUserDetailAsync(string userTicket, CancellationToken ct = default)
        => _http.PostAsync<OAuthUserDetailResponse>("/cgi-bin/auth/getuserdetail",
            new OAuthUserDetailRequest { UserTicket = userTicket }, ct);
}
