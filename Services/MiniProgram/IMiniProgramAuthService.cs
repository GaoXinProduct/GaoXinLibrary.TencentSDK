using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序登录服务接口
/// <para>
/// 提供小程序 code 换取 session 和获取手机号等登录相关功能。
/// </para>
/// </summary>
public interface IMiniProgramAuthService
{
    /// <summary>
    /// 登录凭证校验（auth.code2Session）
    /// <para>通过前端 wx.login 获取的 code 换取 openid、session_key 等信息。</para>
    /// </summary>
    /// <param name="jsCode">前端 wx.login 获取的临时登录凭证 code</param>
    /// <param name="ct">取消令牌</param>
    Task<Code2SessionResponse> Code2SessionAsync(string jsCode, CancellationToken ct = default);

    /// <summary>
    /// 获取手机号（phonenumber.getPhoneNumber）
    /// <para>通过前端 getPhoneNumber 组件获取的 code 换取用户手机号。</para>
    /// </summary>
    /// <param name="code">前端 getPhoneNumber 返回的 code</param>
    /// <param name="ct">取消令牌</param>
    Task<GetPhoneNumberResponse> GetPhoneNumberAsync(string code, CancellationToken ct = default);

    /// <summary>
    /// 校验 session_key 是否有效（GET /wxa/checksession）
    /// </summary>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="sessionKey">用户的 session_key</param>
    /// <param name="ct">取消令牌</param>
    Task<CheckSessionKeyResponse> CheckSessionKeyAsync(string openId, string sessionKey, CancellationToken ct = default);

    /// <summary>
    /// 重置 session_key（GET /wxa/resetusersessionkey）
    /// </summary>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="sessionKey">用户的 session_key</param>
    /// <param name="ct">取消令牌</param>
    Task<ResetUserSessionKeyResponse> ResetUserSessionKeyAsync(string openId, string sessionKey, CancellationToken ct = default);
}

