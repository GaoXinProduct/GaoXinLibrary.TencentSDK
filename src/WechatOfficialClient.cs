using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;

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
    private readonly bool _ownsHttpClient;
    private readonly AccessTokenProvider _tokenProvider;
    private readonly JsApiTicketProvider _ticketProvider;
    private readonly ILogger _logger;

    /// <summary>OAuth 网页授权</summary>
    public OfficialOAuthService OAuth { get; }

    /// <summary>自定义菜单</summary>
    public OfficialMenuService Menu { get; }

    /// <summary>模板消息</summary>
    public OfficialTemplateMessageService TemplateMessage { get; }

    /// <summary>用户管理</summary>
    public OfficialUserService User { get; }

    /// <summary>服务号二维码</summary>
    public OfficialQrCodeService QrCode { get; }

    /// <summary>素材管理</summary>
    public OfficialMaterialService Material { get; }

    /// <summary>JS-SDK</summary>
    public OfficialJsSdkService JsSdk { get; }

    /// <summary>用户标签管理</summary>
    public OfficialTagService Tag { get; }

    /// <summary>草稿管理</summary>
    public OfficialDraftService Draft { get; }

    /// <summary>发布能力</summary>
    public OfficialPublishService Publish { get; }

    /// <summary>留言管理</summary>
    public OfficialCommentService Comment { get; }

    /// <summary>客服消息</summary>
    public OfficialCustomMessageService CustomMessage { get; }

    /// <summary>基础消息（群发 / 模板管理）</summary>
    public OfficialMessageService Message { get; }

    /// <summary>数据统计</summary>
    public OfficialDataAnalysisService DataAnalysis { get; }

    /// <summary>智能接口（语义理解 / OCR）</summary>
    public OfficialAiService Ai { get; }

    /// <summary>微信门店</summary>
    public OfficialPoiService Poi { get; }

    /// <summary>微信发票（商户开票）</summary>
    public OfficialInvoiceService Invoice { get; }

    /// <summary>OpenAPI 管理</summary>
    public OfficialOpenApiService OpenApi { get; }

    /// <summary>消息回调</summary>
    public OfficialCallbackService Callback { get; }

    /// <summary>当前配置</summary>
    public WechatOfficialOptions Options { get; }

    private WechatOfficialClient(WechatOfficialOptions options, HttpClient httpClient, bool ownsHttpClient, ILogger? logger = null, ILogger<OfficialCallbackService>? callbackLogger = null, WechatOfficialShareOptions? shareOptions = null)
    {
        Options = options;
        _httpClient = httpClient;
        _ownsHttpClient = ownsHttpClient;
        _logger = logger ?? NullLogger<WechatOfficialClient>.Instance;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        if (shareOptions is not null)
            _tokenProvider.ConfigureSharedSecret(shareOptions.SecretShareUrl, shareOptions.ShareSecret);
        var http = new WechatHttpClient(httpClient, _tokenProvider, options, logger);

        _ticketProvider = new JsApiTicketProvider(http);
        _ticketProvider.OnTicketChanged = options.OnTicketChanged ?? shareOptions?.OnTicketChanged;

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
        Callback = new OfficialCallbackService(http, options, callbackLogger);

        #region 备服务器模式：挂载载荷接收回调，分发 Ticket 并回写 Options
        if (shareOptions is not null)
        {
            _tokenProvider.OnSecretPayloadReceived = (payload, ct) =>
            {
                // 回写凭证到 Options（供 OAuth 等动态读取）
                if (!string.IsNullOrWhiteSpace(payload.AppId))
                    options.AppId = payload.AppId;
                if (!string.IsNullOrWhiteSpace(payload.AppSecret))
                    options.AppSecret = payload.AppSecret;

                // 分发 jsapi_ticket
                if (!string.IsNullOrWhiteSpace(payload.JsApiTicket))
                    _ticketProvider.SetTicket(payload.JsApiTicket,
                        TimeSpan.FromSeconds(Math.Max(payload.TicketExpiresIn, 1)));

                return Task.CompletedTask;
            };
        }
        #endregion
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static WechatOfficialClient Create(WechatOfficialOptions options, ILogger? logger = null)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WechatOfficialClient(options, httpClient, ownsHttpClient: true, logger);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static WechatOfficialClient Create(WechatOfficialOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOfficialClient(options, httpClient, ownsHttpClient: false, logger);
    }

    internal static WechatOfficialClient CreateOwned(WechatOfficialOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOfficialClient(options, httpClient, ownsHttpClient: true, logger);
    }

    internal static WechatOfficialClient CreateOwned(WechatOfficialOptions options, HttpClient httpClient, ILogger? logger, ILogger<OfficialCallbackService>? callbackLogger)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOfficialClient(options, httpClient, ownsHttpClient: true, logger, callbackLogger);
    }

    internal static WechatOfficialClient CreateShareOwned(WechatOfficialShareOptions options, HttpClient httpClient, ILogger? logger = null, ILogger<OfficialCallbackService>? callbackLogger = null)
    {
        ValidateShareOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOfficialClient(ToOfficialOptions(options), httpClient, ownsHttpClient: true, logger, callbackLogger, options);
    }

    private static WechatOfficialOptions ToOfficialOptions(WechatOfficialShareOptions options) => new()
    {
        BaseUrl = options.BaseUrl,
        HttpTimeout = options.HttpTimeout,
        OnTokenChanged = options.OnTokenChanged,
        RetryOptions = options.RetryOptions,
        OnTicketChanged = options.OnTicketChanged
    };

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

    #region jsapi_ticket 管理

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

    #endregion
    #region 统一共享密钥（主服务器调用）

    /// <summary>
    /// 获取统一共享密钥载荷（主服务器调用），使用 <see cref="WechatOfficialOptions.ShareSecret"/> 作为共享密钥
    /// <para>
    /// 需先在 <see cref="WechatOfficialClient.Options"/> 中配置 <see cref="WechatOfficialOptions.ShareSecret"/>。<br/>
    /// 若未配置则抛出 <see cref="InvalidOperationException"/>。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>加密后的统一共享密钥载荷</returns>
    /// <exception cref="InvalidOperationException">Options.ShareSecret 未配置</exception>
    public Task<SharedSecretResult> GetSharedSecretAsync(CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(Options.ShareSecret))
            throw new InvalidOperationException(
                "WechatOfficialOptions.ShareSecret 未配置。请在 Options 中设置 ShareSecret，或调用 GetSharedSecretAsync(shareSecret, ct) 重载传入。");
        return GetSharedSecretAsync(Options.ShareSecret, ct);
    }

    /// <summary>
    /// 获取统一共享密钥载荷（主服务器调用）
    /// <para>
    /// 将当前有效的 access_token、jsapi_ticket、AppId/AppSecret
    /// 打包为 <see cref="SharedSecretPayload"/>，使用 <paramref name="shareSecret"/> 加密后返回。<br/>
    /// 建议在主服务器侧通过受保护的内部接口对外暴露此方法的返回值。
    /// </para>
    /// </summary>
    /// <param name="shareSecret">主服务器与备服务器约定的共享密钥</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>加密后的统一共享密钥载荷</returns>
    public async Task<SharedSecretResult> GetSharedSecretAsync(string shareSecret, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shareSecret);

        var payload = await _tokenProvider.BuildBasePayloadAsync(ct).ConfigureAwait(false);

        payload.AppId = Options.AppId;
        payload.AppSecret = Options.AppSecret;

        // jsapi_ticket（可选，未缓存时不阻塞）
        try
        {
            payload.JsApiTicket = await _ticketProvider.GetTicketAsync(ct).ConfigureAwait(false);
            payload.TicketExpiresIn = _ticketProvider.GetRemainingSeconds();
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "构建共享密钥载荷时未能获取 jsapi_ticket，已跳过该字段");
        }

        var key = TencentTokenCrypto.DeriveKey(shareSecret);
        var payloadJson = JsonSerializer.Serialize(payload);
        var encrypted = TencentTokenCrypto.EncryptWithKey(payloadJson, key);

        return new SharedSecretResult { Data = encrypted };
    }

    private static void ValidateOptions(WechatOfficialOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (string.IsNullOrWhiteSpace(options.AppId))
            throw new ArgumentException("AppId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.AppSecret))
            throw new ArgumentException("AppSecret 不能为空", nameof(options));
    }

    private static void ValidateShareOptions(WechatOfficialShareOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.SecretShareUrl))
            throw new ArgumentException("WechatOfficialShareOptions.SecretShareUrl 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.ShareSecret))
            throw new ArgumentException("WechatOfficialShareOptions.ShareSecret 不能为空", nameof(options));
    }

    public void Dispose()
    {
        if (_ownsHttpClient)
            _httpClient.Dispose();
    }
    #endregion
}
