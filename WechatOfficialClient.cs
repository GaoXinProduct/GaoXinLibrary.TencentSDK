using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;

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

    private WechatOfficialClient(WechatOfficialOptions options, HttpClient httpClient, bool ownsHttpClient, ILogger? logger = null)
    {
        Options = options;
        _httpClient = httpClient;
        _ownsHttpClient = ownsHttpClient;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        var http = new WechatHttpClient(httpClient, _tokenProvider, options, logger);

        _ticketProvider = new JsApiTicketProvider(http);
        _ticketProvider.OnTicketChanged = options.OnTicketChanged;

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

        // ─── 备服务器模式：挂载载荷接收回调，分发 Ticket 并回写 Options ──────────
        if (!string.IsNullOrWhiteSpace(options.SecretShareUrl))
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

    // ─── 统一共享密钥（主服务器调用） ─────────────────────────────────────────

    /// <summary>
    /// 获取统一共享密钥载荷（主服务器调用）
    /// <para>
    /// 将当前有效的 access_token、jsapi_ticket、AppId/AppSecret
    /// 打包为 <see cref="SharedSecretPayload"/>，使用 <see cref="WechatOfficialOptions.ShareSecret"/> 加密后返回。<br/>
    /// 建议在主服务器侧通过受保护的内部接口对外暴露此方法的返回值。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>加密后的统一共享密钥载荷</returns>
    /// <exception cref="InvalidOperationException">未配置 <see cref="WechatOfficialOptions.ShareSecret"/> 时抛出</exception>
    public async Task<SharedSecretResult> GetSharedSecretAsync(CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(Options.ShareSecret))
            throw new InvalidOperationException("获取统一共享密钥需配置 WechatOfficialOptions.ShareSecret");

        var payload = await _tokenProvider.BuildBasePayloadAsync(ct);

        payload.AppId = Options.AppId;
        payload.AppSecret = Options.AppSecret;

        // jsapi_ticket（可选，未缓存时不阻塞）
        try
        {
            payload.JsApiTicket = await _ticketProvider.GetTicketAsync(ct);
            payload.TicketExpiresIn = _ticketProvider.GetRemainingSeconds();
        }
        catch { /* 主服务器尚未获取过 jsapi_ticket 时忽略 */ }

        var key = TencentTokenCrypto.DeriveKey(Options.ShareSecret);
        var payloadJson = JsonSerializer.Serialize(payload);
        var encrypted = TencentTokenCrypto.EncryptWithKey(payloadJson, key);

        return new SharedSecretResult { Data = encrypted };
    }

    private static void ValidateOptions(WechatOfficialOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        // 备服务器模式（SecretShareUrl 已配置）：无需 AppId / AppSecret
        if (!string.IsNullOrWhiteSpace(options.SecretShareUrl))
        {
            if (string.IsNullOrWhiteSpace(options.ShareSecret))
                throw new ArgumentException("配置 SecretShareUrl 时必须同时配置 ShareSecret", nameof(options));
            return;
        }

        if (string.IsNullOrWhiteSpace(options.AppId))
            throw new ArgumentException("AppId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.AppSecret))
            throw new ArgumentException("AppSecret 不能为空", nameof(options));
    }

    public void Dispose()
    {
        if (_ownsHttpClient)
            _httpClient.Dispose();
    }
}
