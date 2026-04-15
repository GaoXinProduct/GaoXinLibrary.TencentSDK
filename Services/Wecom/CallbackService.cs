using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 应用接收消息与事件回调服务实现
/// </summary>
public class CallbackService
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

    /// <summary>
    /// 验证回调 URL（GET 请求）
    /// <para>
    /// 使用 msg_signature 和加密的 echostr 进行验证。
    /// </para>
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="echoStr">URL 参数 echostr（加密的随机字符串）</param>
    /// <returns>解密后的 echostr 明文（应直接写入 HTTP 响应）</returns>
    public string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr)
    {
        return _crypto.VerifyUrl(msgSignature, timestamp, nonce, echoStr);
    }

    /// <summary>
    /// 解密并解析回调 POST 请求体中的消息/事件
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="postBody">POST 请求体 XML 字符串（加密信封）</param>
    /// <returns>解析后的消息/事件对象（可根据 MsgType 和具体子类型进行类型转换）</returns>
    public CallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody)
    {
        var decryptedXml = _crypto.DecryptMessage(msgSignature, timestamp, nonce, postBody);
        return CallbackMessageBase.FromXml(decryptedXml);
    }

    /// <summary>
    /// 加密被动回复消息（安全模式）
    /// <para>将回复消息的 XML 明文加密并生成完整的回复 XML 信封。</para>
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文（通过 <see cref="CallbackReplyBuilder"/> 构建）</param>
    /// <param name="timestamp">时间戳（可使用当前时间戳）</param>
    /// <param name="nonce">随机字符串</param>
    /// <returns>加密后的完整回复 XML（直接写入 HTTP 响应）</returns>
    public string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null)
    {
        timestamp ??= DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        nonce ??= Guid.NewGuid().ToString("N")[..16];
        return _crypto.EncryptReply(replyXml, timestamp, nonce);
    }

    /// <summary>
    /// 获取企业微信服务器的 IP 地址段
    /// <para>可用于校验回调请求是否来自企业微信服务器。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>IP 地址段数组</returns>
    public async Task<string[]> GetCallbackIpAsync(CancellationToken ct = default)
    {
        var response = await _http.GetAsync<GetCallbackIpResponse>("/cgi-bin/getcallbackip", ct: ct);
        return response.IpList ?? [];
    }

    /// <summary>
    /// 获取企业微信接口 IP 段
    /// <para>可用于判断服务器出口 IP 是否在企业微信接口 IP 段内。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>接口 IP 地址段数组</returns>
    public async Task<string[]> GetApiDomainIpAsync(CancellationToken ct = default)
    {
        var response = await _http.GetAsync<GetCallbackIpResponse>("/cgi-bin/get_api_domain_ip", ct: ct);
        return response.IpList ?? [];
    }
}
