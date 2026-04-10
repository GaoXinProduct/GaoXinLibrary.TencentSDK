using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GaoXinLibrary.TencentSDK.Wecom.Extensions;

/// <summary>
/// 企业微信群机器人 SDK 依赖注入扩展方法
/// <para>
/// <b>单实例用法</b>（无 key）：
/// <code>
/// builder.Services.AddWecomWebHookService(options =>
/// {
///     options.WebhookKey = "your_webhook_key";
/// });
/// // 注入：
/// public class MyService(IWebhookService webhook) { ... }
/// </code>
///
/// <b>多实例用法</b>（Keyed Services，.NET 8+）：
/// <code>
/// builder.Services.AddWecomWebHookService("bot1", opt => { opt.WebhookKey = "key1"; });
/// builder.Services.AddWecomWebHookService("bot2", opt => { opt.WebhookKey = "key2"; });
/// // 注入：
/// public class MyService(
///     [FromKeyedServices("bot1")] IWebhookService webhook1,
///     [FromKeyedServices("bot2")] IWebhookService webhook2) { ... }
/// </code>
/// </para>
/// <para>
/// 注意：群机器人（<see cref="IWebhookService"/>）不依赖 access_token，直接通过 Webhook Key 推送消息，
/// 无需提前调用 <see cref="WecomServiceCollectionExtensions.AddWecomService(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{WecomOptions})"/>。
/// </para>
/// </summary>
public static class WecomWebHookServiceCollectionExtensions
{
    // ─── AddWecomWebHookService 无 key（单实例） ─────────────────────────

    /// <summary>
    /// 注册企业微信群机器人服务（使用委托配置选项，无 key 单实例）
    /// <para>
    /// 仅注册 <see cref="IWebhookService"/>，使用 <see cref="WecomWebHookOptions.WebhookKey"/> 绑定目标群机器人，
    /// 注入后调用时无需再传入 Webhook Key。
    /// </para>
    /// </summary>
    public static IServiceCollection AddWecomWebHookService(
        this IServiceCollection services,
        Action<WecomWebHookOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomWebHookOptions();
        configure(options);
        return services.AddWecomWebHookService(options);
    }

    /// <summary>
    /// 注册企业微信群机器人服务（使用已有配置对象，无 key 单实例）
    /// </summary>
    public static IServiceCollection AddWecomWebHookService(
        this IServiceCollection services,
        WecomWebHookOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        services.TryAddSingleton(options);

        // 群机器人（注入时绑定固定 WebhookKey，调用时无需再传入）
        services.TryAddSingleton<IWebhookService>(_ =>
            new WebhookService(
                WecomServiceCollectionExtensions.CreateLongLivedHttpClient(TimeSpan.FromSeconds(30)),
                "https://qyapi.weixin.qq.com",
                options.WebhookKey ?? string.Empty));

        return services;
    }

    // ─── AddWecomWebHookService 带 key（多实例，Keyed Services） ─────────

    /// <summary>
    /// 注册企业微信群机器人服务（带 key，使用委托配置选项）
    /// <para>支持多次调用以注册不同群机器人实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// </summary>
    public static IServiceCollection AddWecomWebHookService(
        this IServiceCollection services,
        string name,
        Action<WecomWebHookOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomWebHookOptions();
        configure(options);
        return services.AddWecomWebHookService(name, options);
    }

    /// <summary>
    /// 注册企业微信群机器人服务（带 key，使用已有配置对象）
    /// <para>支持多次调用以注册不同群机器人实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// </summary>
    public static IServiceCollection AddWecomWebHookService(
        this IServiceCollection services,
        string name,
        WecomWebHookOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(options);

        services.AddKeyedSingleton(name, options);

        // 群机器人（Keyed，注入时绑定固定 WebhookKey）
        services.AddKeyedSingleton<IWebhookService>(name, (_, _) =>
            new WebhookService(
                WecomServiceCollectionExtensions.CreateLongLivedHttpClient(TimeSpan.FromSeconds(30)),
                "https://qyapi.weixin.qq.com",
                options.WebhookKey ?? string.Empty));

        return services;
    }

    // ─── AddWecomWebHookService IConfiguration 绑定 ──────────────────────

    /// <summary>
    /// 注册企业微信群机器人服务（从 <see cref="IConfiguration"/> 绑定配置）
    /// <para>
    /// 用法示例：
    /// <code>
    /// builder.Services.AddWecomWebHookService(builder.Configuration.GetSection("WecomWebHook"));
    /// </code>
    /// appsettings.json 示例：
    /// <code>
    /// {
    ///   "WecomWebHook": {
    ///     "WebhookKey": "your_webhook_key"
    ///   }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public static IServiceCollection AddWecomWebHookService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WecomWebHookOptions();
        configuration.Bind(options);
        return services.AddWecomWebHookService(options);
    }

    /// <summary>
    /// 注册企业微信群机器人服务（带 key，从 <see cref="IConfiguration"/> 绑定配置）
    /// </summary>
    public static IServiceCollection AddWecomWebHookService(
        this IServiceCollection services,
        string name,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new WecomWebHookOptions();
        configuration.Bind(options);
        return services.AddWecomWebHookService(name, options);
    }
}
