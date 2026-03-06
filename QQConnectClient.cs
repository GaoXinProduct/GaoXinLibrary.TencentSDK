using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;

namespace GaoXinLibrary.TencentSDK.Wechat;

/// <summary>
/// QQ 互联 SDK 主客户端
/// <para>
/// 使用示例：
/// <code>
/// var client = QQConnectClient.Create(new QQConnectOptions
/// {
///     AppId     = "your_qq_appid",
///     AppSecret = "your_qq_appkey"
/// });
/// var url = client.Login.BuildAuthUrl("https://example.com/callback");
/// </code>
/// </para>
/// </summary>
public sealed class QQConnectClient : IDisposable
{
    private readonly HttpClient _httpClient;

    /// <summary>QQ 登录服务</summary>
    public IQQConnectService Login { get; }

    /// <summary>当前配置</summary>
    public QQConnectOptions Options { get; }

    private QQConnectClient(QQConnectOptions options, HttpClient httpClient)
    {
        Options = options;
        _httpClient = httpClient;
        Login = new QQConnectService(httpClient, options);
    }

    /// <summary>
    /// 使用指定配置创建客户端实例
    /// </summary>
    public static QQConnectClient Create(QQConnectOptions options)
    {
        ValidateOptions(options);
        var httpClient = new HttpClient { Timeout = options.HttpTimeout };
        return new QQConnectClient(options, httpClient);
    }

    /// <summary>
    /// 使用已有 HttpClient 创建客户端实例
    /// </summary>
    public static QQConnectClient Create(QQConnectOptions options, HttpClient httpClient)
    {
        ValidateOptions(options);
        ArgumentNullException.ThrowIfNull(httpClient);
        return new QQConnectClient(options, httpClient);
    }

    private static void ValidateOptions(QQConnectOptions options)
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
