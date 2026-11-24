using System.Net.Http.Json;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能机器人服务实现</summary>
public sealed class SmartRobotService
{
    private const string ReplyHost = "qyapi.weixin.qq.com";
    private const string ReplyPath = "/cgi-bin/aibot/response";
    private const string ReplyQueryPrefix = "?response_code=";

    // 回调地址本身即为凭证，使用独立且禁止重定向的传输。
    private static readonly HttpClient ReplyHttpClient = new(new SocketsHttpHandler
    {
        AllowAutoRedirect = false,
        UseCookies = false,
        PooledConnectionLifetime = TimeSpan.FromMinutes(5)
    })
    {
        Timeout = Timeout.InfiniteTimeSpan
    };

    private readonly WecomCryptoHelper? _legacyCrypto;
    private readonly WecomCryptoHelper? _apiCrypto;
    private readonly WecomHttpClient _http;
    private readonly SmartSheetService _smartSheet;
    private readonly HttpClient _replyHttpClient;
    private readonly TimeSpan _replyTimeout;

    /// <summary>
    /// 初始化智能机器人服务
    /// </summary>
    /// <param name="http">企业微信 HTTP 客户端</param>
    /// <param name="options">企业微信智能机器人配置（需包含 CallbackToken 和 CallbackEncodingAesKey）</param>
    public SmartRobotService(WecomHttpClient http, WecomOptions options)
        : this(http, options, ReplyHttpClient) { }

