using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;

namespace GaoXinLibrary.TencentSDK.Wecom;

/// <summary>
/// 企业微信服务端 SDK 主客户端
/// <para>
/// 使用示例：
/// <code>
/// var client = WecomClient.Create(new WecomOptions
/// {
///     CorpId     = "your_corpid",
///     CorpSecret = "your_corpsecret",
///     AgentId    = 1000001
/// });
/// await client.Message.SendTextAsync("Hello!", toUser: "@all");
/// </code>
/// </para>
/// </summary>
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

    /// <summary>应用管理</summary>
    public IAgentService Agent { get; }

    /// <summary>素材管理</summary>
    public IMediaService Media { get; }

    /// <summary>应用群聊会话管理</summary>
    public IGroupChatService GroupChat { get; }

    /// <summary>自定义菜单管理（菜单与应用管理共用同一服务实例）</summary>
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
        var agentSvc = new AgentService(_http);
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
    /// 使用指定配置创建 WecomClient 实例
    /// </summary>
    public static WecomClient Create(WecomOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.CorpId)) throw new ArgumentException("CorpId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.CorpSecret)) throw new ArgumentException("CorpSecret 不能为空", nameof(options));

        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WecomClient(options, httpClient);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建 WecomClient 实例（便于注入自定义 Handler）
    /// </summary>
    public static WecomClient Create(WecomOptions options, HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WecomClient(options, httpClient);
    }

    /// <summary>使 access_token 缓存失效（下次 GetAccessTokenAsync 时自动重新获取）</summary>
    public void InvalidateAccessTokenCache() => _tokenProvider.InvalidateCache();

    /// <summary>强制刷新 access_token（立即请求新 Token 并更新缓存）</summary>
    public Task<string> RefreshAccessTokenAsync(CancellationToken ct = default)
        => _tokenProvider.RefreshTokenAsync(ct);

    /// <summary>
    /// 手动设置 access_token（适用于从外部令牌服务获取 Token 的场景）
    /// </summary>
    /// <param name="token">access_token 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    public void SetAccessToken(string token, TimeSpan? expiresIn = null)
        => _tokenProvider.SetToken(token, expiresIn);

    /// <summary>直接获取当前有效的 access_token</summary>
    public Task<string> GetAccessTokenAsync(CancellationToken ct = default)
        => _tokenProvider.GetTokenAsync(ct);

    /// <summary>
    /// 获取当前 access_token 的共享加密形式（ChaCha20-Poly1305）
    /// <para>
    /// 用于主服务对外暴露 Token 共享接口，需在 Options 中配置 <c>ShareSecret</c>。<br/>
    /// 将返回的 <see cref="SharedTokenResult.Token"/> 和 <see cref="SharedTokenResult.ExpiresIn"/> 原样写入响应 JSON，
    /// 备服务据此同步本地缓存过期时间。
    /// </para>
    /// </summary>
    public Task<SharedTokenResult> GetSharedAccessTokenAsync(CancellationToken ct = default)
        => _tokenProvider.GetSharedTokenAsync(ct);

    public void Dispose()
    {
        MsgAudit.Dispose();
        _httpClient.Dispose();
    }
}
