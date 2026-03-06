using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 智能机器人服务接口
/// <para>
/// 智能机器人开启 API 模式后，用户与机器人交互时企业微信会向回调 URL 推送消息和事件。
/// 本服务提供回调验证、消息解密、被动回复加密及主动回复能力。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101039"/>
/// </para>
/// </summary>
public interface ISmartRobotService
{
    /// <summary>
    /// 验证回调 URL（GET 请求）
    /// <para>配置智能机器人回调 URL 时，企业微信会发送 GET 请求进行验证。</para>
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="echoStr">URL 参数 echostr（加密的随机字符串）</param>
    /// <returns>解密后的 echostr 明文（应直接写入 HTTP 响应）</returns>
    string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr);

    /// <summary>
    /// 解密并解析智能机器人回调的消息/事件
    /// <para>
    /// 接收消息参考：<see href="https://developer.work.weixin.qq.com/document/path/100719"/>
    /// 接收事件参考：<see href="https://developer.work.weixin.qq.com/document/path/101027"/>
    /// </para>
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="postBody">POST 请求体 XML 字符串</param>
    /// <returns>解析后的消息/事件对象</returns>
    CallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody);

    /// <summary>
    /// 加密被动回复消息
    /// <para>
    /// 将回复消息的 XML 明文加密并生成完整的回复 XML 信封，用于被动回复智能机器人消息。
    /// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101031"/>
    /// </para>
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文（通过 <see cref="CallbackReplyBuilder"/> 构建）</param>
    /// <param name="timestamp">时间戳（可使用当前时间戳）</param>
    /// <param name="nonce">随机字符串</param>
    /// <returns>加密后的完整回复 XML（直接写入 HTTP 响应）</returns>
    string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null);

    /// <summary>
    /// 主动回复消息（通过 API 接口发送消息）
    /// <para>
    /// 使用应用消息发送接口，向指定用户主动发送消息。
    /// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101138"/>
    /// </para>
    /// </summary>
    /// <param name="request">发送消息请求（与应用消息发送接口一致）</param>
    /// <param name="ct">取消令牌</param>
    Task SendMessageAsync(object request, CancellationToken ct = default);
}
