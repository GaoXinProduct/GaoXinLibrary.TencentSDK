using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OpenPlatform;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;


/// <summary>
/// 微信开放平台网站应用登录服务接口
/// <para>
/// 微信开放平台网站应用 OAuth2 登录流程：<br/>
/// 1. 调用 <see cref="BuildAuthUrl"/> 构造扫码登录链接；<br/>
/// 2. 用户扫码确认后，重定向至 redirect_uri 并携带 code；<br/>
/// 3. 使用 code 调用 <see cref="GetAccessTokenAsync"/> 换取 access_token；<br/>
/// 4. 使用 access_token 调用 <see cref="GetUserInfoAsync"/> 获取用户信息。
/// </para>
/// </summary>
public interface IOpenPlatformService
{
    /// <summary>
    /// 构造微信开放平台扫码登录 URL
    /// </summary>
    /// <param name="redirectUri">授权后重定向的回调 URL</param>
    /// <param name="state">自定义状态参数，防止 CSRF 攻击</param>
    /// <returns>完整的扫码登录 URL</returns>
    string BuildAuthUrl(string redirectUri, string state = "");

    /// <summary>
    /// 通过 code 获取 access_token
    /// </summary>
    /// <param name="code">授权回调中的 code 参数</param>
    /// <param name="ct">取消令牌</param>
    Task<OpenAccessTokenResponse> GetAccessTokenAsync(string code, CancellationToken ct = default);

    /// <summary>
    /// 刷新 access_token
    /// </summary>
    /// <param name="refreshToken">上次获取的 refresh_token</param>
    /// <param name="ct">取消令牌</param>
    Task<OpenRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default);

    /// <summary>
    /// 获取用户个人信息
    /// </summary>
    /// <param name="accessToken">网页授权 access_token</param>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="lang">语言（zh_CN/zh_TW/en），默认 zh_CN</param>
    /// <param name="ct">取消令牌</param>
    Task<OpenUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, string lang = "zh_CN", CancellationToken ct = default);

    /// <summary>
    /// 检验授权凭证是否有效
    /// </summary>
    /// <param name="accessToken">网页授权 access_token</param>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="ct">取消令牌</param>
    Task<CheckAccessTokenResponse> CheckAccessTokenAsync(string accessToken, string openId, CancellationToken ct = default);

    /// <summary>
    /// 获取 PC OpenSDK ticket
    /// <para>
    /// 用于网站应用调用 PC 微信能力（如拉起/分享 PC 小程序、微信分享等）。<br/>
    /// ticket 5 分钟内有效，仅可调用一次网站应用接口。<br/>
    /// 调用前需先获取普通 access_token（通过 /cgi-bin/token 接口）。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task<GetPcOpenSdkTicketResponse> GetPcOpenSdkTicketAsync(CancellationToken ct = default);
}
