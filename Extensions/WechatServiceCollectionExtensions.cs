using System.Net.Http;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Wechat.Extensions;

/// <summary>
/// 微信 SDK 依赖注入扩展方法
/// <para>
/// <b>小程序</b>：
/// <code>
/// builder.Services.AddWechatMiniProgramService(options =>
/// {
///     options.AppId     = "your_appid";
///     options.AppSecret = "your_appsecret";
/// });
/// // 注入门面客户端，通过属性访问子服务：
/// public class MyService(WechatMiniProgramClient miniProgram) { ... }
/// </code>
///
/// <b>公众号</b>：
/// <code>
/// builder.Services.AddWechatOfficialService(options =>
/// {
///     options.AppId     = "your_appid";
///     options.AppSecret = "your_appsecret";
/// });
/// // 注入门面客户端，通过属性访问子服务：
/// public class MyService(WechatOfficialClient official) { ... }
/// </code>
///
/// <b>开放平台</b>：
/// <code>
/// builder.Services.AddWechatOpenService(options =>
/// {
///     options.AppId     = "your_appid";
///     options.AppSecret = "your_appsecret";
/// });
/// // 注入门面客户端，通过属性访问子服务：
/// public class MyService(WechatOpenClient open) { ... }
/// </code>
/// </para>
/// </summary>
public static class WechatServiceCollectionExtensions
{
    // ─── 小程序 ──────────────────────────────────────────────────────

