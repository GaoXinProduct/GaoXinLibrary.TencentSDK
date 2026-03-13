using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Wecom;

/// <summary>
/// 企业微信服务端 SDK 主客户端
/// </summary>
/// <remarks>
/// 通过 <see cref="Create(WecomOptions)"/> 或 <see cref="Create(WecomOptions, HttpClient)"/> 工厂方法创建实例；
/// 使用完毕后请调用 <see cref="Dispose"/> 或通过 <c>using</c> 语句释放资源。
/// <para>
/// 快速入门：
/// <code>
/// using var client = WecomClient.Create(new WecomOptions
/// {
///     CorpId     = "your_corpid",
///     CorpSecret = "your_corpsecret",
///     AgentId    = 1000001
/// });
/// await client.Message.SendTextAsync("Hello!", toUser: "@all");
/// </code>
/// </para>
/// </remarks>
public sealed class WecomClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly AccessTokenProvider _tokenProvider;
    private readonly WecomHttpClient _http;
    private readonly WecomTicketProvider _jsApiTicketProvider;
    private readonly WecomTicketProvider _agentTicketProvider;

    // ─── 子服务 ──────────────────────────────────────────────────────────────

    /// <summary>成员管理</summary>
    public IUserService User { get; }

    /// <summary>部门管理</summary>
    public IDepartmentService Department { get; }

    /// <summary>标签管理</summary>
    public ITagService Tag { get; }

    /// <summary>应用消息发送</summary>
    public IMessageService Message { get; }

    /// <summary>群机器人消息推送</summary>
    public IWebhookService Webhook { get; }

    /// <summary>应用管理（查询/配置自建应用及自定义菜单）</summary>
    public IAgentService Agent { get; }

    /// <summary>素材管理</summary>
    public IMediaService Media { get; }

    /// <summary>应用群聊会话管理</summary>
    public IGroupChatService GroupChat { get; }

    /// <summary>自定义菜单管理</summary>
    /// <remarks>与 <see cref="Agent"/> 共用同一 <c>AgentService</c> 实例。</remarks>
    public IMenuService Menu { get; }

    /// <summary>网页授权登录（OAuth2）</summary>
    public IOAuthService OAuth { get; }

    /// <summary>应用接收消息与事件回调</summary>
    public ICallbackService Callback { get; }

    /// <summary>智能机器人</summary>
    public ISmartRobotService SmartRobot { get; }

    /// <summary>企业互联</summary>
    public ICorpGroupService CorpGroup { get; }

    /// <summary>上下游/互联企业</summary>
    public ILinkedCorpService LinkedCorp { get; }

    /// <summary>微信客服</summary>
    public IKfService Kf { get; }

    /// <summary>会话内容存档</summary>
    public IMsgAuditService MsgAudit { get; }

    /// <summary>企业微信 H5 / JS-SDK</summary>
    public IJsSdkService JsSdk { get; }

    /// <summary>打卡</summary>
    public ICheckinService Checkin { get; }

    /// <summary>审批</summary>
    public IApprovalService Approval { get; }

    /// <summary>异步导出</summary>
    public IExportService Export { get; }

    /// <summary>异步导入</summary>
    public IAsyncImportService AsyncImport { get; }

    /// <summary>二次验证</summary>
    public ISecondVerifyService SecondVerify { get; }

    /// <summary>安全管理</summary>
    public ISecurityService Security { get; }

    /// <summary>高级功能账号管理</summary>
    public IAdvancedAccountService AdvancedAccount { get; }

    /// <summary>操作日志</summary>
    public IOperationLogService OperationLog { get; }

    /// <summary>账号ID管理</summary>
    public IAccountIdService AccountId { get; }

    /// <summary>IP段查询</summary>
    public IIpRangeService IpRange { get; }

    /// <summary>客户联系</summary>
    public IExternalContactService ExternalContact { get; }

    /// <summary>企业支付</summary>
    public ICorpPayService CorpPay { get; }

    /// <summary>邮件</summary>
    public IEmailService Email { get; }

    /// <summary>文档</summary>
    public IDocumentService Document { get; }

    /// <summary>日程</summary>
    public ICalendarService Calendar { get; }

    /// <summary>会议</summary>
    public IMeetingService Meeting { get; }

    /// <summary>微盘</summary>
    public IWedriveService Wedrive { get; }

    /// <summary>直播</summary>
    public ILivingService Living { get; }

    /// <summary>公费电话</summary>
    public IDialService Dial { get; }

    /// <summary>汇报</summary>
    public IReportService Report { get; }

    /// <summary>人事助手</summary>
    public IHrService Hr { get; }

    /// <summary>会议室</summary>
    public IMeetingRoomService MeetingRoom { get; }

    /// <summary>电子发票</summary>
    public IInvoiceService Invoice { get; }

    /// <summary>智能表格</summary>
    public ISmartSheetService SmartSheet { get; }

    /// <summary>收集表</summary>
    public ICollectFormService CollectForm { get; }

    /// <summary>当前配置</summary>
    public WecomOptions Options { get; }

    // ─── 构造 ─────────────────────────────────────────────────────────────────

    private WecomClient(WecomOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        Options = options;
        _httpClient = httpClient;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        _http = new WecomHttpClient(httpClient, _tokenProvider, options, logger);

        User = new UserService(_http);
        Department = new DepartmentService(_http);
        Tag = new TagService(_http);
        Message = new MessageService(_http, options.AgentId);
        Webhook = new WebhookService(_http, options.BaseUrl);
        var agentSvc = new AgentService(_http, options);
        Agent = agentSvc;
        Menu = agentSvc;
        Media = new MediaService(_http, _tokenProvider, httpClient, options.BaseUrl);
        GroupChat = new GroupChatService(_http);
        OAuth = new OAuthService(_http, options.CorpId, options.AgentId);
        Callback = new CallbackService(_http, options);
        SmartRobot = new SmartRobotService(_http, options);
        CorpGroup = new CorpGroupService(_http);
        LinkedCorp = new LinkedCorpService(_http);
        Kf = new KfService(_http);
        MsgAudit = new MsgAuditService(_http, options);
        _jsApiTicketProvider = new WecomTicketProvider(
            async ct =>
            {
                var resp = await _http.GetAsync<GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk.GetJsApiTicketResponse>(
                    "/cgi-bin/get_jsapi_ticket", ct: ct);
                return (resp.Ticket, resp.ExpiresIn);
            },
            httpClient);
        _jsApiTicketProvider.ConfigureSharedTicket(options.JsApiTicketShareSecret, options.JsApiTicketShareUrl);
        _jsApiTicketProvider.OnTicketChanged = options.OnJsApiTicketChanged;

        _agentTicketProvider = new WecomTicketProvider(
            async ct =>
            {
                var resp = await _http.GetAsync<GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk.GetAgentTicketResponse>(
                    "/cgi-bin/ticket/get",
                    new Dictionary<string, string?> { ["type"] = "agent_config" }, ct);
                return (resp.Ticket, resp.ExpiresIn);
            },
            httpClient);
        _agentTicketProvider.ConfigureSharedTicket(options.AgentTicketShareSecret, options.AgentTicketShareUrl);
        _agentTicketProvider.OnTicketChanged = options.OnAgentTicketChanged;

        JsSdk = new JsSdkService(_jsApiTicketProvider, _agentTicketProvider, options.CorpId, options.AgentId);
        Checkin = new CheckinService(_http);
        Approval = new ApprovalService(_http);
        Export = new ExportService(_http);
        AsyncImport = new AsyncImportService(_http);
        SecondVerify = new SecondVerifyService(_http);
        Security = new SecurityService(_http);
        AdvancedAccount = new AdvancedAccountService(_http);
        OperationLog = new OperationLogService(_http);
        AccountId = new AccountIdService(_http);
        IpRange = new IpRangeService(_http);
        ExternalContact = new ExternalContactService(_http);
        CorpPay = new CorpPayService(_http);
        Email = new EmailService(_http);
        Document = new DocumentService(_http);
        Calendar = new CalendarService(_http);
        Meeting = new MeetingService(_http);
        Wedrive = new WedriveService(_http);
        Living = new LivingService(_http);
        Dial = new DialService(_http);
        Report = new ReportService(_http);
        Hr = new HrService(_http);
        MeetingRoom = new MeetingRoomService(_http);
        Invoice = new InvoiceService(_http);
        SmartSheet = new SmartSheetService(_http);
        CollectForm = new CollectFormService(_http);
    }

    /// <summary>
    /// 使用指定配置创建 <see cref="WecomClient"/> 实例（内部自动创建 <see cref="HttpClient"/>）
    /// </summary>
    /// <param name="options">企业微信配置，必须包含 <see cref="WecomOptions.CorpId"/> 和 <see cref="WecomOptions.CorpSecret"/>。</param>
    /// <returns>已初始化的 <see cref="WecomClient"/> 实例。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> 为 <c>null</c>。</exception>
    /// <exception cref="ArgumentException"><see cref="WecomOptions.CorpId"/> 或 <see cref="WecomOptions.CorpSecret"/> 为空。</exception>
    public static WecomClient Create(WecomOptions options, ILogger? logger = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.CorpId)) throw new ArgumentException("CorpId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.CorpSecret) &&
            (string.IsNullOrWhiteSpace(options.ShareSecret) || string.IsNullOrWhiteSpace(options.TokenShareUrl)))
        {
            throw new ArgumentException("CorpSecret 不能为空，或者需要同时配置 ShareSecret 和 TokenShareUrl", nameof(options));
        }

        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WecomClient(options, httpClient, logger);
    }

    /// <summary>
    /// 使用已有 <see cref="HttpClient"/> 创建 <see cref="WecomClient"/> 实例
    /// </summary>
    /// <param name="options">企业微信配置。</param>
    /// <param name="httpClient">外部托管的 <see cref="HttpClient"/>，可注入自定义 <see cref="System.Net.Http.DelegatingHandler"/>（如日志、重试）。</param>
    /// <returns>已初始化的 <see cref="WecomClient"/> 实例。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> 或 <paramref name="httpClient"/> 为 <c>null</c>。</exception>
    public static WecomClient Create(WecomOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WecomClient(options, httpClient, logger);
    }

    /// <summary>
    /// 使 access_token 缓存失效
    /// </summary>
    /// <remarks>下次调用 <see cref="GetAccessTokenAsync"/> 时将自动向企业微信重新申请 Token。</remarks>
    public void InvalidateAccessTokenCache() => _tokenProvider.InvalidateCache();

    /// <summary>
    /// 强制刷新 access_token（立即向企业微信请求新 Token 并更新本地缓存）
    /// </summary>
    /// <param name="ct">取消令牌。</param>
    /// <returns>最新的 access_token 字符串。</returns>
    public Task<string> RefreshAccessTokenAsync(CancellationToken ct = default)
        => _tokenProvider.RefreshTokenAsync(ct);

    /// <summary>
    /// 手动写入 access_token（适用于从外部令牌共享服务获取 Token 的场景）
    /// </summary>
    /// <param name="token">access_token 字符串。</param>
    /// <param name="expiresIn">
    /// Token 有效期；为 <c>null</c> 时默认 7200 秒。<br/>
    /// 内部将提前 60 秒判定过期，以预留安全余量。
    /// </param>
    public void SetAccessToken(string token, TimeSpan? expiresIn = null)
        => _tokenProvider.SetToken(token, expiresIn);

    /// <summary>
    /// 获取当前有效的 access_token（缓存未过期时直接返回，否则自动刷新）
    /// </summary>
    /// <param name="ct">取消令牌。</param>
    /// <returns>有效的 access_token 字符串。</returns>
    public Task<string> GetAccessTokenAsync(CancellationToken ct = default)
        => _tokenProvider.GetTokenAsync(ct);

    /// <summary>
    /// 获取当前 access_token 的共享加密形式（ChaCha20-Poly1305）
    /// </summary>
    /// <param name="ct">取消令牌。</param>
    /// <returns>
    /// 包含加密 Token 字符串及剩余有效秒数的 <see cref="SharedTokenResult"/>。
    /// </returns>
    /// <remarks>
    /// 用于主服务对外暴露 Token 共享接口，需在 <see cref="Options"/> 中配置 <see cref="WecomOptions.ShareSecret"/>。<br/>
    /// 将返回的 <see cref="SharedTokenResult.Token"/> 与 <see cref="SharedTokenResult.ExpiresIn"/> 原样写入响应 JSON，
    /// 备服务据此调用 <see cref="SetAccessToken"/> 同步本地缓存。
    /// </remarks>
    public Task<SharedTokenResult> GetSharedAccessTokenAsync(CancellationToken ct = default)
        => _tokenProvider.GetSharedTokenAsync(ct);

    // ─── 企业级 jsapi_ticket 管理 ──────────────────────────────────────────

    /// <summary>使企业级 jsapi_ticket 缓存失效</summary>
    public void InvalidateJsApiTicketCache() => _jsApiTicketProvider.InvalidateCache();

    /// <summary>强制刷新企业级 jsapi_ticket</summary>
    public Task<string> RefreshJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.RefreshTicketAsync(ct);

    /// <summary>
    /// 手动设置企业级 jsapi_ticket
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒</param>
    public void SetJsApiTicket(string ticket, TimeSpan? expiresIn = null)
        => _jsApiTicketProvider.SetTicket(ticket, expiresIn);

    /// <summary>获取当前有效的企业级 jsapi_ticket</summary>
    public Task<string> GetJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.GetTicketAsync(ct);

    /// <summary>
    /// 获取当前企业级 jsapi_ticket 的共享加密形式（ChaCha20-Poly1305）
    /// </summary>
    public Task<SharedTokenResult> GetSharedJsApiTicketAsync(CancellationToken ct = default)
        => _jsApiTicketProvider.GetSharedTicketAsync(ct);

    // ─── 应用级 jsapi_ticket 管理 ──────────────────────────────────────────

    /// <summary>使应用级 jsapi_ticket 缓存失效</summary>
    public void InvalidateAgentTicketCache() => _agentTicketProvider.InvalidateCache();

    /// <summary>强制刷新应用级 jsapi_ticket</summary>
    public Task<string> RefreshAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.RefreshTicketAsync(ct);

    /// <summary>
    /// 手动设置应用级 jsapi_ticket
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒</param>
    public void SetAgentTicket(string ticket, TimeSpan? expiresIn = null)
        => _agentTicketProvider.SetTicket(ticket, expiresIn);

    /// <summary>获取当前有效的应用级 jsapi_ticket</summary>
    public Task<string> GetAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.GetTicketAsync(ct);

    /// <summary>
    /// 获取当前应用级 jsapi_ticket 的共享加密形式（ChaCha20-Poly1305）
    /// </summary>
    public Task<SharedTokenResult> GetSharedAgentTicketAsync(CancellationToken ct = default)
        => _agentTicketProvider.GetSharedTicketAsync(ct);

    /// <summary>
    /// 释放托管资源（<see cref="IMsgAuditService"/> 及内部 <see cref="HttpClient"/>）。
    /// </summary>
    public void Dispose()
    {
        MsgAudit.Dispose();
        _httpClient.Dispose();
    }
}
