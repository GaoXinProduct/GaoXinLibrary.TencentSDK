using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;

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
    private readonly bool _ownsHttpClient;
    private readonly AccessTokenProvider _tokenProvider;
    private readonly WecomHttpClient _http;
    private readonly WecomTicketProvider _jsApiTicketProvider;
    private readonly WecomTicketProvider _agentTicketProvider;

    #region 子服务

    /// <summary>成员管理</summary>
    public UserService User { get; }

    /// <summary>部门管理</summary>
    public DepartmentService Department { get; }

    /// <summary>标签管理</summary>
    public TagService Tag { get; }

    /// <summary>应用消息发送</summary>
    public MessageService Message { get; }

    /// <summary>应用管理（查询/配置自建应用及自定义菜单）</summary>
    public AgentService Agent { get; }

    /// <summary>素材管理</summary>
    public MediaService Media { get; }

    /// <summary>应用群聊会话管理</summary>
    public GroupChatService GroupChat { get; }

    /// <summary>自定义菜单管理</summary>
    /// <remarks>与 <see cref="Agent"/> 共用同一 <c>AgentService</c> 实例。</remarks>
    public AgentService Menu { get; }

    /// <summary>网页授权登录（OAuth2）</summary>
    public OAuthService OAuth { get; }

    /// <summary>企业互联</summary>
    public CorpGroupService CorpGroup { get; }

    /// <summary>上下游/互联企业</summary>
    public LinkedCorpService LinkedCorp { get; }

    /// <summary>微信客服</summary>
    public KfService Kf { get; }

    /// <summary>会话内容存档</summary>
    public MsgAuditService MsgAudit { get; }

    /// <summary>企业微信 H5 / JS-SDK</summary>
    public JsSdkService JsSdk { get; }

    /// <summary>打卡</summary>
    public CheckinService Checkin { get; }

    /// <summary>审批</summary>
    public ApprovalService Approval { get; }

    /// <summary>异步导出</summary>
    public ExportService Export { get; }

    /// <summary>异步导入</summary>
    public AsyncImportService AsyncImport { get; }

    /// <summary>二次验证</summary>
    public SecondVerifyService SecondVerify { get; }

    /// <summary>安全管理</summary>
    public SecurityService Security { get; }

    /// <summary>高级功能账号管理</summary>
    public AdvancedAccountService AdvancedAccount { get; }

    /// <summary>操作日志</summary>
    public OperationLogService OperationLog { get; }

    /// <summary>账号ID管理</summary>
    public AccountIdService AccountId { get; }

    /// <summary>IP段查询</summary>
    public IpRangeService IpRange { get; }

    /// <summary>客户联系</summary>
    public ExternalContactService ExternalContact { get; }

    /// <summary>企业支付</summary>
    public CorpPayService CorpPay { get; }

    /// <summary>邮件</summary>
    public EmailService Email { get; }

    /// <summary>文档</summary>
    public DocumentService Document { get; }

    /// <summary>日程</summary>
    public CalendarService Calendar { get; }

    /// <summary>会议</summary>
    public MeetingService Meeting { get; }

    /// <summary>微盘</summary>
    public WedriveService Wedrive { get; }

    /// <summary>直播</summary>
    public LivingService Living { get; }

    /// <summary>公费电话</summary>
    public DialService Dial { get; }

    /// <summary>汇报</summary>
    public ReportService Report { get; }

    /// <summary>人事助手</summary>
    public HrService Hr { get; }

    /// <summary>会议室</summary>
    public MeetingRoomService MeetingRoom { get; }

    /// <summary>电子发票</summary>
    public InvoiceService Invoice { get; }

    /// <summary>智能表格</summary>
    public SmartSheetService SmartSheet { get; }

    /// <summary>收集表</summary>
    public CollectFormService CollectForm { get; }

    /// <summary>当前配置</summary>
    public WecomOptions Options { get; }

    #endregion
    #region 构造

    private WecomClient(WecomOptions options, HttpClient httpClient, bool ownsHttpClient, ILogger? logger = null)
    {
        Options = options;
        _httpClient = httpClient;
        _ownsHttpClient = ownsHttpClient;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        _http = new WecomHttpClient(httpClient, _tokenProvider, options, logger);

        User = new UserService(_http);
        Department = new DepartmentService(_http);
        Tag = new TagService(_http);
        Message = new MessageService(_http, options.AgentId);
        var agentSvc = new AgentService(_http, options);
        Agent = agentSvc;
        Menu = agentSvc;
        Media = new MediaService(_http, _tokenProvider, httpClient, options.BaseUrl);
        GroupChat = new GroupChatService(_http);
        OAuth = new OAuthService(_http, options);
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
            });

        _agentTicketProvider = new WecomTicketProvider(
            async ct =>
            {
                var resp = await _http.GetAsync<GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk.GetAgentTicketResponse>(
                    "/cgi-bin/ticket/get",
                    new Dictionary<string, string?> { ["type"] = "agent_config" }, ct);
                return (resp.Ticket, resp.ExpiresIn);
            });

        JsSdk = new JsSdkService(_jsApiTicketProvider, _agentTicketProvider, options);
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

        #region 备服务器模式：挂载载荷接收回调，分发 Ticket 并回写 Options
        if (!string.IsNullOrWhiteSpace(options.SecretShareUrl))
        {
            _tokenProvider.OnSecretPayloadReceived = (payload, ct) =>
            {
                // 回写凭证到 Options（供 OAuth / JsSdk 等动态读取）
                if (!string.IsNullOrWhiteSpace(payload.CorpId))
                    options.CorpId = payload.CorpId;
                if (!string.IsNullOrWhiteSpace(payload.CorpSecret))
                    options.CorpSecret = payload.CorpSecret;
                if (payload.AgentId != 0)
                    options.AgentId = payload.AgentId;

                // 分发企业级 jsapi_ticket
                if (!string.IsNullOrWhiteSpace(payload.JsApiTicket))
                    _jsApiTicketProvider.SetTicket(payload.JsApiTicket,
                        TimeSpan.FromSeconds(Math.Max(payload.TicketExpiresIn, 1)));

                // 分发应用级 jsapi_ticket
                if (!string.IsNullOrWhiteSpace(payload.AgentTicket))
                    _agentTicketProvider.SetTicket(payload.AgentTicket,
                        TimeSpan.FromSeconds(Math.Max(payload.AgentTicketExpiresIn, 1)));

                return Task.CompletedTask;
            };
        }
        #endregion
    }

    /// <summary>
    /// 使用指定配置创建 <see cref="WecomClient"/> 实例（内部自动创建 <see cref="HttpClient"/>）
    /// </summary>
    /// <param name="options">企业微信配置，必须包含 <see cref="WecomOptions.CorpId"/> 和 <see cref="WecomOptions.CorpSecret"/>（备服务器模式下可省略）。</param>
    /// <returns>已初始化的 <see cref="WecomClient"/> 实例。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> 为 <c>null</c>。</exception>
    /// <exception cref="ArgumentException"><see cref="WecomOptions.CorpId"/> 或 <see cref="WecomOptions.CorpSecret"/> 为空（非备服务器模式）。</exception>
    public static WecomClient Create(WecomOptions options, ILogger? logger = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WecomClient(options, httpClient, ownsHttpClient: true, logger);
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
        ValidateOptions(options);
        return new WecomClient(options, httpClient, ownsHttpClient: false, logger);
    }

    private static void ValidateOptions(WecomOptions options)
    {
        // 备服务器模式（SecretShareUrl 已配置）：无需 CorpId / CorpSecret
        if (!string.IsNullOrWhiteSpace(options.SecretShareUrl))
        {
            if (string.IsNullOrWhiteSpace(options.ShareSecret))
                throw new ArgumentException("配置 SecretShareUrl 时必须同时配置 ShareSecret", nameof(options));
            return;
        }

        if (string.IsNullOrWhiteSpace(options.CorpId))
            throw new ArgumentException("CorpId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.CorpSecret))
            throw new ArgumentException("CorpSecret 不能为空", nameof(options));
    }

    /// <summary>
    /// 获取内部 HTTP 客户端（供同程序集的 DI 扩展方法使用）
    /// </summary>
    internal WecomHttpClient GetInternalHttpClient() => _http;

    /// <summary>
    /// 使 access_token 缓存失效
    /// </summary>
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

    #endregion
    #region 企业级 jsapi_ticket 管理

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

    #endregion
    #region 应用级 jsapi_ticket 管理

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

    #endregion
    #region 统一共享密钥（主服务器调用）

    /// <summary>
    /// 获取统一共享密钥载荷（主服务器调用）
    /// <para>
    /// 将当前有效的 access_token、企业级/应用级 jsapi_ticket、CorpId/CorpSecret/AgentId
    /// 打包为 <see cref="SharedSecretPayload"/>，使用 <see cref="WecomOptions.ShareSecret"/> 加密后返回。<br/>
    /// 建议在主服务器侧通过受保护的内部接口对外暴露此方法的返回值。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>加密后的统一共享密钥载荷</returns>
    /// <exception cref="InvalidOperationException">未配置 <see cref="WecomOptions.ShareSecret"/> 时抛出</exception>
    public async Task<SharedSecretResult> GetSharedSecretAsync(CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(Options.ShareSecret))
            throw new InvalidOperationException("获取统一共享密钥需配置 WecomOptions.ShareSecret");

        var payload = await _tokenProvider.BuildBasePayloadAsync(ct);

        payload.CorpId = Options.CorpId;
        payload.CorpSecret = Options.CorpSecret;
        payload.AgentId = Options.AgentId;

        // 企业级 jsapi_ticket（可选，未缓存时不阻塞）
        try
        {
            payload.JsApiTicket = await _jsApiTicketProvider.GetTicketAsync(ct);
            payload.TicketExpiresIn = _jsApiTicketProvider.GetRemainingSeconds();
        }
        catch { /* 主服务器尚未获取过 jsapi_ticket 时忽略 */ }

        // 应用级 jsapi_ticket（可选）
        try
        {
            payload.AgentTicket = await _agentTicketProvider.GetTicketAsync(ct);
            payload.AgentTicketExpiresIn = _agentTicketProvider.GetRemainingSeconds();
        }
        catch { /* 同上 */ }

        var key = TencentTokenCrypto.DeriveKey(Options.ShareSecret);
        var payloadJson = JsonSerializer.Serialize(payload);
        var encrypted = TencentTokenCrypto.EncryptWithKey(payloadJson, key);

        return new SharedSecretResult { Data = encrypted };
    }

    /// <summary>
    /// 释放托管资源（<see cref="MsgAuditService"/> 及内部 <see cref="HttpClient"/>）。
    /// </summary>
    public void Dispose()
    {
        MsgAudit.Dispose();
        if (_ownsHttpClient)
            _httpClient.Dispose();
    }
    #endregion
}