    /// <summary>
    /// 注册微信小程序 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgramService(
        this IServiceCollection services,
        Action<WechatMiniProgramOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatMiniProgramOptions();
        configure(options);
        return services.AddWechatMiniProgramService(options);
    }

    /// <summary>
    /// 注册微信小程序 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgramService(
        this IServiceCollection services,
        WechatMiniProgramOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.TryAddSingleton<WechatMiniProgramClient>(sp =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WechatMiniProgramClient>();
            return WechatMiniProgramClient.Create(options, httpClient, logger);
        });

        return services;
    }

    /// <summary>
    /// 注册微信小程序 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgramService(
        this IServiceCollection services,
        string name,
        Action<WechatMiniProgramOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatMiniProgramOptions();
        configure(options);
        return services.AddWechatMiniProgramService(name, options);
    }

    /// <summary>
    /// 注册微信小程序 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgramService(
        this IServiceCollection services,
        string name,
        WechatMiniProgramOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        services.AddKeyedSingleton(name, options);

        services.AddKeyedSingleton<WechatMiniProgramClient>(name, (sp, _) =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WechatMiniProgramClient>();
            return WechatMiniProgramClient.Create(options, httpClient, logger);
        });

        // 注册工厂（幂等），使 MVC Controller 构造函数可通过工厂按名称解析 Keyed 实例
        services.TryAddSingleton<IWechatMiniProgramClientFactory, WechatMiniProgramClientFactory>();

        return services;
    }

    // ─── 公众号 ──────────────────────────────────────────────────────

    /// <summary>
    /// 注册微信公众号 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddWechatOfficialService(
        this IServiceCollection services,
        Action<WechatOfficialOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOfficialOptions();
        configure(options);
        return services.AddWechatOfficialService(options);
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddWechatOfficialService(
        this IServiceCollection services,
        WechatOfficialOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.TryAddSingleton<WechatOfficialClient>(sp =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WechatOfficialClient>();
            return WechatOfficialClient.Create(options, httpClient, logger);
        });

        // 回调服务：仅在配置了 CallbackToken 和 CallbackEncodingAesKey 时注册
        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            services.TryAddSingleton<IOfficialCallbackService>(sp => sp.GetRequiredService<WechatOfficialClient>().Callback);
        }

        return services;
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOfficialService(
        this IServiceCollection services,
        string name,
        Action<WechatOfficialOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOfficialOptions();
        configure(options);
        return services.AddWechatOfficialService(name, options);
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOfficialService(
        this IServiceCollection services,
        string name,
        WechatOfficialOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        services.AddKeyedSingleton(name, options);

        services.AddKeyedSingleton<WechatOfficialClient>(name, (sp, _) =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WechatOfficialClient>();
            return WechatOfficialClient.Create(options, httpClient, logger);
        });

        // 回调服务：仅在配置了 CallbackToken 和 CallbackEncodingAesKey 时注册（Keyed）
        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            services.AddKeyedSingleton<IOfficialCallbackService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Callback);
        }

        // 注册工厂（幂等），使 MVC Controller 构造函数可通过工厂按名称解析 Keyed 实例
        services.TryAddSingleton<IWechatOfficialClientFactory, WechatOfficialClientFactory>();

        return services;
    }

    // ─── 开放平台 ────────────────────────────────────────────────────

    /// <summary>
    /// 注册微信开放平台 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddWechatOpenService(
        this IServiceCollection services,
        Action<WechatOpenOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOpenOptions();
        configure(options);
        return services.AddWechatOpenService(options);
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddWechatOpenService(
        this IServiceCollection services,
        WechatOpenOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.TryAddSingleton<WechatOpenClient>(sp =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WechatOpenClient>();
            return WechatOpenClient.Create(options, httpClient, logger);
        });

        return services;
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOpenService(
        this IServiceCollection services,
        string name,
        Action<WechatOpenOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOpenOptions();
        configure(options);
        return services.AddWechatOpenService(name, options);
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOpenService(
        this IServiceCollection services,
        string name,
        WechatOpenOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        services.AddKeyedSingleton(name, options);

        services.AddKeyedSingleton<WechatOpenClient>(name, (sp, _) =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WechatOpenClient>();
            return WechatOpenClient.Create(options, httpClient, logger);
        });

        // 注册工厂（幂等），使 MVC Controller 构造函数可通过工厂按名称解析 Keyed 实例
        services.TryAddSingleton<IWechatOpenClientFactory, WechatOpenClientFactory>();

        return services;
    }

    // ─── QQ 互联 ─────────────────────────────────────────────────────────

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddQQConnectService(
        this IServiceCollection services,
        Action<QQConnectOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new QQConnectOptions();
        configure(options);
        return services.AddQQConnectService(options);
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddQQConnectService(
        this IServiceCollection services,
        QQConnectOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.TryAddSingleton<QQConnectClient>(sp =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            return QQConnectClient.Create(options, httpClient);
        });

        return services;
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddQQConnectService(
        this IServiceCollection services,
        string name,
        Action<QQConnectOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new QQConnectOptions();
        configure(options);
        return services.AddQQConnectService(name, options);
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddQQConnectService(
        this IServiceCollection services,
        string name,
        QQConnectOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        services.AddKeyedSingleton(name, options);

        services.AddKeyedSingleton<QQConnectClient>(name, (sp, _) =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            return QQConnectClient.Create(options, httpClient);
        });

        // 注册工厂（幂等），使 MVC Controller 构造函数可通过工厂按名称解析 Keyed 实例
        services.TryAddSingleton<IQQConnectClientFactory, QQConnectClientFactory>();

        return services;
    }

    // ─── IConfiguration 绑定 ────────────────────────────────────────────

    /// <summary>
    /// 注册微信小程序 SDK 服务（从 <see cref="IConfiguration"/> 绑定配置）
    /// <para>
    /// 用法示例：
    /// <code>
    /// builder.Services.AddWechatMiniProgramService(builder.Configuration.GetSection("WechatMiniProgram"));
    /// </code>
    /// </para>
    /// </summary>
    public static IServiceCollection AddWechatMiniProgramService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WechatMiniProgramOptions();
        configuration.Bind(options);
        return services.AddWechatMiniProgramService(options);
    }

    /// <summary>
    /// 注册微信小程序 SDK 服务（带 key，从 <see cref="IConfiguration"/> 绑定配置）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgramService(
        this IServiceCollection services,
        string name,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WechatMiniProgramOptions();
        configuration.Bind(options);
        return services.AddWechatMiniProgramService(name, options);
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（从 <see cref="IConfiguration"/> 绑定配置）
    /// <para>
    /// 用法示例：
    /// <code>
    /// builder.Services.AddWechatOfficialService(builder.Configuration.GetSection("WechatOfficial"));
    /// </code>
    /// </para>
    /// </summary>
    public static IServiceCollection AddWechatOfficialService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WechatOfficialOptions();
        configuration.Bind(options);
        return services.AddWechatOfficialService(options);
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（带 key，从 <see cref="IConfiguration"/> 绑定配置）
    /// </summary>
    public static IServiceCollection AddWechatOfficialService(
        this IServiceCollection services,
        string name,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WechatOfficialOptions();
        configuration.Bind(options);
        return services.AddWechatOfficialService(name, options);
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（从 <see cref="IConfiguration"/> 绑定配置）
    /// <para>
    /// 用法示例：
    /// <code>
    /// builder.Services.AddWechatOpenService(builder.Configuration.GetSection("WechatOpen"));
    /// </code>
    /// </para>
    /// </summary>
    public static IServiceCollection AddWechatOpenService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WechatOpenOptions();
        configuration.Bind(options);
        return services.AddWechatOpenService(options);
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（带 key，从 <see cref="IConfiguration"/> 绑定配置）
    /// </summary>
    public static IServiceCollection AddWechatOpenService(
        this IServiceCollection services,
        string name,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WechatOpenOptions();
        configuration.Bind(options);
        return services.AddWechatOpenService(name, options);
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（从 <see cref="IConfiguration"/> 绑定配置）
    /// <para>
    /// 用法示例：
    /// <code>
    /// builder.Services.AddQQConnectService(builder.Configuration.GetSection("QQConnect"));
    /// </code>
    /// </para>
    /// </summary>
    public static IServiceCollection AddQQConnectService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new QQConnectOptions();
        configuration.Bind(options);
        return services.AddQQConnectService(options);
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（带 key，从 <see cref="IConfiguration"/> 绑定配置）
    /// </summary>
    public static IServiceCollection AddQQConnectService(
        this IServiceCollection services,
        string name,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new QQConnectOptions();
        configuration.Bind(options);
        return services.AddQQConnectService(name, options);
    }

    // ─── 内部辅助 ──────────────────────────────────────────────────────

    /// <summary>
    /// 创建适合 Singleton 持有的长生命周期 HttpClient。
    /// 使用 SocketsHttpHandler.PooledConnectionLifetime 实现连接级 DNS 轮换，
    /// 从而避免 IHttpClientFactory Handler 轮换导致的 ObjectDisposedException。
    /// </summary>
    private static HttpClient CreateLongLivedHttpClient(TimeSpan timeout)
    {
        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        };
        return new HttpClient(handler, disposeHandler: false)
        {
            Timeout = timeout
        };
    }

    private static void ValidateOptions(WechatOptions options)
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
            throw new ArgumentException("WechatOptions.AppId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.AppSecret))
            throw new ArgumentException("WechatOptions.AppSecret 不能为空", nameof(options));
    }
}