    internal SmartRobotService(WecomHttpClient http, WecomOptions options, HttpClient replyHttpClient)
    {
        _http = http;
        _smartSheet = new SmartSheetService(http);
        _replyHttpClient = replyHttpClient;
        _replyTimeout = options.HttpTimeout;

        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            _apiCrypto = WecomCryptoHelper.CreateForSmartRobot(options.CallbackToken, options.CallbackEncodingAesKey);
            if (!string.IsNullOrWhiteSpace(options.CorpId))
                _legacyCrypto = new WecomCryptoHelper(options.CallbackToken, options.CallbackEncodingAesKey, options.CorpId);
        }
    }

    /// <summary>
    /// 验证使用企业 CorpId 作为接收方标识的旧版回调 URL（GET 请求）。
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="echoStr">URL 参数 echostr（加密的随机字符串）</param>
    /// <returns>解密后的 echostr 明文（应直接写入 HTTP 响应）</returns>
    public string VerifyUrl(string msgSignature, string timestamp, string nonce, string echoStr)
        => GetConfiguredCrypto(_legacyCrypto).VerifyUrl(msgSignature, timestamp, nonce, echoStr);

    /// <summary>验证企业自建智能机器人的 API 模式回调 URL。成功时返回 echostr 明文。</summary>
    public string VerifyApiCallbackUrl(string msgSignature, string timestamp, string nonce, string echoStr)
        => GetConfiguredCrypto(_apiCrypto).VerifyUrl(msgSignature, timestamp, nonce, echoStr);

    /// <summary>
    /// 验签、解密并解析企业自建智能机器人的 JSON 回调。参考
    /// <see href="https://developer.work.weixin.qq.com/document/path/101033"/>。
    /// </summary>
    public SmartRobotApiCallback DecryptApiCallback(string msgSignature, string timestamp, string nonce, string postBody)
    {
        var crypto = GetConfiguredCrypto(_apiCrypto);
        using var envelope = JsonDocument.Parse(postBody);
        if (envelope.RootElement.ValueKind != JsonValueKind.Object ||
            !envelope.RootElement.TryGetProperty("encrypt", out var encrypted) ||
            encrypted.ValueKind != JsonValueKind.String ||
            encrypted.GetString() is not { Length: > 0 } ciphertext)
        {
            throw new TencentException("智能机器人回调缺少 encrypt 字段");
        }

        if (!crypto.VerifySignature(msgSignature, timestamp, nonce, ciphertext))
            throw new TencentException("智能机器人回调签名不匹配");

        return JsonSerializer.Deserialize<SmartRobotApiCallback>(crypto.Decrypt(ciphertext), WecomHttpClient.JsonOptions)
               ?? throw new TencentException("智能机器人回调正文为空");
    }

    /// <summary>
    /// 解密并解析旧版 XML 回调消息或事件。
    /// <para>
    /// 支持解析的消息类型：text / image / voice / video / location / link / attachment。
    /// 支持解析的事件类型：enter_chat / subscribe / unsubscribe / click 等。
    /// 企业自建智能机器人的 JSON 回调使用 <see cref="DecryptApiCallback"/>。
    /// </para>
    /// </summary>
    /// <param name="msgSignature">URL 参数 msg_signature</param>
    /// <param name="timestamp">URL 参数 timestamp</param>
    /// <param name="nonce">URL 参数 nonce</param>
    /// <param name="postBody">POST 请求体 XML 字符串</param>
    /// <returns>解析后的消息/事件对象</returns>
    public CallbackMessageBase DecryptAndParse(string msgSignature, string timestamp, string nonce, string postBody)
    {
        var decryptedXml = GetConfiguredCrypto(_legacyCrypto).DecryptMessage(msgSignature, timestamp, nonce, postBody);
        return CallbackMessageBase.FromXml(decryptedXml);
    }

    /// <summary>
    /// 加密旧版 XML 被动回复消息。
    /// <para>
    /// 将回复消息的 XML 明文加密并生成对应的 XML 信封。
    /// 支持的回复类型：text / image / voice / video / news / markdown / template_card。
    /// 通过 <see cref="CallbackReplyBuilder"/> 构建回复 XML。
    /// </para>
    /// </summary>
    /// <param name="replyXml">回复消息的 XML 明文（通过 <see cref="CallbackReplyBuilder"/> 构建）</param>
    /// <param name="timestamp">时间戳（可使用当前时间戳）</param>
    /// <param name="nonce">随机字符串</param>
    /// <returns>加密后的完整回复 XML（直接写入 HTTP 响应）</returns>
    public string EncryptReply(string replyXml, string? timestamp = null, string? nonce = null)
    {
        var crypto = GetConfiguredCrypto(_legacyCrypto);
        timestamp ??= DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        nonce ??= Guid.NewGuid().ToString("N")[..16];
        return crypto.EncryptReply(replyXml, timestamp, nonce);
    }

    /// <summary>
    /// 使用自建应用向指定用户发送应用消息。回复智能机器人回调请使用 <see cref="ReplyAsync"/>。
    /// </summary>
    /// <param name="request">发送消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>发送消息响应（包含 msgid 等信息）</returns>
    public Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SendMessageResponse>("/cgi-bin/message/send", request, ct);

    /// <summary>
    /// 使用回调的 response_url 主动回复一次。企业微信规定地址仅可用一次，且一小时内有效。
    /// 参考 <see href="https://developer.work.weixin.qq.com/document/path/101138"/>。
    /// </summary>
    public async Task ReplyAsync(string responseUrl, SmartRobotReplyRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var uri = GetReplyUri(responseUrl);
        ValidateReply(request);

        using var timeout = CancellationTokenSource.CreateLinkedTokenSource(ct);
        timeout.CancelAfter(_replyTimeout);
        using var content = JsonContent.Create(request, options: WecomHttpClient.JsonOptions);
        using var response = await _replyHttpClient.PostAsync(uri, content, timeout.Token).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<WecomBaseResponse>(WecomHttpClient.JsonOptions, timeout.Token).ConfigureAwait(false)
                     ?? throw new TencentException("智能机器人回复响应为空");
        if (result.ErrCode != 0)
            throw new TencentException(result.ErrCode, result.ErrMsg ?? "未知错误", "企业微信");
    }

    private static Uri GetReplyUri(string responseUrl)
    {
        if (Uri.TryCreate(responseUrl, UriKind.Absolute, out var uri) &&
            uri.Scheme == Uri.UriSchemeHttps &&
            uri.IsDefaultPort &&
            string.Equals(uri.IdnHost, ReplyHost, StringComparison.OrdinalIgnoreCase) &&
            uri.AbsolutePath == ReplyPath &&
            uri.UserInfo.Length == 0 &&
            uri.Fragment.Length == 0 &&
            uri.Query.StartsWith(ReplyQueryPrefix, StringComparison.Ordinal) &&
            uri.Query.Length > ReplyQueryPrefix.Length &&
            !uri.Query.Contains('&') &&
            !uri.Query.Contains(';'))
        {
            return uri;
        }

        throw new ArgumentException("请使用企业微信智能机器人回调提供的 response_url。", nameof(responseUrl));
    }

    private static void ValidateReply(SmartRobotReplyRequest request)
    {
        if (request is { MsgType: "markdown", Markdown: { } markdown, TemplateCard: null })
        {
            ArgumentException.ThrowIfNullOrEmpty(markdown.Content, nameof(markdown.Content));
            if (Encoding.UTF8.GetByteCount(markdown.Content) > 20480)
                throw new ArgumentException("Markdown 回复内容不能超过 20480 字节。", nameof(request));
            if (markdown.Feedback?.Id is { } feedbackId && Encoding.UTF8.GetByteCount(feedbackId) > 256)
                throw new ArgumentException("反馈 ID 不能超过 256 字节。", nameof(request));
            return;
        }

        if (request is { MsgType: "template_card", Markdown: null, TemplateCard.ValueKind: JsonValueKind.Object })
            return;

        throw new ArgumentException("请提供与 MsgType 匹配的 Markdown 或模板卡片内容。", nameof(request));
    }

    #region 智能表格自动化创建的群聊

    /// <summary>
    /// 获取智能表格自动化创建的群聊列表
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100989"/></para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetSmartSheetChatListResponse> GetSmartSheetChatListAsync(GetSmartSheetChatListRequest request, CancellationToken ct = default)
        => _smartSheet.GetSmartSheetChatListAsync(request, ct);

    /// <summary>
    /// 获取智能表格自动化创建的群聊会话详情
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101028"/></para>
    /// </summary>
    /// <param name="chatId">群聊 ID</param>
    /// <param name="ct">取消令牌</param>
    [Obsolete("官方接口需要 DocId 与 ChatId，请使用接收 GetSmartSheetChatRequest 的重载。")]
    public Task<GetSmartSheetChatResponse> GetSmartSheetChatAsync(string chatId, CancellationToken ct = default)
        => Task.FromException<GetSmartSheetChatResponse>(
            new NotSupportedException("查询智能表格群聊需要文档 ID 与群聊 ID。"));

    /// <summary>按文档 ID 和群聊 ID 查询智能表格自动化群聊。</summary>
    public Task<GetSmartSheetChatResponse> GetSmartSheetChatAsync(GetSmartSheetChatRequest request, CancellationToken ct = default)
        => _smartSheet.GetSmartSheetChatAsync(request, ct);

    /// <summary>
    /// 修改智能表格自动化创建的群聊会话
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101029"/></para>
    /// </summary>
    /// <param name="request">修改请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task UpdateSmartSheetChatAsync(UpdateSmartSheetChatRequest request, CancellationToken ct = default)
        => _smartSheet.UpdateSmartSheetChatAsync(request, ct);
    #endregion

    private static WecomCryptoHelper GetConfiguredCrypto(WecomCryptoHelper? crypto)
        => crypto ?? throw new TencentException("智能机器人回调功能未配置：请在 WecomSmartBotOptions 中设置 CallbackToken 和 CallbackEncodingAesKey");
}
