using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GaoXinLibrary.TencentSDK.Wechat.Extensions;

/// <summary>
/// 微信 SDK 依赖注入扩展方法
/// <para>
/// <b>小程序</b>：
/// <code>
/// builder.Services.AddWechatMiniProgram(options =>
/// {
///     options.AppId     = "your_appid";
///     options.AppSecret = "your_appsecret";
/// });
/// // 注入：
/// public class MyService(IMiniProgramAuthService auth) { ... }
/// </code>
///
/// <b>公众号</b>：
/// <code>
/// builder.Services.AddWechatOfficial(options =>
/// {
///     options.AppId     = "your_appid";
///     options.AppSecret = "your_appsecret";
/// });
/// // 注入：
/// public class MyService(IOfficialOAuthService oauth) { ... }
/// </code>
///
/// <b>开放平台</b>：
/// <code>
/// builder.Services.AddWechatOpen(options =>
/// {
///     options.AppId     = "your_appid";
///     options.AppSecret = "your_appsecret";
/// });
/// // 注入：
/// public class MyService(IOpenPlatformService webLogin) { ... }
/// </code>
/// </para>
/// </summary>
public static class WechatServiceCollectionExtensions
{
    // ─── 小程序 ──────────────────────────────────────────────────────

    /// <summary>
    /// 注册微信小程序 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgram(
        this IServiceCollection services,
        Action<WechatMiniProgramOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatMiniProgramOptions();
        configure(options);
        return services.AddWechatMiniProgram(options);
    }

    /// <summary>
    /// 注册微信小程序 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgram(
        this IServiceCollection services,
        WechatMiniProgramOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.AddHttpClient(TencentConstants.MiniProgramHttpClientName, client =>
        {
            client.Timeout = options.HttpTimeout;
        });

        services.TryAddSingleton<WechatMiniProgramClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(TencentConstants.MiniProgramHttpClientName);
            return WechatMiniProgramClient.Create(options, httpClient);
        });

        services.TryAddSingleton<IMiniProgramAuthService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Auth);
        services.TryAddSingleton<IMiniProgramQrCodeService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().QrCode);
        services.TryAddSingleton<IMiniProgramSubscribeMessageService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().SubscribeMessage);
        services.TryAddSingleton<IMiniProgramSecurityService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Security);
        services.TryAddSingleton<IMiniProgramShippingService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Shipping);
        services.TryAddSingleton<IMiniProgramOcrService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Ocr);
        services.TryAddSingleton<IMiniProgramLinkService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Link);
        services.TryAddSingleton<IMiniProgramDataAnalysisService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().DataAnalysis);
        services.TryAddSingleton<IMiniProgramExpressService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Express);
        services.TryAddSingleton<IMiniProgramOperationService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Operation);
        services.TryAddSingleton<IMiniProgramDeviceService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().Device);
        services.TryAddSingleton<IMiniProgramCustomMessageService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().CustomMessage);
        services.TryAddSingleton<IMiniProgramOpenApiService>(sp => sp.GetRequiredService<WechatMiniProgramClient>().OpenApi);

        return services;
    }

    /// <summary>
    /// 注册微信小程序 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgram(
        this IServiceCollection services,
        string name,
        Action<WechatMiniProgramOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatMiniProgramOptions();
        configure(options);
        return services.AddWechatMiniProgram(name, options);
    }

    /// <summary>
    /// 注册微信小程序 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatMiniProgram(
        this IServiceCollection services,
        string name,
        WechatMiniProgramOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        var httpClientName = $"{TencentConstants.MiniProgramHttpClientName}.{name}";

        services.AddKeyedSingleton(name, options);
        services.AddHttpClient(httpClientName, client => { client.Timeout = options.HttpTimeout; });

        services.AddKeyedSingleton<WechatMiniProgramClient>(name, (sp, _) =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(httpClientName);
            return WechatMiniProgramClient.Create(options, httpClient);
        });

        services.AddKeyedSingleton<IMiniProgramAuthService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Auth);
        services.AddKeyedSingleton<IMiniProgramQrCodeService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).QrCode);
        services.AddKeyedSingleton<IMiniProgramSubscribeMessageService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).SubscribeMessage);
        services.AddKeyedSingleton<IMiniProgramSecurityService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Security);
        services.AddKeyedSingleton<IMiniProgramShippingService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Shipping);
        services.AddKeyedSingleton<IMiniProgramOcrService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Ocr);
        services.AddKeyedSingleton<IMiniProgramLinkService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Link);
        services.AddKeyedSingleton<IMiniProgramDataAnalysisService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).DataAnalysis);
        services.AddKeyedSingleton<IMiniProgramExpressService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Express);
        services.AddKeyedSingleton<IMiniProgramOperationService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Operation);
        services.AddKeyedSingleton<IMiniProgramDeviceService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).Device);
        services.AddKeyedSingleton<IMiniProgramCustomMessageService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).CustomMessage);
        services.AddKeyedSingleton<IMiniProgramOpenApiService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatMiniProgramClient>(key).OpenApi);

        return services;
    }

    // ─── 公众号 ──────────────────────────────────────────────────────

    /// <summary>
    /// 注册微信公众号 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddWechatOfficial(
        this IServiceCollection services,
        Action<WechatOfficialOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOfficialOptions();
        configure(options);
        return services.AddWechatOfficial(options);
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddWechatOfficial(
        this IServiceCollection services,
        WechatOfficialOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.AddHttpClient(TencentConstants.OfficialHttpClientName, client =>
        {
            client.Timeout = options.HttpTimeout;
        });

        services.TryAddSingleton<WechatOfficialClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(TencentConstants.OfficialHttpClientName);
            return WechatOfficialClient.Create(options, httpClient);
        });

        services.TryAddSingleton<IOfficialOAuthService>(sp => sp.GetRequiredService<WechatOfficialClient>().OAuth);
        services.TryAddSingleton<IOfficialMenuService>(sp => sp.GetRequiredService<WechatOfficialClient>().Menu);
        services.TryAddSingleton<IOfficialTemplateMessageService>(sp => sp.GetRequiredService<WechatOfficialClient>().TemplateMessage);
        services.TryAddSingleton<IOfficialUserService>(sp => sp.GetRequiredService<WechatOfficialClient>().User);
        services.TryAddSingleton<IOfficialMaterialService>(sp => sp.GetRequiredService<WechatOfficialClient>().Material);
        services.TryAddSingleton<IOfficialJsSdkService>(sp => sp.GetRequiredService<WechatOfficialClient>().JsSdk);
        services.TryAddSingleton<IOfficialTagService>(sp => sp.GetRequiredService<WechatOfficialClient>().Tag);
        services.TryAddSingleton<IOfficialDraftService>(sp => sp.GetRequiredService<WechatOfficialClient>().Draft);
        services.TryAddSingleton<IOfficialPublishService>(sp => sp.GetRequiredService<WechatOfficialClient>().Publish);
        services.TryAddSingleton<IOfficialCommentService>(sp => sp.GetRequiredService<WechatOfficialClient>().Comment);
        services.TryAddSingleton<IOfficialCustomMessageService>(sp => sp.GetRequiredService<WechatOfficialClient>().CustomMessage);
        services.TryAddSingleton<IOfficialMessageService>(sp => sp.GetRequiredService<WechatOfficialClient>().Message);
        services.TryAddSingleton<IOfficialDataAnalysisService>(sp => sp.GetRequiredService<WechatOfficialClient>().DataAnalysis);
        services.TryAddSingleton<IOfficialAiService>(sp => sp.GetRequiredService<WechatOfficialClient>().Ai);
        services.TryAddSingleton<IOfficialPoiService>(sp => sp.GetRequiredService<WechatOfficialClient>().Poi);
        services.TryAddSingleton<IOfficialOpenApiService>(sp => sp.GetRequiredService<WechatOfficialClient>().OpenApi);
        services.TryAddSingleton<IOfficialCallbackService>(sp => sp.GetRequiredService<WechatOfficialClient>().Callback);

        return services;
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOfficial(
        this IServiceCollection services,
        string name,
        Action<WechatOfficialOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOfficialOptions();
        configure(options);
        return services.AddWechatOfficial(name, options);
    }

    /// <summary>
    /// 注册微信公众号 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOfficial(
        this IServiceCollection services,
        string name,
        WechatOfficialOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        var httpClientName = $"{TencentConstants.OfficialHttpClientName}.{name}";

        services.AddKeyedSingleton(name, options);
        services.AddHttpClient(httpClientName, client => { client.Timeout = options.HttpTimeout; });

        services.AddKeyedSingleton<WechatOfficialClient>(name, (sp, _) =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(httpClientName);
            return WechatOfficialClient.Create(options, httpClient);
        });

        services.AddKeyedSingleton<IOfficialOAuthService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).OAuth);
        services.AddKeyedSingleton<IOfficialMenuService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Menu);
        services.AddKeyedSingleton<IOfficialTemplateMessageService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).TemplateMessage);
        services.AddKeyedSingleton<IOfficialUserService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).User);
        services.AddKeyedSingleton<IOfficialMaterialService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Material);
        services.AddKeyedSingleton<IOfficialJsSdkService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).JsSdk);
        services.AddKeyedSingleton<IOfficialTagService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Tag);
        services.AddKeyedSingleton<IOfficialDraftService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Draft);
        services.AddKeyedSingleton<IOfficialPublishService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Publish);
        services.AddKeyedSingleton<IOfficialCommentService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Comment);
        services.AddKeyedSingleton<IOfficialCustomMessageService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).CustomMessage);
        services.AddKeyedSingleton<IOfficialMessageService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Message);
        services.AddKeyedSingleton<IOfficialDataAnalysisService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).DataAnalysis);
        services.AddKeyedSingleton<IOfficialAiService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Ai);
        services.AddKeyedSingleton<IOfficialPoiService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Poi);
        services.AddKeyedSingleton<IOfficialOpenApiService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).OpenApi);
        services.AddKeyedSingleton<IOfficialCallbackService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOfficialClient>(key).Callback);

        return services;
    }

    // ─── 开放平台 ────────────────────────────────────────────────────

    /// <summary>
    /// 注册微信开放平台 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddWechatOpen(
        this IServiceCollection services,
        Action<WechatOpenOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOpenOptions();
        configure(options);
        return services.AddWechatOpen(options);
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddWechatOpen(
        this IServiceCollection services,
        WechatOpenOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.AddHttpClient(TencentConstants.OpenHttpClientName, client =>
        {
            client.Timeout = options.HttpTimeout;
        });

        services.TryAddSingleton<WechatOpenClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(TencentConstants.OpenHttpClientName);
            return WechatOpenClient.Create(options, httpClient);
        });

        services.TryAddSingleton<IOpenPlatformService>(sp => sp.GetRequiredService<WechatOpenClient>().WebLogin);

        return services;
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOpen(
        this IServiceCollection services,
        string name,
        Action<WechatOpenOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new WechatOpenOptions();
        configure(options);
        return services.AddWechatOpen(name, options);
    }

    /// <summary>
    /// 注册微信开放平台 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddWechatOpen(
        this IServiceCollection services,
        string name,
        WechatOpenOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        var httpClientName = $"{TencentConstants.OpenHttpClientName}.{name}";

        services.AddKeyedSingleton(name, options);
        services.AddHttpClient(httpClientName, client => { client.Timeout = options.HttpTimeout; });

        services.AddKeyedSingleton<WechatOpenClient>(name, (sp, _) =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(httpClientName);
            return WechatOpenClient.Create(options, httpClient);
        });

        services.AddKeyedSingleton<IOpenPlatformService>(name, (sp, key) => sp.GetRequiredKeyedService<WechatOpenClient>(key).WebLogin);

        return services;
    }

    // ─── QQ 互联 ─────────────────────────────────────────────────────────

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（使用委托配置选项）
    /// </summary>
    public static IServiceCollection AddQQConnect(
        this IServiceCollection services,
        Action<QQConnectOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        var options = new QQConnectOptions();
        configure(options);
        return services.AddQQConnect(options);
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（使用已有配置对象）
    /// </summary>
    public static IServiceCollection AddQQConnect(
        this IServiceCollection services,
        QQConnectOptions options)
    {
        ValidateOptions(options);

        services.TryAddSingleton(options);

        services.AddHttpClient(TencentConstants.QQConnectHttpClientName, client =>
        {
            client.Timeout = options.HttpTimeout;
        });

        services.TryAddSingleton<QQConnectClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(TencentConstants.QQConnectHttpClientName);
            return QQConnectClient.Create(options, httpClient);
        });

        services.TryAddSingleton<IQQConnectService>(sp => sp.GetRequiredService<QQConnectClient>().Login);

        return services;
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddQQConnect(
        this IServiceCollection services,
        string name,
        Action<QQConnectOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);
        var options = new QQConnectOptions();
        configure(options);
        return services.AddQQConnect(name, options);
    }

    /// <summary>
    /// 注册 QQ 互联 SDK 服务（带 key，多实例）
    /// </summary>
    public static IServiceCollection AddQQConnect(
        this IServiceCollection services,
        string name,
        QQConnectOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        var httpClientName = $"{TencentConstants.QQConnectHttpClientName}.{name}";

        services.AddKeyedSingleton(name, options);
        services.AddHttpClient(httpClientName, client => { client.Timeout = options.HttpTimeout; });

        services.AddKeyedSingleton<QQConnectClient>(name, (sp, _) =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(httpClientName);
            return QQConnectClient.Create(options, httpClient);
        });

        services.AddKeyedSingleton<IQQConnectService>(name, (sp, key) => sp.GetRequiredKeyedService<QQConnectClient>(key).Login);

        return services;
    }

    // ─── 内部辅助 ──────────────────────────────────────────────────────

    private static void ValidateOptions(WechatOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.AppId))
            throw new ArgumentException("WechatOptions.AppId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.AppSecret))
            throw new ArgumentException("WechatOptions.AppSecret 不能为空", nameof(options));
    }
}
