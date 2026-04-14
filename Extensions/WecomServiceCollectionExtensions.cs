using System.Net.Http;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Wecom.Extensions;

/// <summary>
/// 企业微信 SDK 核心服务依赖注入扩展方法
/// <para>
/// <b>单实例用法</b>（无 key）：
/// <code>
/// builder.Services.AddWecomService(options =>
/// {
///     options.CorpId     = "your_corpid";
///     options.CorpSecret = "your_corpsecret";
///     options.AgentId    = 1000001;
/// });
/// // 注入门面客户端，通过属性访问子服务：
/// public class MyService(WecomClient wecom) { ... }
/// </code>
///
/// <b>多实例用法</b>（Keyed Services，.NET 8+）：
/// <code>
/// builder.Services.AddWecomService("agent1", opt =>
/// {
///     opt.CorpId = "corp1"; opt.CorpSecret = "secret1"; opt.AgentId = 1000001;
/// });
/// builder.Services.AddWecomService("agent2", opt =>
/// {
///     opt.CorpId = "corp1"; opt.CorpSecret = "secret2"; opt.AgentId = 1000002;
/// });
/// // 注入工厂，通过名称获取对应客户端（推荐用于 MVC Controller）：
/// public class MyController(IWecomClientFactory factory) : ControllerBase
/// {
///     var agent1 = factory.CreateClient("agent1");
/// }
/// </code>
///
/// <b>群机器人</b>（可选，需额外调用）：
/// <code>
/// // 群机器人需调用 AddWecomWebHookService（位于 WecomWebHookServiceCollectionExtensions）
/// builder.Services.AddWecomWebHookService(options =>
/// {
///     options.WebhookKey = "your_webhook_key";
/// });
/// </code>
///
/// <b>消息回调</b>（可选，在 <see cref="WecomOptions"/> 中配置后自动注册）：
/// <code>
/// builder.Services.AddWecomService(options =>
/// {
///     options.CorpId                 = "your_corpid";
///     options.CorpSecret             = "your_corpsecret";
///     options.AgentId                = 1000001;
///     options.CallbackToken          = "your_token";        // 同时配置两项时自动注册 ICallbackService
///     options.CallbackEncodingAesKey = "your_43char_key";
/// });
/// // 注入回调服务（URL 验证/消息解密/加密回复）：
/// public class CallbackHandler(ICallbackService callback) { ... }
/// </code>
///
/// <b>智能机器人（含长连接）</b>（可选，需额外调用）：
/// <code>
/// // 智能机器人需调用 AddWecomSmartBotService（位于 WecomSmartBotServiceCollectionExtensions）
/// builder.Services.AddWecomSmartBotService(options =>
/// {
///     options.CorpId     = "your_corpid";
///     options.CorpSecret = "your_corpsecret";
///     options.AgentId    = 1000001;
///     options.BotId      = "your_bot_id";      // 可选，启用 SmartRobotWs
///     options.BotSecret  = "your_bot_secret";  // 可选，启用 SmartRobotWs
/// });
/// </code>
/// </para>
/// </summary>
public static class WecomServiceCollectionExtensions
{
    // ─── AddWecomService 无 key（单实例，向后兼容） ───────────────────────

    /// <summary>
    /// 注册企业微信 SDK 核心服务（使用委托配置选项，无 key 单实例）
    /// <para>
    /// 若 <see cref="WecomOptions.CallbackToken"/> 与 <see cref="WecomOptions.CallbackEncodingAesKey"/> 均非空，
    /// 则自动注册 <see cref="ICallbackService"/>（URL 验证/消息解密/加密回复）。<br/>
    /// 若需要群机器人（<see cref="IWebhookService"/>），请调用
    /// <c>AddWecomWebHookService</c>（位于 <c>WecomWebHookServiceCollectionExtensions</c>）。<br/>
    /// 若需要智能机器人（<see cref="ISmartRobotService"/>/<see cref="ISmartRobotWsClient"/>），
    /// 请调用 <c>AddWecomSmartBotService</c>（位于 <c>WecomSmartBotServiceCollectionExtensions</c>）。
    /// </para>
    /// </summary>
    public static IServiceCollection AddWecomService(
        this IServiceCollection services,
        Action<WecomOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomOptions();
        configure(options);
        return services.AddWecomService(options);
    }

    /// <summary>
    /// 注册企业微信 SDK 核心服务（使用已有配置对象，无 key 单实例）
    /// </summary>
    public static IServiceCollection AddWecomService(
        this IServiceCollection services,
        WecomOptions options)
    {
        ValidateOptions(options);

        // 注册配置
        services.TryAddSingleton(options);

        // 注册主客户端（单例）
        // 使用 SocketsHttpHandler + PooledConnectionLifetime 创建长生命周期 HttpClient，
        // 避免 IHttpClientFactory 因 Handler 轮换导致 Singleton 持有已释放的 HttpClient。
        services.TryAddSingleton<WecomClient>(sp =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WecomClient>();
            return WecomClient.Create(options, httpClient, logger);
        });

