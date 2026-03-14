using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 智能机器人服务接口
/// <para>
/// 智能机器人开启 API 模式后，用户与机器人交互时企业微信会向回调 URL 推送消息和事件。
/// 本服务提供回调验证、消息解密、被动回复加密、主动回复以及智能表格自动化群聊管理能力。
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
    /// 支持解析的消息类型：text / image / voice / video / location / link / attachment。
    /// 支持解析的事件类型：enter_chat / subscribe / unsubscribe / click 等。
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
    /// 支持的回复类型：text / image / voice / video / news / markdown / template_card。
    /// 通过 <see cref="CallbackReplyBuilder"/> 构建回复 XML。
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
    /// <param name="request">发送消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>发送消息响应（包含 msgid 等信息）</returns>
    Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request, CancellationToken ct = default);

    // ─── 智能表格自动化创建的群聊 ─────────────────────────────────────────

    /// <summary>
    /// 获取智能表格自动化创建的群聊列表
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100989"/></para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<GetSmartSheetChatListResponse> GetSmartSheetChatListAsync(GetSmartSheetChatListRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取智能表格自动化创建的群聊会话详情
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101028"/></para>
    /// </summary>
    /// <param name="chatId">群聊 ID</param>
    /// <param name="ct">取消令牌</param>
    Task<GetSmartSheetChatResponse> GetSmartSheetChatAsync(string chatId, CancellationToken ct = default);

    /// <summary>
    /// 修改智能表格自动化创建的群聊会话
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101029"/></para>
    /// </summary>
    /// <param name="request">修改请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateSmartSheetChatAsync(UpdateSmartSheetChatRequest request, CancellationToken ct = default);
}
