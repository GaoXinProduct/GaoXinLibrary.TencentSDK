using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号 JS-SDK 服务接口
/// <para>
/// 提供 JS-SDK 所需的 jsapi_ticket 获取（含缓存/共享）和签名计算功能。
/// </para>
/// </summary>
public interface IOfficialJsSdkService
{
    /// <summary>
    /// 获取 jsapi_ticket（自动缓存，过期自动刷新）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task<string> GetTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 计算 JS-SDK 签名（用于 wx.config）
    /// </summary>
    /// <param name="ticket">jsapi_ticket</param>
    /// <param name="url">当前网页 URL（不含 # 及后面部分）</param>
    JsSdkSignature CreateSignature(string ticket, string url);

    /// <summary>使 jsapi_ticket 缓存失效（下次 GetTicketAsync 时自动重新获取）</summary>
    void InvalidateTicketCache();

    /// <summary>强制刷新 jsapi_ticket（立即请求新 Ticket 并更新缓存）</summary>
    Task<string> RefreshTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 手动设置 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    void SetTicket(string ticket, TimeSpan? expiresIn = null);

    /// <summary>
    /// 获取当前 jsapi_ticket 的共享加密形式（ChaCha20-Poly1305）
    /// <para>
    /// 用于主服务对外暴露 Ticket 共享接口，需在 Options 中配置 <c>TicketShareSecret</c>。
    /// </para>
    /// </summary>
    Task<SharedTokenResult> GetSharedTicketAsync(CancellationToken ct = default);
}