        // 回调服务（仅当 CallbackToken + CallbackEncodingAesKey 均配置时注册）
        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            services.TryAddSingleton<ICallbackService>(sp =>
                new CallbackService(
                    sp.GetRequiredService<WecomClient>().GetInternalHttpClient(),
                    options));
        }

        return services;
    }

    // ─── AddWecomService 带 key（多实例，Keyed Services） ────────────────

    /// <summary>
    /// 注册企业微信 SDK 核心服务（带 key，使用委托配置选项）
    /// <para>支持多次调用以注册不同 Agent / CorpSecret 实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// </summary>
    public static IServiceCollection AddWecomService(
        this IServiceCollection services,
        string name,
        Action<WecomOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomOptions();
        configure(options);
        return services.AddWecomService(name, options);
    }

    /// <summary>
    /// 注册企业微信 SDK 核心服务（带 key，使用已有配置对象）
    /// <para>支持多次调用以注册不同 Agent / CorpSecret 实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// <para>
    /// 若 <see cref="WecomOptions.CallbackToken"/> 与 <see cref="WecomOptions.CallbackEncodingAesKey"/> 均非空，
    /// 则自动注册对应 key 的 <see cref="ICallbackService"/>。
    /// </para>
    /// </summary>
    public static IServiceCollection AddWecomService(
        this IServiceCollection services,
        string name,
        WecomOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        // 注册配置（Keyed）
        services.AddKeyedSingleton(name, options);

        // 注册主客户端（Keyed 单例）
        // 使用 SocketsHttpHandler + PooledConnectionLifetime 创建长生命周期 HttpClient，
        // 避免 IHttpClientFactory 因 Handler 轮换导致 Singleton 持有已释放的 HttpClient。
        services.AddKeyedSingleton<WecomClient>(name, (sp, _) =>
        {
            var httpClient = CreateLongLivedHttpClient(options.HttpTimeout);
            var logger = sp.GetService<ILoggerFactory>()?.CreateLogger<WecomClient>();
            return WecomClient.Create(options, httpClient, logger);
        });

        // 回调服务（仅当 CallbackToken + CallbackEncodingAesKey 均配置时注册，Keyed）
        if (!string.IsNullOrWhiteSpace(options.CallbackToken) &&
            !string.IsNullOrWhiteSpace(options.CallbackEncodingAesKey))
        {
            services.TryAddKeyedSingleton<ICallbackService>(name, (sp, key) =>
                new CallbackService(
                    sp.GetRequiredKeyedService<WecomClient>(key).GetInternalHttpClient(),
                    options));
        }

        // 注册工厂（幂等），使 MVC Controller 构造函数可通过工厂按名称解析 Keyed 实例
        services.TryAddSingleton<IWecomClientFactory, WecomClientFactory>();

        return services;
    }

    // ─── AddWecomService IConfiguration 绑定 ────────────────────────────

    /// <summary>
    /// 注册企业微信 SDK 核心服务（从 <see cref="IConfiguration"/> 绑定配置）
    /// <para>
    /// 用法示例：
    /// <code>
    /// builder.Services.AddWecomService(builder.Configuration.GetSection("Wecom"));
    /// </code>
    /// appsettings.json 示例：
    /// <code>
    /// {
    ///   "Wecom": {
    ///     "CorpId": "your_corpid",
    ///     "CorpSecret": "your_corpsecret",
    ///     "AgentId": 1000001
    ///   }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public static IServiceCollection AddWecomService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WecomOptions();
        configuration.Bind(options);
        return services.AddWecomService(options);
    }

    /// <summary>
    /// 注册企业微信 SDK 核心服务（带 key，从 <see cref="IConfiguration"/> 绑定配置）
    /// </summary>
    public static IServiceCollection AddWecomService(
        this IServiceCollection services,
        string name,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WecomOptions();
        configuration.Bind(options);
        return services.AddWecomService(name, options);
    }

    // ─── 内部辅助 ──────────────────────────────────────────────────────

    /// <summary>
    /// 创建适合 Singleton 持有的长生命周期 HttpClient。
    /// 使用 SocketsHttpHandler.PooledConnectionLifetime 实现连接级 DNS 轮换，
    /// 从而避免 IHttpClientFactory Handler 轮换导致的 ObjectDisposedException。
    /// </summary>
    internal static HttpClient CreateLongLivedHttpClient(TimeSpan timeout)
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

    internal static void ValidateOptions(WecomOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        // 备服务器模式（SecretShareUrl 已配置）：无需 CorpId / CorpSecret
        if (!string.IsNullOrWhiteSpace(options.SecretShareUrl))
        {
            if (string.IsNullOrWhiteSpace(options.ShareSecret))
                throw new ArgumentException("配置 SecretShareUrl 时必须同时配置 ShareSecret", nameof(options));
            return;
        }

        if (string.IsNullOrWhiteSpace(options.CorpId))
            throw new ArgumentException("WecomOptions.CorpId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.CorpSecret))
            throw new ArgumentException("WecomOptions.CorpSecret 不能为空", nameof(options));
    }
}
