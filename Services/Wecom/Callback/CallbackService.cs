using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 应用接收消息与事件回调服务实现
/// </summary>
public class CallbackService : ICallbackService
{
    private readonly WecomCryptoHelper _crypto;
    private readonly WecomHttpClient _http;

    /// <summary>
    /// 初始化回调服务
    /// </summary>
    /// <param name="http">企业微信 HTTP 客户端</param>
    /// <param name="options">企业微信配置（需包含 CallbackToken 和 CallbackEncodingAesKey）</param>
    public CallbackService(WecomHttpClient http, WecomOptions options)
    {
        _http = http;

        if (string.IsNullOrWhiteSpace(options.CallbackToken) ||
            string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            throw new TencentException("回调功能未配置：请在 WecomOptions 中设置 CallbackToken 和 CallbackEncodingAesKey");
        }

        _crypto = new WecomCryptoHelper(options.CallbackToken, options.CallbackEncodingAesKey, options.CorpId);
    }

    /// <inheritdoc/>
    public string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr)
    {
        return _crypto.VerifyUrl(msgSignature, timestamp, nonce, echoStr);
    }

    /// <inheritdoc/>
    public CallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody)
    {
        var decryptedXml = _crypto.DecryptMessage(msgSignature, timestamp, nonce, postBody);
        return CallbackMessageBase.FromXml(decryptedXml);
    }

    /// <inheritdoc/>
    public string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null)
    {
        timestamp ??= DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        nonce ??= Guid.NewGuid().ToString("N")[..16];
        return _crypto.EncryptReply(replyXml, timestamp, nonce);
    }

    /// <inheritdoc/>
    public async Task<string[]> GetCallbackIpAsync(CancellationToken ct = default)
    {
        var response = await _http.GetAsync<GetCallbackIpResponse>("/cgi-bin/getcallbackip", ct: ct);
        return response.IpList ?? [];
    }

    /// <inheritdoc/>
    public async Task<string[]> GetApiDomainIpAsync(CancellationToken ct = default)
    {
        var response = await _http.GetAsync<GetCallbackIpResponse>("/cgi-bin/get_api_domain_ip", ct: ct);
        return response.IpList ?? [];
    }
}
