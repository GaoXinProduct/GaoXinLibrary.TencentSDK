using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能机器人服务实现</summary>
public class SmartRobotService
{
    private readonly WecomCryptoHelper _crypto;
    private readonly WecomHttpClient _http;

    /// <summary>
    /// 初始化智能机器人服务
    /// </summary>
    /// <param name="http">企业微信 HTTP 客户端</param>
    /// <param name="options">企业微信智能机器人配置（需包含 CallbackToken 和 CallbackEncodingAesKey）</param>
    public SmartRobotService(WecomHttpClient http, WecomOptions options)
    {
        _http = http;

        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            _crypto = new WecomCryptoHelper(options.CallbackToken, options.CallbackEncodingAesKey, options.CorpId);
        }
        else
        {
            _crypto = null!;
        }
    }

    /// <summary>
    /// 验证回调 URL（GET 请求）
    /// <para>配置智能机器人回调 URL 时，企业微信会发送 GET 请求进行验证。</para>
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="echoStr">URL 参数 echostr（加密的随机字符串）</param>
    /// <returns>解密后的 echostr 明文（应直接写入 HTTP 响应）</returns>
    public string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr)
    {
        EnsureCryptoConfigured();
        return _crypto.VerifyUrl(msgSignature, timestamp, nonce, echoStr);
    }

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
    public CallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody)
    {
        EnsureCryptoConfigured();
        var decryptedXml = _crypto.DecryptMessage(msgSignature, timestamp, nonce, postBody);
        return CallbackMessageBase.FromXml(decryptedXml);
    }

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
    public string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null)
    {
        EnsureCryptoConfigured();
        timestamp ??= DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        nonce ??= Guid.NewGuid().ToString("N")[..16];
        return _crypto.EncryptReply(replyXml, timestamp, nonce);
    }

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
    public async Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<SendMessageResponse>("/cgi-bin/message/send", request, ct);
    }

    #region 智能表格自动化创建的群聊

    /// <summary>
    /// 获取智能表格自动化创建的群聊列表
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100989"/></para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public async Task<GetSmartSheetChatListResponse> GetSmartSheetChatListAsync(GetSmartSheetChatListRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetSmartSheetChatListResponse>("/cgi-bin/chatdata/list", request, ct);
    }

    /// <summary>
    /// 获取智能表格自动化创建的群聊会话详情
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101028"/></para>
    /// </summary>
    /// <param name="chatId">群聊 ID</param>
    /// <param name="ct">取消令牌</param>
    public async Task<GetSmartSheetChatResponse> GetSmartSheetChatAsync(string chatId, CancellationToken ct = default)
    {
        return await _http.GetAsync<GetSmartSheetChatResponse>("/cgi-bin/chatdata/get",
            new Dictionary<string, string?> { ["chatid"] = chatId }, ct);
    }

    /// <summary>
    /// 修改智能表格自动化创建的群聊会话
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101029"/></para>
    /// </summary>
    /// <param name="request">修改请求参数</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateSmartSheetChatAsync(UpdateSmartSheetChatRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>("/cgi-bin/chatdata/update", request, ct);
    }

    private void EnsureCryptoConfigured()
    {
        if (_crypto is null)
            throw new TencentException("智能机器人回调功能未配置：请在 WecomSmartBotOptions 中设置 CallbackToken 和 CallbackEncodingAesKey");
    }
    #endregion
}
