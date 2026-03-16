using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;
using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Wechat;

/// <summary>
/// 微信开放平台 SDK 主客户端
/// <para>
/// 使用示例：
/// <code>
/// var client = WechatOpenClient.Create(new WechatOpenOptions
/// {
///     AppId     = "your_appid",
///     AppSecret = "your_appsecret"
/// });
/// var url = client.WebLogin.BuildAuthUrl("https://example.com/callback");
/// </code>
/// </para>
/// </summary>
public sealed class WechatOpenClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;

    /// <summary>网站应用微信登录</summary>
    public IOpenPlatformService WebLogin { get; }

    /// <summary>当前配置</summary>
    public WechatOpenOptions Options { get; }

    private WechatOpenClient(WechatOpenOptions options, HttpClient httpClient, bool ownsHttpClient, ILogger? logger = null)
    {
        Options = options;
        _httpClient = httpClient;
        _ownsHttpClient = ownsHttpClient;
        // 开放平台网站登录不需要 access_token 自动获取，使用 SNS 接口
        // AccessTokenProvider 仅作为 WechatHttpClient 构造参数传入，不会主动触发自动刷新
        var tokenProvider = new AccessTokenProvider(options, httpClient);
        var http = new WechatHttpClient(httpClient, tokenProvider, options, logger);

        WebLogin = new OpenPlatformService(http, options);
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static WechatOpenClient Create(WechatOpenOptions options, ILogger? logger = null)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WechatOpenClient(options, httpClient, ownsHttpClient: true, logger);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static WechatOpenClient Create(WechatOpenOptions options, HttpClient httpClient, ILogger? logger = null)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOpenClient(options, httpClient, ownsHttpClient: false, logger);
    }

    private static void ValidateOptions(WechatOpenOptions options)
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
        if (_ownsHttpClient)
            _httpClient.Dispose();
    }
}
