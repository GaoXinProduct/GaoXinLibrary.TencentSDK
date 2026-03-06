using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号 JS-SDK 服务实现</summary>
public class OfficialJsSdkService : IOfficialJsSdkService
{
    private readonly WechatHttpClient _http;
    private readonly string _appId;

    public OfficialJsSdkService(WechatHttpClient http, string appId)
    {
        _http = http;
        _appId = appId;
    }

    /// <inheritdoc/>
    public Task<GetJsApiTicketResponse> GetTicketAsync(CancellationToken ct = default)
        => _http.GetAsync<GetJsApiTicketResponse>("/cgi-bin/ticket/getticket",
            new Dictionary<string, string?> { ["type"] = "jsapi" }, ct);

    /// <inheritdoc/>
    public JsSdkSignature CreateSignature(string ticket, string url)
    {
        var nonceStr = Guid.NewGuid().ToString("N");
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        var raw = $"jsapi_ticket={ticket}&noncestr={nonceStr}&timestamp={timestamp}&url={url}";
        var hash = SHA1.HashData(Encoding.UTF8.GetBytes(raw));
        var signature = Convert.ToHexString(hash).ToLowerInvariant();

        return new JsSdkSignature
        {
            AppId = _appId,
            Timestamp = timestamp,
            NonceStr = nonceStr,
            Signature = signature
        };
    }
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号用户标签服务

