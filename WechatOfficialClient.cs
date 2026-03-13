using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;
using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Wechat;

/// <summary>
/// 微信公众号 SDK 主客户端
/// <para>
/// 使用示例：
/// <code>
/// var client = WechatOfficialClient.Create(new WechatOfficialOptions
/// {
///     AppId     = "your_appid",
///     AppSecret = "your_appsecret"
/// });
/// var url = client.OAuth.BuildAuthUrl("https://example.com/callback");
/// </code>
/// </para>
/// </summary>
public sealed class WechatOfficialClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly AccessTokenProvider _tokenProvider;
    private readonly JsApiTicketProvider _ticketProvider;

    /// <summary>OAuth 网页授权</summary>
    public IOfficialOAuthService OAuth { get; }

    /// <summary>自定义菜单</summary>
    public IOfficialMenuService Menu { get; }

    /// <summary>模板消息</summary>
    public IOfficialTemplateMessageService TemplateMessage { get; }

    /// <summary>用户管理</summary>
    public IOfficialUserService User { get; }

    /// <summary>服务号二维码</summary>
    public IOfficialQrCodeService QrCode { get; }

    /// <summary>素材管理</summary>
    public IOfficialMaterialService Material { get; }

    /// <summary>JS-SDK</summary>
    public IOfficialJsSdkService JsSdk { get; }

    /// <summary>用户标签管理</summary>
    public IOfficialTagService Tag { get; }

    /// <summary>草稿管理</summary>
    public IOfficialDraftService Draft { get; }

    /// <summary>发布能力</summary>
    public IOfficialPublishService Publish { get; }

    /// <summary>留言管理</summary>
    public IOfficialCommentService Comment { get; }

    /// <summary>客服消息</summary>
    public IOfficialCustomMessageService CustomMessage { get; }

    /// <summary>基础消息（群发 / 模板管理）</summary>
    public IOfficialMessageService Message { get; }

    /// <summary>数据统计</summary>
    public IOfficialDataAnalysisService DataAnalysis { get; }

    /// <summary>智能接口（语义理解 / OCR）</summary>
    public IOfficialAiService Ai { get; }

    /// <summary>微信门店</summary>
    public IOfficialPoiService Poi { get; }

    /// <summary>微信发票（商户开票）</summary>
    public IOfficialInvoiceService Invoice { get; }

    /// <summary>OpenAPI 管理</summary>
    public IOfficialOpenApiService OpenApi { get; }

    /// <summary>消息回调</summary>
    public IOfficialCallbackService Callback { get; }

    /// <summary>当前配置</summary>
    public WechatOfficialOptions Options { get; }

    private WechatOfficialClient(WechatOfficialOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        Options = options;
        _httpClient = httpClient;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        var http = new WechatHttpClient(httpClient, _tokenProvider, options, logger);

        _ticketProvider = new JsApiTicketProvider(http, httpClient);
        _ticketProvider.ConfigureSharedTicket(options.TicketShareSecret, options.TicketShareUrl);
        _ticketProvider.OnTicketChanged = options.OnTicketChanged;

        // 统一共享密钥模式：收到解密载荷后分发 Ticket、AppId、AppSecret 到各子服务
        if (!string.IsNullOrWhiteSpace(options.SecretShareUrl))
        {
            _tokenProvider.OnSecretPayloadReceived = (payload, _) =>
            {
                // 将 AppId / AppSecret 回写到 Options，供 OAuth 等服务动态读取
                if (!string.IsNullOrEmpty(payload.AppId))
                    options.AppId = payload.AppId;
                if (!string.IsNullOrEmpty(payload.AppSecret))
                    options.AppSecret = payload.AppSecret;

                // 将 Ticket 分发给 TicketProvider
                if (!string.IsNullOrEmpty(payload.JsApiTicket))
                    _ticketProvider.SetTicket(payload.JsApiTicket,
                        TimeSpan.FromSeconds(payload.TicketExpiresIn > 0 ? payload.TicketExpiresIn : 7200));

                return Task.CompletedTask;
            };
        }

        OAuth = new OfficialOAuthService(http, options);
        Menu = new OfficialMenuService(http);
        TemplateMessage = new OfficialTemplateMessageService(http);
        User = new OfficialUserService(http);
        QrCode = new OfficialQrCodeService(http);
        Material = new OfficialMaterialService(http);
        JsSdk = new OfficialJsSdkService(_ticketProvider, options);
        Tag = new OfficialTagService(http);
        Draft = new OfficialDraftService(http);
        Publish = new OfficialPublishService(http);
        Comment = new OfficialCommentService(http);
        CustomMessage = new OfficialCustomMessageService(http);
        Message = new OfficialMessageService(http);
        DataAnalysis = new OfficialDataAnalysisService(http);
        Ai = new OfficialAiService(http);
        Poi = new OfficialPoiService(http);
        Invoice = new OfficialInvoiceService(http);
        OpenApi = new OfficialOpenApiService(http, options);
        Callback = new OfficialCallbackService(http, options);
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static WechatOfficialClient Create(WechatOfficialOptions options, ILogger? logger = null)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WechatOfficialClient(options, httpClient, logger);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static WechatOfficialClient Create(WechatOfficialOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOfficialClient(options, httpClient, logger);
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

    /// <summary>
    /// 获取统一共享密钥的加密形式（ChaCha20-Poly1305）
    /// <para>
    /// 用于主服务对外暴露单一共享接口，需在 Options 中配置 <c>ShareSecret</c>。<br/>
    /// 返回的 <see cref="SharedSecretResult.Data"/> 包含加密后的 <see cref="SharedSecretPayload"/>（access_token、jsapi_ticket、AppId、AppSecret 等）。<br/>
    /// 备服务配置 <c>SecretShareUrl</c> + <c>ShareSecret</c> 后将自动获取解密并分发给各子服务，无需配置 AppId / AppSecret。
    /// </para>
    /// </summary>
    public async Task<SharedSecretResult> GetSharedSecretAsync(CancellationToken ct = default)
    {
        // 确保 ticket 已初始化
        var ticket = await GetTicketAsync(ct);
        var ticketRemaining = _ticketProvider.GetRemainingSeconds();

        return await _tokenProvider.GetSharedSecretAsync(payload =>
        {
            payload.AppId = Options.AppId;
            payload.AppSecret = Options.AppSecret;
            payload.JsApiTicket = ticket;
            payload.TicketExpiresIn = ticketRemaining;
        }, ct);
    }

    // ─── jsapi_ticket 管理 ─────────────────────────────────────────────────

    /// <summary>使 jsapi_ticket 缓存失效（下次 GetTicketAsync 时自动重新获取）</summary>
    public void InvalidateTicketCache() => _ticketProvider.InvalidateCache();

    /// <summary>强制刷新 jsapi_ticket（立即请求新 Ticket 并更新缓存）</summary>
    public Task<string> RefreshTicketAsync(CancellationToken ct = default)
        => _ticketProvider.RefreshTicketAsync(ct);

    /// <summary>
    /// 手动设置 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（内部提前 60 秒过期以留出安全余量）</param>
    public void SetTicket(string ticket, TimeSpan? expiresIn = null)
        => _ticketProvider.SetTicket(ticket, expiresIn);

    /// <summary>直接获取当前有效的 jsapi_ticket</summary>
    public Task<string> GetTicketAsync(CancellationToken ct = default)
        => _ticketProvider.GetTicketAsync(ct);

    /// <summary>
    /// 获取当前 jsapi_ticket 的共享加密形式（ChaCha20-Poly1305）
    /// <para>
    /// 用于主服务对外暴露 Ticket 共享接口，需在 Options 中配置 <c>TicketShareSecret</c>。
    /// </para>
    /// </summary>
    public Task<SharedTokenResult> GetSharedTicketAsync(CancellationToken ct = default)
        => _ticketProvider.GetSharedTicketAsync(ct);

    private static void ValidateOptions(WechatOfficialOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        // 统一共享密钥模式：仅需 ShareSecret + SecretShareUrl，AppId/AppSecret 将由远端载荷提供
        if (!string.IsNullOrWhiteSpace(options.SecretShareUrl) && !string.IsNullOrWhiteSpace(options.ShareSecret))
            return;

        if (string.IsNullOrWhiteSpace(options.AppId))
            throw new ArgumentException("AppId 不能为空（或配置 SecretShareUrl + ShareSecret 使用统一共享密钥模式）", nameof(options));

        if (string.IsNullOrWhiteSpace(options.AppSecret) &&
            (string.IsNullOrWhiteSpace(options.ShareSecret) || string.IsNullOrWhiteSpace(options.TokenShareUrl)))
        {
            throw new ArgumentException("AppSecret 不能为空，或者需要同时配置 ShareSecret 和 TokenShareUrl（或使用 SecretShareUrl 统一共享密钥模式）", nameof(options));
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
