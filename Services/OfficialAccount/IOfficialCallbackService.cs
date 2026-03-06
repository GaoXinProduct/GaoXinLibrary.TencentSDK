using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号消息回调服务接口
/// <para>
/// 处理微信公众号回调 URL 验证、消息解密、事件解析、被动回复加密。<br/>
/// 支持明文模式、兼容模式和安全模式三种消息加密方式。<br/>
/// 参考文档：<see href="https://developers.weixin.qq.com/doc/offiaccount/Message_Management/Receiving_standard_messages.html"/>
/// </para>
/// </summary>
public interface IOfficialCallbackService
{
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
    string VerifyUrl(string signature, string timestamp, string nonce, string echoStr);

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
    string VerifyUrlEncrypted(string msgSignature, string timestamp, string nonce, string echoStr);

    /// <summary>
    /// 解析明文模式下的回调消息
    /// </summary>
    /// <param name="postBody">POST 请求体 XML 字符串（明文）</param>
    /// <returns>解析后的消息/事件对象</returns>
    OfficialCallbackMessageBase ParseMessage(string postBody);

    /// <summary>
    /// 解密并解析安全模式/兼容模式下的回调消息
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="postBody">POST 请求体 XML 字符串（加密信封）</param>
    /// <returns>解析后的消息/事件对象</returns>
    OfficialCallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody);

    /// <summary>
    /// 加密被动回复消息（安全模式/兼容模式）
    /// <para>将回复消息的 XML 明文加密并生成完整的回复 XML 信封。</para>
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文（通过 <see cref="OfficialCallbackReplyBuilder"/> 构建）</param>
    /// <param name="timestamp">时间戳（可使用当前时间戳）</param>
    /// <param name="nonce">随机字符串</param>
    /// <returns>加密后的完整回复 XML（直接写入 HTTP 响应）</returns>
    string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null);

    /// <summary>
    /// 获取微信服务器 IP 地址列表
    /// <para>可用于校验回调请求是否来自微信服务器。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>IP 地址列表</returns>
    Task<string[]> GetCallbackIpAsync(CancellationToken ct = default);
}

