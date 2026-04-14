using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Wecom.Extensions;

/// <summary>
/// 企业微信智能机器人 SDK 依赖注入扩展方法
/// <para>
/// <b>单实例用法</b>（无 key）：
/// <code>
/// builder.Services.AddWecomSmartBotService(options =>
/// {
///     options.CorpId                 = "your_corpid";
///     options.CorpSecret             = "your_corpsecret";
///     options.AgentId                = 1000001;
///     options.CallbackToken          = "your_token";          // 可选，启用回调
///     options.CallbackEncodingAesKey = "your_43char_key";     // 可选，启用回调
///     options.BotId                  = "your_bot_id";         // 可选，启用长连接
///     options.BotSecret              = "your_bot_secret";     // 可选，启用长连接
/// });
/// // 注入：
/// public class MyService(ISmartRobotService robot) { ... }
/// public class BotService(ISmartRobotWsClient wsClient) { ... }  // 仅当 BotId+BotSecret 均配置时可注入
/// </code>
///
/// <b>多实例用法</b>（Keyed Services，.NET 8+）：
/// <code>
/// builder.Services.AddWecomSmartBotService("bot1", opt => { opt.BotId = "id1"; opt.BotSecret = "sec1"; ... });
/// builder.Services.AddWecomSmartBotService("bot2", opt => { opt.BotId = "id2"; opt.BotSecret = "sec2"; ... });
/// // 注入：
/// public class MyService(
///     [FromKeyedServices("bot1")] ISmartRobotService robot1,
///     [FromKeyedServices("bot2")] ISmartRobotService robot2) { ... }
/// </code>
/// </para>
/// <para>
/// 注意：本方法内部会幂等地调用 <see cref="WecomServiceCollectionExtensions.AddWecomService(Microsoft.Extensions.DependencyInjection.IServiceCollection,WecomOptions)"/>，
/// 无需提前手动调用 <c>AddWecomService</c>。
/// <list type="bullet">
///   <item><see cref="ISmartRobotService"/>（API 模式）始终注册。</item>
///   <item><see cref="ISmartRobotWsClient"/>（WebSocket 长连接）仅当 <see cref="WecomSmartBotOptions.BotId"/> 与 <see cref="WecomSmartBotOptions.BotSecret"/> 均非空时注册。</item>
/// </list>
/// </para>
/// </summary>
public static class WecomSmartBotServiceCollectionExtensions
{
    // ─── AddWecomSmartBotService 无 key（单实例） ──────────────────────────

    /// <summary>
    /// 注册企业微信智能机器人服务（使用委托配置选项，无 key 单实例）
    /// </summary>
    public static IServiceCollection AddWecomSmartBotService(
        this IServiceCollection services,
        Action<WecomSmartBotOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomSmartBotOptions();
        configure(options);
        return services.AddWecomSmartBotService(options);
    }

    /// <summary>
    /// 注册企业微信智能机器人服务（使用已有配置对象，无 key 单实例）
    /// </summary>
    public static IServiceCollection AddWecomSmartBotService(
        this IServiceCollection services,
        WecomSmartBotOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        // 幂等注册底层 WecomClient 和核心子服务
        services.AddWecomService(ToWecomOptions(options));

        // 注册 WecomSmartBotOptions（WecomOptions 已由 AddWecomService 注册，此处注册子类型）
        services.TryAddSingleton(options);

        // 智能机器人 API 模式（始终注册）
        services.TryAddSingleton<ISmartRobotService>(sp =>
            new SmartRobotService(
                sp.GetRequiredService<WecomClient>().GetInternalHttpClient(),
                ToWecomOptions(options)));

        // 智能机器人长连接（仅当 BotId + BotSecret 均配置时注册）
        if (!string.IsNullOrWhiteSpace(options.BotId) && !string.IsNullOrWhiteSpace(options.BotSecret))
        {
            services.TryAddSingleton<ISmartRobotWsClient>(_ => new SmartRobotWsClient(options));
        }

        return services;
    }

