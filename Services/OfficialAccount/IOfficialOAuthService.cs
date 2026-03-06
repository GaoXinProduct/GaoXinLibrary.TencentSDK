using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号网页授权服务接口
/// <para>
/// 微信公众号 OAuth2 授权流程：<br/>
/// 1. 调用 <see cref="BuildAuthUrl"/> 构造授权链接；<br/>
/// 2. 用户同意授权后，回调 redirect_uri 并携带 code；<br/>
/// 3. 使用 code 调用 <see cref="GetAccessTokenAsync"/> 换取 access_token；<br/>
/// 4. 若 scope 为 snsapi_userinfo，可调用 <see cref="GetUserInfoAsync"/> 获取用户信息。
/// </para>
/// </summary>
public interface IOfficialOAuthService
{
    /// <summary>
    /// 构造网页授权 URL
    /// </summary>
    /// <param name="redirectUri">授权后重定向的回调 URL</param>
    /// <param name="scope">授权作用域（snsapi_base / snsapi_userinfo）</param>
    /// <param name="state">自定义状态参数（最长 128 字节）</param>
    /// <returns>完整的授权跳转 URL</returns>
    string BuildAuthUrl(string redirectUri, string scope = OfficialOAuthScope.Base, string state = "");

    /// <summary>
    /// 通过 code 换取网页授权 access_token
    /// </summary>
    /// <param name="code">授权回调中的 code 参数</param>
    /// <param name="ct">取消令牌</param>
    Task<OAuthAccessTokenResponse> GetAccessTokenAsync(string code, CancellationToken ct = default);

    /// <summary>
    /// 刷新 access_token
    /// </summary>
    /// <param name="refreshToken">上次获取的 refresh_token</param>
    /// <param name="ct">取消令牌</param>
    Task<OAuthRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default);

    /// <summary>
    /// 拉取用户信息（需 scope 为 snsapi_userinfo）
    /// </summary>
    /// <param name="accessToken">网页授权 access_token</param>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="lang">语言（zh_CN/zh_TW/en），默认 zh_CN</param>
    /// <param name="ct">取消令牌</param>
    Task<OAuthUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, string lang = "zh_CN", CancellationToken ct = default);
}

