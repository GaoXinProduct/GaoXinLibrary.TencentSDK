using GaoXinLibrary.TencentSDK.Core;
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
    private readonly AccessTokenProvider _tokenProvider;

    /// <summary>OAuth 网页授权</summary>
    public IOfficialOAuthService OAuth { get; }

    /// <summary>自定义菜单</summary>
    public IOfficialMenuService Menu { get; }

    /// <summary>模板消息</summary>
    public IOfficialTemplateMessageService TemplateMessage { get; }

    /// <summary>用户管理</summary>
    public IOfficialUserService User { get; }

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

    /// <summary>OpenAPI 管理</summary>
    public IOfficialOpenApiService OpenApi { get; }

    /// <summary>消息回调</summary>
    public IOfficialCallbackService Callback { get; }

    /// <summary>当前配置</summary>
    public WechatOfficialOptions Options { get; }

    private WechatOfficialClient(WechatOfficialOptions options, HttpClient httpClient)
    {
        Options = options;
        _httpClient = httpClient;
        _tokenProvider = new AccessTokenProvider(options, httpClient);
        var http = new WechatHttpClient(httpClient, _tokenProvider, options);

        OAuth = new OfficialOAuthService(http, options);
        Menu = new OfficialMenuService(http);
        TemplateMessage = new OfficialTemplateMessageService(http);
        User = new OfficialUserService(http);
        Material = new OfficialMaterialService(http);
        JsSdk = new OfficialJsSdkService(http, options.AppId);
        Tag = new OfficialTagService(http);
        Draft = new OfficialDraftService(http);
        Publish = new OfficialPublishService(http);
        Comment = new OfficialCommentService(http);
        CustomMessage = new OfficialCustomMessageService(http);
        Message = new OfficialMessageService(http);
        DataAnalysis = new OfficialDataAnalysisService(http);
        Ai = new OfficialAiService(http);
        Poi = new OfficialPoiService(http);
        OpenApi = new OfficialOpenApiService(http, options);
        Callback = new OfficialCallbackService(http, options);
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static WechatOfficialClient Create(WechatOfficialOptions options)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WechatOfficialClient(options, httpClient);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static WechatOfficialClient Create(WechatOfficialOptions options, HttpClient httpClient)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOfficialClient(options, httpClient);
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

    private static void ValidateOptions(WechatOfficialOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.AppId)) throw new ArgumentException("AppId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.AppSecret)) throw new ArgumentException("AppSecret 不能为空", nameof(options));
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
