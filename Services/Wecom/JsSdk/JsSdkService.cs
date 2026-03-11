using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业微信 H5 / JS-SDK 服务实现</summary>
public class JsSdkService : IJsSdkService
{
    private readonly WecomTicketProvider _jsApiTicketProvider;
    private readonly WecomTicketProvider _agentTicketProvider;
    private readonly string _corpId;
    private readonly int _agentId;

    public JsSdkService(
        WecomTicketProvider jsApiTicketProvider,
        WecomTicketProvider agentTicketProvider,
        string corpId,
        int agentId)
    {
        _jsApiTicketProvider = jsApiTicketProvider;
        _agentTicketProvider = agentTicketProvider;
        _corpId = corpId;
        _agentId = agentId;
    }

    // ─── 企业级 jsapi_ticket ──────────────────────────────────────────────

    /// <inheritdoc/>
    public Task<string> GetJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.GetTicketAsync(ct);

    /// <inheritdoc/>
    public void InvalidateJsApiTicketCache() => _jsApiTicketProvider.InvalidateCache();

    /// <inheritdoc/>
    public Task<string> RefreshJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.RefreshTicketAsync(ct);

    /// <inheritdoc/>
    public void SetJsApiTicket(string ticket, TimeSpan? expiresIn = null)
        => _jsApiTicketProvider.SetTicket(ticket, expiresIn);

    /// <inheritdoc/>
    public Task<SharedTokenResult> GetSharedJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.GetSharedTicketAsync(ct);

    // ─── 应用级 jsapi_ticket ──────────────────────────────────────────────

    /// <inheritdoc/>
    public Task<string> GetAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.GetTicketAsync(ct);

    /// <inheritdoc/>
    public void InvalidateAgentTicketCache() => _agentTicketProvider.InvalidateCache();

    /// <inheritdoc/>
    public Task<string> RefreshAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.RefreshTicketAsync(ct);

    /// <inheritdoc/>
    public void SetAgentTicket(string ticket, TimeSpan? expiresIn = null)
        => _agentTicketProvider.SetTicket(ticket, expiresIn);

    /// <inheritdoc/>
    public Task<SharedTokenResult> GetSharedAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.GetSharedTicketAsync(ct);

    // ─── 签名计算 ─────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public JsSdkSignature CreateSignature(string ticket, string url)
    {
        var nonceStr = GenerateNonceStr();
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var signature = ComputeSignature(ticket, nonceStr, timestamp, url);

        return new JsSdkSignature
        {
            CorpId = _corpId,
            Timestamp = timestamp,
            NonceStr = nonceStr,
            Signature = signature
        };
    }

    /// <inheritdoc/>
    public AgentJsSdkSignature CreateAgentSignature(string ticket, string url)
    {
        var nonceStr = GenerateNonceStr();
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var signature = ComputeSignature(ticket, nonceStr, timestamp, url);

        return new AgentJsSdkSignature
        {
            CorpId = _corpId,
            AgentId = _agentId,
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
}
