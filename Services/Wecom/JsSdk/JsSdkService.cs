using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业微信 H5 / JS-SDK 服务实现</summary>
public class JsSdkService : IJsSdkService
{
    private readonly WecomHttpClient _http;
    private readonly string _corpId;
    private readonly int _agentId;

    public JsSdkService(WecomHttpClient http, string corpId, int agentId)
    {
        _http = http;
        _corpId = corpId;
        _agentId = agentId;
    }

    /// <inheritdoc/>
    public async Task<GetJsApiTicketResponse> GetJsApiTicketAsync(CancellationToken ct = default)
    {
        return await _http.GetAsync<GetJsApiTicketResponse>(
            "/cgi-bin/get_jsapi_ticket", ct: ct);
    }

    /// <inheritdoc/>
    public async Task<GetAgentTicketResponse> GetAgentTicketAsync(CancellationToken ct = default)
    {
        return await _http.GetAsync<GetAgentTicketResponse>(
            "/cgi-bin/ticket/get",
            new Dictionary<string, string?> { ["type"] = "agent_config" }, ct);
    }

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
