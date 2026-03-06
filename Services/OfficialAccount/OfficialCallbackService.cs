using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号消息回调服务实现</summary>
public class OfficialCallbackService : IOfficialCallbackService
{
    private readonly WechatCryptoHelper? _crypto;
    private readonly WechatHttpClient _http;
    private readonly string _token;

    public OfficialCallbackService(WechatHttpClient http, WechatOfficialOptions options)
    {
        _http = http;
        _token = options.CallbackToken ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            _crypto = new WechatCryptoHelper(options.CallbackToken, options.CallbackEncodingAesKey, options.AppId);
        }
    }

    /// <inheritdoc/>
    public string VerifyUrl(string signature, string timestamp, string nonce, string echoStr)
    {
        if (string.IsNullOrWhiteSpace(_token))
            throw new TencentException("回调功能未配置：请在 WechatOfficialOptions 中设置 CallbackToken");

        // 明文模式：token + timestamp + nonce 字典排序后拼接做 SHA1
        string[] arr = [_token, timestamp, nonce];
        Array.Sort(arr, StringComparer.Ordinal);
        var raw = string.Concat(arr);
        var hash = System.Security.Cryptography.SHA1.HashData(System.Text.Encoding.UTF8.GetBytes(raw));
        var computed = Convert.ToHexString(hash).ToLowerInvariant();

        if (!string.Equals(computed, signature, StringComparison.OrdinalIgnoreCase))
            throw new TencentException("回调 URL 验证失败：签名不匹配");

        return echoStr;
    }

    /// <inheritdoc/>
    public string VerifyUrlEncrypted(string msgSignature, string timestamp, string nonce, string echoStr)
    {
        EnsureCryptoConfigured();
        return _crypto!.VerifyUrl(msgSignature, timestamp, nonce, echoStr);
    }

    /// <inheritdoc/>
    public OfficialCallbackMessageBase ParseMessage(string postBody)
    {
        return OfficialCallbackMessageBase.FromXml(postBody);
    }

    /// <inheritdoc/>
    public OfficialCallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody)
    {
        EnsureCryptoConfigured();
        var decryptedXml = _crypto!.DecryptMessage(msgSignature, timestamp, nonce, postBody);
        return OfficialCallbackMessageBase.FromXml(decryptedXml);
    }

    /// <inheritdoc/>
    public string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null)
    {
        EnsureCryptoConfigured();
        timestamp ??= DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        nonce ??= Guid.NewGuid().ToString("N")[..16];
        return _crypto!.EncryptReply(replyXml, timestamp, nonce);
    }

    /// <inheritdoc/>
    public async Task<string[]> GetCallbackIpAsync(CancellationToken ct = default)
    {
        var response = await _http.GetAsync<GetCallbackIpResponse>("/cgi-bin/getcallbackip", ct: ct);
        return response.IpList ?? [];
    }

    private void EnsureCryptoConfigured()
    {
        if (_crypto is null)
            throw new TencentException("消息加解密未配置：请在 WechatOfficialOptions 中设置 CallbackToken 和 CallbackEncodingAesKey");
    }
}

