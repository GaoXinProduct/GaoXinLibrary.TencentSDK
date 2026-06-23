using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;

namespace GaoXinLibrary.TencentSDK.Wechat;

/// <summary>
/// 微信小程序 SDK 主客户端
/// <para>
/// 使用示例：
/// <code>
/// var client = WechatMiniProgramClient.Create(new WechatMiniProgramOptions
/// {
///     AppId     = "your_appid",
///     AppSecret = "your_appsecret"
/// });
/// var session = await client.Auth.Code2SessionAsync("js_code_from_wx_login").ConfigureAwait(false);
/// </code>
/// </para>
/// </summary>
public sealed class WechatMiniProgramClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;
    private readonly AccessTokenProvider _tokenProvider;
    private readonly ILogger _logger;

    /// <summary>登录与手机号</summary>
    public MiniProgramAuthService Auth { get; }

    /// <summary>小程序码</summary>
    public MiniProgramQrCodeService QrCode { get; }

    /// <summary>订阅消息</summary>
    public MiniProgramSubscribeMessageService SubscribeMessage { get; }

    /// <summary>内容安全</summary>
    public MiniProgramSecurityService Security { get; }

    /// <summary>发货信息管理</summary>
    public MiniProgramShippingService Shipping { get; }

    /// <summary>OCR 与图像处理</summary>
    public MiniProgramOcrService Ocr { get; }

    /// <summary>小程序链接（URL Scheme / URL Link / Short Link）</summary>
    public MiniProgramLinkService Link { get; }

    /// <summary>数据分析</summary>
    public MiniProgramDataAnalysisService DataAnalysis { get; }

    /// <summary>物流助手</summary>
    public MiniProgramExpressService Express { get; }

    /// <summary>运维中心</summary>
    public MiniProgramOperationService Operation { get; }

    /// <summary>硬件设备</summary>
    public MiniProgramDeviceService Device { get; }

    /// <summary>客服消息</summary>
    public MiniProgramCustomMessageService CustomMessage { get; }

    /// <summary>OpenAPI 管理</summary>
    public MiniProgramOpenApiService OpenApi { get; }

    /// <summary>交易管理服务</summary>
    public MiniProgramTradeService Trade { get; }

    /// <summary>即时配送服务</summary>
    public MiniProgramDeliveryService Delivery { get; }

    /// <summary>交易保障服务</summary>
    public MiniProgramTransactionGuaranteeService TransactionGuarantee { get; }

    /// <summary>动态消息服务</summary>
    public MiniProgramDynamicMessageService DynamicMessage { get; }

    /// <summary>云开发服务</summary>
    public MiniProgramCloudBaseService CloudBase { get; }

    /// <summary>当前配置</summary>
    public WechatMiniProgramOptions Options { get; }

    private WechatMiniProgramClient(WechatMiniProgramOptions options, HttpClient httpClient, bool ownsHttpClient, ILogger? logger = null, WechatMiniProgramShareOptions? shareOptions = null)
    {
        Options = options;
        _httpClient = httpClient;
        _ownsHttpClient = ownsHttpClient;
        _logger = logger ?? NullLogger<WechatMiniProgramClient>.Instance;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        if (shareOptions is not null)
        {
            _tokenProvider.ConfigureSharedSecret(shareOptions.SecretShareUrl, shareOptions.ShareSecret);
            _tokenProvider.OnSecretPayloadReceived = (payload, ct) =>
            {
                if (!string.IsNullOrWhiteSpace(payload.AppId))
                    options.AppId = payload.AppId;
                if (!string.IsNullOrWhiteSpace(payload.AppSecret))
                    options.AppSecret = payload.AppSecret;
                return Task.CompletedTask;
            };
        }
        var http = new WechatHttpClient(httpClient, _tokenProvider, options, logger);

        Auth = new MiniProgramAuthService(http, options);
        QrCode = new MiniProgramQrCodeService(http);
        SubscribeMessage = new MiniProgramSubscribeMessageService(http);
        Security = new MiniProgramSecurityService(http);
        Shipping = new MiniProgramShippingService(http);
        Ocr = new MiniProgramOcrService(http);
        Link = new MiniProgramLinkService(http);
        DataAnalysis = new MiniProgramDataAnalysisService(http);
        Express = new MiniProgramExpressService(http);
        Operation = new MiniProgramOperationService(http);
        Device = new MiniProgramDeviceService(http);
        CustomMessage = new MiniProgramCustomMessageService(http);
        OpenApi = new MiniProgramOpenApiService(http, options);
        Trade = new MiniProgramTradeService(http);
        Delivery = new MiniProgramDeliveryService(http);
        TransactionGuarantee = new MiniProgramTransactionGuaranteeService(http);
        DynamicMessage = new MiniProgramDynamicMessageService(http);
        CloudBase = new MiniProgramCloudBaseService(http);
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static WechatMiniProgramClient Create(WechatMiniProgramOptions options, ILogger? logger = null)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WechatMiniProgramClient(options, httpClient, ownsHttpClient: true, logger);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static WechatMiniProgramClient Create(WechatMiniProgramOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatMiniProgramClient(options, httpClient, ownsHttpClient: false, logger);
    }

    internal static WechatMiniProgramClient CreateOwned(WechatMiniProgramOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatMiniProgramClient(options, httpClient, ownsHttpClient: true, logger);
    }

    internal static WechatMiniProgramClient CreateShareOwned(WechatMiniProgramShareOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateShareOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatMiniProgramClient(ToMiniProgramOptions(options), httpClient, ownsHttpClient: true, logger, options);
    }

    private static WechatMiniProgramOptions ToMiniProgramOptions(WechatMiniProgramShareOptions options) => new()
    {
        BaseUrl = options.BaseUrl,
        HttpTimeout = options.HttpTimeout,
        OnTokenChanged = options.OnTokenChanged,
        RetryOptions = options.RetryOptions
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

    private static void ValidateOptions(WechatMiniProgramOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.AppId)) throw new ArgumentException("AppId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.AppSecret))
            throw new ArgumentException("AppSecret 不能为空", nameof(options));
    }

    private static void ValidateShareOptions(WechatMiniProgramShareOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.SecretShareUrl))
            throw new ArgumentException("WechatMiniProgramShareOptions.SecretShareUrl 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.ShareSecret))
            throw new ArgumentException("WechatMiniProgramShareOptions.ShareSecret 不能为空", nameof(options));
    }

    #region 统一共享密钥（主服务器调用）

    public Task<SharedSecretResult> GetSharedSecretAsync(CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(Options.ShareSecret))
            throw new InvalidOperationException(
                "WechatMiniProgramOptions.ShareSecret 未配置。请在 Options 中设置 ShareSecret，或调用 GetSharedSecretAsync(shareSecret, ct) 重载传入。");
        return GetSharedSecretAsync(Options.ShareSecret, ct);
    }

    public async Task<SharedSecretResult> GetSharedSecretAsync(string shareSecret, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shareSecret);

        var payload = await _tokenProvider.BuildBasePayloadAsync(ct).ConfigureAwait(false);

        payload.AppId = Options.AppId;
        payload.AppSecret = Options.AppSecret;

        var key = TencentTokenCrypto.DeriveKey(shareSecret);
        var payloadJson = JsonSerializer.Serialize(payload);
        var encrypted = TencentTokenCrypto.EncryptWithKey(payloadJson, key);

        return new SharedSecretResult { Data = encrypted };
    }

    #endregion

    public void Dispose()
    {
        if (_ownsHttpClient)
            _httpClient.Dispose();
    }
}
