using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业微信 H5 / JS-SDK 服务实现</summary>
public class JsSdkService
{
    private readonly WecomTicketProvider _jsApiTicketProvider;
    private readonly WecomTicketProvider _agentTicketProvider;
    private readonly WecomOptions _options;

    public JsSdkService(
        WecomTicketProvider jsApiTicketProvider,
        WecomTicketProvider agentTicketProvider,
        WecomOptions options)
    {
        _jsApiTicketProvider = jsApiTicketProvider;
        _agentTicketProvider = agentTicketProvider;
        _options = options;
    }

    #region 企业级 jsapi_ticket

    /// <summary>
    /// 获取企业的 jsapi_ticket（自动缓存，过期自动刷新）
    /// <para>一小时内，一个企业最多可获取400次，且单个应用不能超过100次。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>jsapi_ticket 字符串</returns>
    public Task<string> GetJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.GetTicketAsync(ct);

    /// <summary>使企业级 jsapi_ticket 缓存失效（下次 GetJsApiTicketAsync 时自动重新获取）</summary>
    public void InvalidateJsApiTicketCache() => _jsApiTicketProvider.InvalidateCache();

    /// <summary>强制刷新企业级 jsapi_ticket（立即请求新 Ticket 并更新缓存）</summary>
    public Task<string> RefreshJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.RefreshTicketAsync(ct);

    /// <summary>
    /// 手动设置企业级 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    public void SetJsApiTicket(string ticket, TimeSpan? expiresIn = null)
        => _jsApiTicketProvider.SetTicket(ticket, expiresIn);

    #endregion
    #region 应用级 jsapi_ticket

    /// <summary>
    /// 获取应用的 jsapi_ticket（自动缓存，过期自动刷新，用于 agentConfig 注入）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>应用级别的 jsapi_ticket 字符串</returns>
    public Task<string> GetAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.GetTicketAsync(ct);

    /// <summary>使应用级 jsapi_ticket 缓存失效（下次 GetAgentTicketAsync 时自动重新获取）</summary>
    public void InvalidateAgentTicketCache() => _agentTicketProvider.InvalidateCache();

    /// <summary>强制刷新应用级 jsapi_ticket（立即请求新 Ticket 并更新缓存）</summary>
    public Task<string> RefreshAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.RefreshTicketAsync(ct);

    /// <summary>
    /// 手动设置应用级 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    public void SetAgentTicket(string ticket, TimeSpan? expiresIn = null)
        => _agentTicketProvider.SetTicket(ticket, expiresIn);

    #endregion
    #region 签名计算

    /// <summary>
    /// 计算企业级别的 JS-SDK 签名（用于 wx.config）
    /// </summary>
    /// <param name="ticket">通过 <see cref="GetJsApiTicketAsync"/> 获取的 jsapi_ticket</param>
    /// <param name="url">当前网页的完整 URL（不包含 # 及其后面部分）</param>
    /// <returns>签名结果</returns>
    public JsSdkSignature CreateSignature(string ticket, string url)
    {
        var nonceStr = GenerateNonceStr();
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var signature = ComputeSignature(ticket, nonceStr, timestamp, url);

        return new JsSdkSignature
        {
            CorpId = _options.CorpId,
            Timestamp = timestamp,
            NonceStr = nonceStr,
            Signature = signature
        };
    }

    /// <summary>
    /// 计算应用级别的 JS-SDK 签名（用于 wx.agentConfig）
    /// </summary>
    /// <param name="ticket">通过 <see cref="GetAgentTicketAsync"/> 获取的应用 jsapi_ticket</param>
    /// <param name="url">当前网页的完整 URL（不包含 # 及其后面部分）</param>
    /// <returns>应用级别签名结果</returns>
    public AgentJsSdkSignature CreateAgentSignature(string ticket, string url)
    {
        var nonceStr = GenerateNonceStr();
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var signature = ComputeSignature(ticket, nonceStr, timestamp, url);

        return new AgentJsSdkSignature
        {
            CorpId = _options.CorpId,
            AgentId = _options.AgentId,
            Timestamp = timestamp,
            NonceStr = nonceStr,
            Signature = signature
        };
    }

    /// <summary>
    /// 按照企业微信 JS-SDK 签名算法计算签名
    /// <para>签名规则：将 jsapi_ticket、noncestr、timestamp、url 按 key 排序后拼接，再做 SHA1 散列</para>
    /// </summary>
    private static string ComputeSignature(string ticket, string nonceStr, long timestamp, string url)
    {
        var raw = $"jsapi_ticket={ticket}&noncestr={nonceStr}&timestamp={timestamp}&url={url}";
        var byteCount = Encoding.UTF8.GetByteCount(raw);
        Span<byte> utf8 = byteCount <= 512 ? stackalloc byte[byteCount] : new byte[byteCount];
        Encoding.UTF8.GetBytes(raw, utf8);
        Span<byte> hash = stackalloc byte[20];
        SHA1.HashData(utf8, hash);
        return HexHelper.ToLowerHex(hash);
    }

    private static string GenerateNonceStr()
        => Guid.NewGuid().ToString("N");
    #endregion
}
