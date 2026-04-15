using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号消息回调服务实现</summary>
public class OfficialCallbackService
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

    /// <summary>
    /// 验证回调 URL（GET 请求）— 明文模式
    /// <para>
    /// 微信在配置 URL 时会发送 GET 请求进行验证。<br/>
    /// 开发者通过校验 signature 验证请求来自微信服务器，并原样返回 echostr。
    /// </para>
    /// </summary>
    /// <param name="signature">URL 参数 signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="echoStr">URL 参数 echostr</param>
    /// <returns>验证通过时返回 echostr（应直接写入 HTTP 响应）</returns>
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

    /// <summary>
    /// 验证回调 URL（GET 请求）— 安全模式/兼容模式
    /// <para>
    /// 安全模式下使用 msg_signature 和加密的 echostr 进行验证。
    /// </para>
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="echoStr">URL 参数 echostr（加密字符串）</param>
    /// <returns>解密后的 echostr 明文</returns>
    public string VerifyUrlEncrypted(string msgSignature, string timestamp, string nonce, string echoStr)
    {
        EnsureCryptoConfigured();
        return _crypto!.VerifyUrl(msgSignature, timestamp, nonce, echoStr);
    }

    /// <summary>
    /// 解析明文模式下的回调消息
    /// </summary>
    /// <param name="postBody">POST 请求体 XML 字符串（明文）</param>
    /// <returns>解析后的消息/事件对象</returns>
    public OfficialCallbackMessageBase ParseMessage(string postBody)
    {
        return OfficialCallbackMessageBase.FromXml(postBody);
    }

    /// <summary>
    /// 解密并解析安全模式/兼容模式下的回调消息
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="postBody">POST 请求体 XML 字符串（加密信封）</param>
    /// <returns>解析后的消息/事件对象</returns>
    public OfficialCallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody)
    {
        EnsureCryptoConfigured();
        var decryptedXml = _crypto!.DecryptMessage(msgSignature, timestamp, nonce, postBody);
        return OfficialCallbackMessageBase.FromXml(decryptedXml);
    }

    /// <summary>
    /// 加密被动回复消息（安全模式/兼容模式）
    /// <para>将回复消息的 XML 明文加密并生成完整的回复 XML 信封。</para>
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文（通过 <see cref="OfficialCallbackReplyBuilder"/> 构建）</param>
    /// <param name="timestamp">时间戳（可使用当前时间戳）</param>
    /// <param name="nonce">随机字符串</param>
    /// <returns>加密后的完整回复 XML（直接写入 HTTP 响应）</returns>
    public string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null)
    {
        EnsureCryptoConfigured();
        timestamp ??= DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        nonce ??= Guid.NewGuid().ToString("N")[..16];
        return _crypto!.EncryptReply(replyXml, timestamp, nonce);
    }

    /// <summary>
    /// 获取微信服务器 IP 地址列表
    /// <para>可用于校验回调请求是否来自微信服务器。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>IP 地址列表</returns>
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

