using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;

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

    /// <summary>当前配置</summary>
    public WecomOptions Options { get; }

    // ─── 构造 ─────────────────────────────────────────────────────────────────

    private WecomClient(WecomOptions options, HttpClient httpClient)
    {
        Options = options;
        _httpClient = httpClient;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        _http = new WecomHttpClient(httpClient, _tokenProvider, options);

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
        JsSdk = new JsSdkService(_http, options.CorpId, options.AgentId);
        Checkin = new CheckinService(_http);
        Approval = new ApprovalService(_http);
        Export = new ExportService(_http);
    }

    /// <summary>
    /// 使用指定配置创建 <see cref="WecomClient"/> 实例（内部自动创建 <see cref="HttpClient"/>）
    /// </summary>
    /// <param name="options">企业微信配置，必须包含 <see cref="WecomOptions.CorpId"/> 和 <see cref="WecomOptions.CorpSecret"/>。</param>
    /// <returns>已初始化的 <see cref="WecomClient"/> 实例。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> 为 <c>null</c>。</exception>
    /// <exception cref="ArgumentException"><see cref="WecomOptions.CorpId"/> 或 <see cref="WecomOptions.CorpSecret"/> 为空。</exception>
    public static WecomClient Create(WecomOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.CorpId)) throw new ArgumentException("CorpId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.CorpSecret)) throw new ArgumentException("CorpSecret 不能为空", nameof(options));

        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WecomClient(options, httpClient);
    }

    /// <summary>
    /// 使用已有 <see cref="HttpClient"/> 创建 <see cref="WecomClient"/> 实例
    /// </summary>
    /// <param name="options">企业微信配置。</param>
    /// <param name="httpClient">外部托管的 <see cref="HttpClient"/>，可注入自定义 <see cref="System.Net.Http.DelegatingHandler"/>（如日志、重试）。</param>
    /// <returns>已初始化的 <see cref="WecomClient"/> 实例。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> 或 <paramref name="httpClient"/> 为 <c>null</c>。</exception>
    public static WecomClient Create(WecomOptions options, HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WecomClient(options, httpClient);
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

    /// <summary>
    /// 释放托管资源（<see cref="IMsgAuditService"/> 及内部 <see cref="HttpClient"/>）。
    /// </summary>
    public void Dispose()
    {
        MsgAudit.Dispose();
        _httpClient.Dispose();
    }
}
