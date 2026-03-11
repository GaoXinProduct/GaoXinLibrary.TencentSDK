using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 企业微信 H5 / JS-SDK 服务接口
/// <para>
/// 提供企业微信 JS-SDK 所需的 jsapi_ticket 获取（含缓存/共享）、签名计算等功能，
/// 用于在企业微信 H5 页面中调用 JS-SDK 接口。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90506"/>
/// </para>
/// </summary>
public interface IJsSdkService
{
    // ─── 企业级 jsapi_ticket（用于 wx.config） ─────────────────────────────

    /// <summary>
    /// 获取企业的 jsapi_ticket（自动缓存，过期自动刷新）
    /// <para>一小时内，一个企业最多可获取400次，且单个应用不能超过100次。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>jsapi_ticket 字符串</returns>
    Task<string> GetJsApiTicketAsync(CancellationToken ct = default);

    /// <summary>使企业级 jsapi_ticket 缓存失效（下次 GetJsApiTicketAsync 时自动重新获取）</summary>
    void InvalidateJsApiTicketCache();

    /// <summary>强制刷新企业级 jsapi_ticket（立即请求新 Ticket 并更新缓存）</summary>
    Task<string> RefreshJsApiTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 手动设置企业级 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    void SetJsApiTicket(string ticket, TimeSpan? expiresIn = null);

    /// <summary>
    /// 获取当前企业级 jsapi_ticket 的共享加密形式（ChaCha20-Poly1305）
    /// <para>
    /// 用于主服务对外暴露 Ticket 共享接口，需在 Options 中配置 <c>JsApiTicketShareSecret</c>。
    /// </para>
    /// </summary>
    Task<SharedTokenResult> GetSharedJsApiTicketAsync(CancellationToken ct = default);

    // ─── 应用级 jsapi_ticket（用于 wx.agentConfig） ────────────────────────

    /// <summary>
    /// 获取应用的 jsapi_ticket（自动缓存，过期自动刷新，用于 agentConfig 注入）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>应用级别的 jsapi_ticket 字符串</returns>
    Task<string> GetAgentTicketAsync(CancellationToken ct = default);

    /// <summary>使应用级 jsapi_ticket 缓存失效（下次 GetAgentTicketAsync 时自动重新获取）</summary>
    void InvalidateAgentTicketCache();

    /// <summary>强制刷新应用级 jsapi_ticket（立即请求新 Ticket 并更新缓存）</summary>
    Task<string> RefreshAgentTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 手动设置应用级 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    void SetAgentTicket(string ticket, TimeSpan? expiresIn = null);

    /// <summary>
    /// 获取当前应用级 jsapi_ticket 的共享加密形式（ChaCha20-Poly1305）
    /// <para>
    /// 用于主服务对外暴露 Ticket 共享接口，需在 Options 中配置 <c>AgentTicketShareSecret</c>。
    /// </para>
    /// </summary>
    Task<SharedTokenResult> GetSharedAgentTicketAsync(CancellationToken ct = default);

    // ─── 签名计算 ─────────────────────────────────────────────────────────

    /// <summary>
    /// 计算企业级别的 JS-SDK 签名（用于 wx.config）
    /// </summary>
    /// <param name="ticket">通过 <see cref="GetJsApiTicketAsync"/> 获取的 jsapi_ticket</param>
    /// <param name="url">当前网页的完整 URL（不包含 # 及其后面部分）</param>
    /// <returns>签名结果</returns>
    JsSdkSignature CreateSignature(string ticket, string url);

    /// <summary>
    /// 计算应用级别的 JS-SDK 签名（用于 wx.agentConfig）
    /// </summary>
    /// <param name="ticket">通过 <see cref="GetAgentTicketAsync"/> 获取的应用 jsapi_ticket</param>
    /// <param name="url">当前网页的完整 URL（不包含 # 及其后面部分）</param>
    /// <returns>应用级别签名结果</returns>
    AgentJsSdkSignature CreateAgentSignature(string ticket, string url);
}
