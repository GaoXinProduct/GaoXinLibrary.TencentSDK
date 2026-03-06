using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;

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

    /// <summary>网站应用微信登录</summary>
    public IOpenPlatformService WebLogin { get; }

    /// <summary>当前配置</summary>
    public WechatOpenOptions Options { get; }

    private WechatOpenClient(WechatOpenOptions options, HttpClient httpClient)
    {
        Options = options;
        _httpClient = httpClient;
        // 开放平台网站登录不需要 access_token 自动获取，使用 SNS 接口
        var tokenProvider = new AccessTokenProvider(options, httpClient);
        var http = new WechatHttpClient(httpClient, tokenProvider, options);

        WebLogin = new OpenPlatformService(http, options);
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static WechatOpenClient Create(WechatOpenOptions options)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new WechatOpenClient(options, httpClient);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static WechatOpenClient Create(WechatOpenOptions options, HttpClient httpClient)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new WechatOpenClient(options, httpClient);
    }

    private static void ValidateOptions(WechatOpenOptions options)
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
