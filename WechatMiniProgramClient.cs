using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;
using Microsoft.Extensions.Logging;

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
/// var session = await client.Auth.Code2SessionAsync("js_code_from_wx_login");
/// </code>
/// </para>
/// </summary>
public sealed class WechatMiniProgramClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly AccessTokenProvider _tokenProvider;

    /// <summary>登录与手机号</summary>
    public IMiniProgramAuthService Auth { get; }

    /// <summary>小程序码</summary>
    public IMiniProgramQrCodeService QrCode { get; }

    /// <summary>订阅消息</summary>
    public IMiniProgramSubscribeMessageService SubscribeMessage { get; }

    /// <summary>内容安全</summary>
    public IMiniProgramSecurityService Security { get; }

    /// <summary>发货信息管理</summary>
    public IMiniProgramShippingService Shipping { get; }

    /// <summary>OCR 与图像处理</summary>
    public IMiniProgramOcrService Ocr { get; }

    /// <summary>小程序链接（URL Scheme / URL Link / Short Link）</summary>
    public IMiniProgramLinkService Link { get; }

    /// <summary>数据分析</summary>
    public IMiniProgramDataAnalysisService DataAnalysis { get; }

    /// <summary>物流助手</summary>
    public IMiniProgramExpressService Express { get; }

    /// <summary>运维中心</summary>
    public IMiniProgramOperationService Operation { get; }

    /// <summary>硬件设备</summary>
    public IMiniProgramDeviceService Device { get; }

    /// <summary>客服消息</summary>
    public IMiniProgramCustomMessageService CustomMessage { get; }

    /// <summary>OpenAPI 管理</summary>
    public IMiniProgramOpenApiService OpenApi { get; }

    /// <summary>当前配置</summary>
    public WechatMiniProgramOptions Options { get; }

    private WechatMiniProgramClient(WechatMiniProgramOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        Options = options;
        _httpClient = httpClient;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
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
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static WechatMiniProgramClient Create(WechatMiniProgramOptions options, ILogger? logger = null)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WechatMiniProgramClient(options, httpClient, logger);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static WechatMiniProgramClient Create(WechatMiniProgramOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatMiniProgramClient(options, httpClient, logger);
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

    private static void ValidateOptions(WechatMiniProgramOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.AppId)) throw new ArgumentException("AppId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.AppSecret) &&
            (string.IsNullOrWhiteSpace(options.ShareSecret) || string.IsNullOrWhiteSpace(options.TokenShareUrl)))
        {
            throw new ArgumentException("AppSecret 不能为空，或者需要同时配置 ShareSecret 和 TokenShareUrl", nameof(options));
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