    // ─── AddWecomSmartBotService 带 key（多实例，Keyed Services） ──────────

    /// <summary>
    /// 注册企业微信智能机器人服务（带 key，使用委托配置选项）
    /// <para>支持多次调用以注册不同智能机器人实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// </summary>
    public static IServiceCollection AddWecomSmartBotService(
        this IServiceCollection services,
        string name,
        Action<WecomSmartBotOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomSmartBotOptions();
        configure(options);
        return services.AddWecomSmartBotService(name, options);
    }

    /// <summary>
    /// 注册企业微信智能机器人服务（带 key，使用已有配置对象）
    /// <para>支持多次调用以注册不同智能机器人实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// </summary>
    public static IServiceCollection AddWecomSmartBotService(
        this IServiceCollection services,
        string name,
        WecomSmartBotOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(options);

        // 幂等注册底层 WecomClient 和核心子服务（Keyed）
        services.AddWecomService(name, ToWecomOptions(options));

        // 注册 WecomSmartBotOptions（Keyed）
        services.AddKeyedSingleton(name, options);

        // 智能机器人 API 模式（始终注册，Keyed）
        services.AddKeyedSingleton<ISmartRobotService>(name, (sp, key) =>
            new SmartRobotService(
                sp.GetRequiredKeyedService<WecomClient>(key).GetInternalHttpClient(),
                ToWecomOptions(options)));

        // 智能机器人长连接（仅当 BotId + BotSecret 均配置时注册，Keyed）
        if (!string.IsNullOrWhiteSpace(options.BotId) && !string.IsNullOrWhiteSpace(options.BotSecret))
        {
            services.AddKeyedSingleton<ISmartRobotWsClient>(name, (_, _) => new SmartRobotWsClient(options));
        }

        // 注册工厂（幂等），使 MVC Controller 构造函数可通过工厂按名称解析 Keyed 实例
        services.TryAddSingleton<IWecomSmartBotServiceFactory, WecomSmartBotServiceFactory>();

        return services;
    }

    // ─── AddWecomSmartBotService IConfiguration 绑定 ──────────────────────

    /// <summary>
    /// 注册企业微信智能机器人服务（从 <see cref="IConfiguration"/> 绑定配置）
    /// <para>
    /// 用法示例：
    /// <code>
    /// builder.Services.AddWecomSmartBotService(builder.Configuration.GetSection("WecomSmartBot"));
    /// </code>
    /// appsettings.json 示例：
    /// <code>
    /// {
    ///   "WecomSmartBot": {
    ///     "CorpId": "your_corpid",
    ///     "CorpSecret": "your_corpsecret",
    ///     "AgentId": 1000001,
    ///     "CallbackToken": "your_token",
    ///     "CallbackEncodingAesKey": "your_43char_key",
    ///     "BotId": "your_bot_id",
    ///     "BotSecret": "your_bot_secret"
    ///   }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public static IServiceCollection AddWecomSmartBotService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WecomSmartBotOptions();
        configuration.Bind(options);
        return services.AddWecomSmartBotService(options);
    }

    /// <summary>
    /// 注册企业微信智能机器人服务（带 key，从 <see cref="IConfiguration"/> 绑定配置）
    /// </summary>
    public static IServiceCollection AddWecomSmartBotService(
        this IServiceCollection services,
        string name,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WecomSmartBotOptions();
        configuration.Bind(options);
        return services.AddWecomSmartBotService(name, options);
    }

    private static WecomOptions ToWecomOptions(WecomSmartBotOptions o) => new()
    {
        CorpId                 = o.CorpId,
        CorpSecret             = o.CorpSecret,
        AgentId                = o.AgentId,
        BaseUrl                = o.BaseUrl,
        HttpTimeout            = o.HttpTimeout,
        CallbackToken          = o.CallbackToken,
        CallbackEncodingAesKey = o.CallbackEncodingAesKey,
    };
}
