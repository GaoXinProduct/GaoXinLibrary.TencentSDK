using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号 JS-SDK 服务实现</summary>
public class OfficialJsSdkService
{
    private readonly JsApiTicketProvider _ticketProvider;
    private readonly WechatOptions _options;

    public OfficialJsSdkService(JsApiTicketProvider ticketProvider, WechatOptions options)
    {
        _ticketProvider = ticketProvider;
        _options = options;
    }

    /// <summary>
    /// 获取 jsapi_ticket（自动缓存，过期自动刷新）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<string> GetTicketAsync(CancellationToken ct = default)
        => _ticketProvider.GetTicketAsync(ct);

    /// <summary>使 jsapi_ticket 缓存失效（下次 GetTicketAsync 时自动重新获取）</summary>
    public void InvalidateTicketCache() => _ticketProvider.InvalidateCache();

    /// <summary>强制刷新 jsapi_ticket（立即请求新 Ticket 并更新缓存）</summary>
    public Task<string> RefreshTicketAsync(CancellationToken ct = default)
        => _ticketProvider.RefreshTicketAsync(ct);

    /// <summary>
    /// 手动设置 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    public void SetTicket(string ticket, TimeSpan? expiresIn = null)
        => _ticketProvider.SetTicket(ticket, expiresIn);

    /// <summary>
    /// 计算 JS-SDK 签名（用于 wx.config）
    /// </summary>
    /// <param name="ticket">jsapi_ticket</param>
    /// <param name="url">当前网页 URL（不含 # 及后面部分）</param>
    public JsSdkSignature CreateSignature(string ticket, string url)
    {
        var nonceStr = Guid.NewGuid().ToString("N");
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        var raw = $"jsapi_ticket={ticket}&noncestr={nonceStr}&timestamp={timestamp}&url={url}";
        var hash = SHA1.HashData(Encoding.UTF8.GetBytes(raw));
        var signature = Convert.ToHexString(hash).ToLowerInvariant();

        return new JsSdkSignature
        {
            AppId = _options.AppId,
            Timestamp = timestamp,
            NonceStr = nonceStr,
            Signature = signature
        };
    }
}
