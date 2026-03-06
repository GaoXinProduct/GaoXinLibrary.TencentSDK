using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 应用接收消息与事件回调服务接口
/// <para>
/// 处理企业微信回调 URL 验证、消息解密、事件解析、被动回复加密。<br/>
/// 支持明文模式和安全模式两种消息加密方式。<br/>
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90238"/>
/// </para>
/// </summary>
public interface ICallbackService
{
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
    string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr);

    /// <summary>
    /// 解密并解析回调 POST 请求体中的消息/事件
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="postBody">POST 请求体 XML 字符串（加密信封）</param>
    /// <returns>解析后的消息/事件对象（可根据 MsgType 和具体子类型进行类型转换）</returns>
    CallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody);

    /// <summary>
    /// 加密被动回复消息（安全模式）
    /// <para>将回复消息的 XML 明文加密并生成完整的回复 XML 信封。</para>
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文（通过 <see cref="CallbackReplyBuilder"/> 构建）</param>
    /// <param name="timestamp">时间戳（可使用当前时间戳）</param>
    /// <param name="nonce">随机字符串</param>
    /// <returns>加密后的完整回复 XML（直接写入 HTTP 响应）</returns>
    string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null);

    /// <summary>
    /// 获取企业微信服务器的 IP 地址段
    /// <para>可用于校验回调请求是否来自企业微信服务器。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>IP 地址段数组</returns>
    Task<string[]> GetCallbackIpAsync(CancellationToken ct = default);

    /// <summary>
    /// 获取企业微信接口 IP 段
    /// <para>可用于判断服务器出口 IP 是否在企业微信接口 IP 段内。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>接口 IP 地址段数组</returns>
    Task<string[]> GetApiDomainIpAsync(CancellationToken ct = default);
}
