using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;


/// <summary>
/// QQ 互联登录服务接口
/// <para>
/// QQ 互联 OAuth2.0 网站应用登录流程：<br/>
/// 1. 调用 <see cref="BuildAuthUrl"/> 构造用户授权页面 URL；<br/>
/// 2. 用户授权后，重定向至 redirect_uri 并携带 code；<br/>
/// 3. 使用 code 调用 <see cref="GetAccessTokenAsync"/> 换取 access_token；<br/>
/// 4. 使用 access_token 调用 <see cref="GetOpenIdAsync"/> 获取用户 OpenID；<br/>
/// 5. 使用 access_token + openid 调用 <see cref="GetUserInfoAsync"/> 获取用户信息。
/// </para>
/// </summary>
public interface IQQConnectService
{
    /// <summary>
    /// 构造 QQ 登录授权页面 URL
    /// </summary>
    /// <param name="redirectUri">授权后重定向的回调 URL</param>
    /// <param name="state">自定义状态参数，防止 CSRF 攻击</param>
    /// <param name="scope">请求的权限范围，默认 get_user_info</param>
    /// <param name="display">PC 网页登录时为空，移动端可传 mobile</param>
    /// <returns>完整的授权页面 URL</returns>
    string BuildAuthUrl(string redirectUri, string state = "", string scope = "get_user_info", string display = "");

    /// <summary>
    /// 使用 Authorization Code 获取 Access Token
    /// </summary>
    /// <param name="code">授权回调中的 code 参数</param>
    /// <param name="redirectUri">与请求授权时传入的 redirect_uri 一致</param>
    /// <param name="ct">取消令牌</param>
    Task<QQAccessTokenResponse> GetAccessTokenAsync(string code, string redirectUri, CancellationToken ct = default);

    /// <summary>
    /// 刷新 Access Token
    /// </summary>
    /// <param name="refreshToken">上次获取的 refresh_token</param>
    /// <param name="ct">取消令牌</param>
    Task<QQRefreshTokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken ct = default);

    /// <summary>
    /// 获取用户 OpenID
    /// </summary>
    /// <param name="accessToken">授权令牌</param>
    /// <param name="ct">取消令牌</param>
    Task<QQOpenIdResponse> GetOpenIdAsync(string accessToken, CancellationToken ct = default);

    /// <summary>
    /// 获取 QQ 用户信息
    /// </summary>
    /// <param name="accessToken">授权令牌</param>
    /// <param name="openId">用户 OpenID</param>
    /// <param name="ct">取消令牌</param>
    Task<QQUserInfoResponse> GetUserInfoAsync(string accessToken, string openId, CancellationToken ct = default);
}
