using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GaoXinLibrary.TencentSDK.Wecom.Extensions;

/// <summary>
/// 企业微信 SDK 依赖注入扩展方法
/// <para>
/// <b>单实例用法</b>（无 key，向后兼容）：
/// <code>
/// builder.Services.AddWecom(options =>
/// {
///     options.CorpId     = "your_corpid";
///     options.CorpSecret = "your_corpsecret";
///     options.AgentId    = 1000001;
/// });
/// // 注入：
/// public class MyService(IMessageService message, IUserService user) { ... }
/// </code>
///
/// <b>多实例用法</b>（Keyed Services，.NET 8+）：
/// <code>
/// builder.Services.AddWecom("agent1", opt =>
/// {
///     opt.CorpId = "corp1"; opt.CorpSecret = "secret1"; opt.AgentId = 1000001;
/// });
/// builder.Services.AddWecom("agent2", opt =>
/// {
///     opt.CorpId = "corp1"; opt.CorpSecret = "secret2"; opt.AgentId = 1000002;
/// });
/// // 注入：
/// public class MyService(
///     [FromKeyedServices("agent1")] IMessageService msg1,
///     [FromKeyedServices("agent2")] IMessageService msg2) { ... }
/// </code>
/// </para>
/// </summary>
public static class WecomServiceCollectionExtensions
{
    // ─── 无 key（单实例，向后兼容） ──────────────────────────────────────

    /// <summary>
    /// 注册企业微信 SDK 服务（使用委托配置选项，无 key 单实例）
    /// </summary>
    public static IServiceCollection AddWecom(
        this IServiceCollection services,
        Action<WecomOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomOptions();
        configure(options);
        return services.AddWecom(options);
    }

    /// <summary>
    /// 注册企业微信 SDK 服务（使用已有配置对象，无 key 单实例）
    /// </summary>
    public static IServiceCollection AddWecom(
        this IServiceCollection services,
        WecomOptions options)
    {
        ValidateOptions(options);

        // 注册配置
        services.TryAddSingleton(options);

        var httpClientName = TencentConstants.WecomHttpClientName;

        // 注册命名 HttpClient
        services.AddHttpClient(httpClientName, client =>
        {
            client.Timeout = options.HttpTimeout;
        });

        // 注册主客户端（单例）
        services.TryAddSingleton<WecomClient>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(httpClientName);
            return WecomClient.Create(options, httpClient);
        });

        // 注册各子服务接口
        services.TryAddSingleton<IUserService>(sp => sp.GetRequiredService<WecomClient>().User);
        services.TryAddSingleton<IDepartmentService>(sp => sp.GetRequiredService<WecomClient>().Department);
        services.TryAddSingleton<ITagService>(sp => sp.GetRequiredService<WecomClient>().Tag);
        services.TryAddSingleton<IMessageService>(sp => sp.GetRequiredService<WecomClient>().Message);
        services.TryAddSingleton<IWebhookService>(sp => sp.GetRequiredService<WecomClient>().Webhook);
        services.TryAddSingleton<IAgentService>(sp => sp.GetRequiredService<WecomClient>().Agent);
        services.TryAddSingleton<IMediaService>(sp => sp.GetRequiredService<WecomClient>().Media);
        services.TryAddSingleton<IGroupChatService>(sp => sp.GetRequiredService<WecomClient>().GroupChat);
        services.TryAddSingleton<IMenuService>(sp => sp.GetRequiredService<WecomClient>().Menu);
        services.TryAddSingleton<IOAuthService>(sp => sp.GetRequiredService<WecomClient>().OAuth);
        services.TryAddSingleton<ICallbackService>(sp => sp.GetRequiredService<WecomClient>().Callback);
        services.TryAddSingleton<ISmartRobotService>(sp => sp.GetRequiredService<WecomClient>().SmartRobot);
        services.TryAddSingleton<ICorpGroupService>(sp => sp.GetRequiredService<WecomClient>().CorpGroup);
        services.TryAddSingleton<ILinkedCorpService>(sp => sp.GetRequiredService<WecomClient>().LinkedCorp);
        services.TryAddSingleton<IKfService>(sp => sp.GetRequiredService<WecomClient>().Kf);
        services.TryAddSingleton<IMsgAuditService>(sp => sp.GetRequiredService<WecomClient>().MsgAudit);
        services.TryAddSingleton<IJsSdkService>(sp => sp.GetRequiredService<WecomClient>().JsSdk);
        services.TryAddSingleton<ICheckinService>(sp => sp.GetRequiredService<WecomClient>().Checkin);
        services.TryAddSingleton<IApprovalService>(sp => sp.GetRequiredService<WecomClient>().Approval);
        services.TryAddSingleton<IExportService>(sp => sp.GetRequiredService<WecomClient>().Export);
        services.TryAddSingleton<IAsyncImportService>(sp => sp.GetRequiredService<WecomClient>().AsyncImport);
        services.TryAddSingleton<ISecondVerifyService>(sp => sp.GetRequiredService<WecomClient>().SecondVerify);
        services.TryAddSingleton<ISecurityService>(sp => sp.GetRequiredService<WecomClient>().Security);
        services.TryAddSingleton<IAdvancedAccountService>(sp => sp.GetRequiredService<WecomClient>().AdvancedAccount);
        services.TryAddSingleton<IOperationLogService>(sp => sp.GetRequiredService<WecomClient>().OperationLog);
        services.TryAddSingleton<IAccountIdService>(sp => sp.GetRequiredService<WecomClient>().AccountId);
        services.TryAddSingleton<IIpRangeService>(sp => sp.GetRequiredService<WecomClient>().IpRange);
        services.TryAddSingleton<IExternalContactService>(sp => sp.GetRequiredService<WecomClient>().ExternalContact);
        services.TryAddSingleton<ICorpPayService>(sp => sp.GetRequiredService<WecomClient>().CorpPay);
        services.TryAddSingleton<IEmailService>(sp => sp.GetRequiredService<WecomClient>().Email);
        services.TryAddSingleton<IDocumentService>(sp => sp.GetRequiredService<WecomClient>().Document);
        services.TryAddSingleton<ICalendarService>(sp => sp.GetRequiredService<WecomClient>().Calendar);
        services.TryAddSingleton<IMeetingService>(sp => sp.GetRequiredService<WecomClient>().Meeting);
        services.TryAddSingleton<IWedriveService>(sp => sp.GetRequiredService<WecomClient>().Wedrive);
        services.TryAddSingleton<ILivingService>(sp => sp.GetRequiredService<WecomClient>().Living);
        services.TryAddSingleton<IDialService>(sp => sp.GetRequiredService<WecomClient>().Dial);
        services.TryAddSingleton<IReportService>(sp => sp.GetRequiredService<WecomClient>().Report);
        services.TryAddSingleton<IHrService>(sp => sp.GetRequiredService<WecomClient>().Hr);
        services.TryAddSingleton<IMeetingRoomService>(sp => sp.GetRequiredService<WecomClient>().MeetingRoom);
        services.TryAddSingleton<IInvoiceService>(sp => sp.GetRequiredService<WecomClient>().Invoice);
        services.TryAddSingleton<ISmartSheetService>(sp => sp.GetRequiredService<WecomClient>().SmartSheet);
        services.TryAddSingleton<ICollectFormService>(sp => sp.GetRequiredService<WecomClient>().CollectForm);

        return services;
    }

    // ─── 带 key（多实例，Keyed Services） ──────────────────────────────

    /// <summary>
    /// 注册企业微信 SDK 服务（带 key，使用委托配置选项）
    /// <para>支持多次调用以注册不同 Agent / CorpSecret 实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// </summary>
    public static IServiceCollection AddWecom(
        this IServiceCollection services,
        string name,
        Action<WecomOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configure);

        var options = new WecomOptions();
        configure(options);
        return services.AddWecom(name, options);
    }

    /// <summary>
    /// 注册企业微信 SDK 服务（带 key，使用已有配置对象）
    /// <para>支持多次调用以注册不同 Agent / CorpSecret 实例，通过 <c>[FromKeyedServices("name")]</c> 注入。</para>
    /// </summary>
    public static IServiceCollection AddWecom(
        this IServiceCollection services,
        string name,
        WecomOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);
        ValidateOptions(options);

        var httpClientName = $"{TencentConstants.WecomHttpClientName}.{name}";

        // 注册配置（Keyed）
        services.AddKeyedSingleton(name, options);

        // 注册命名 HttpClient（每个 key 独立）
        services.AddHttpClient(httpClientName, client =>
        {
            client.Timeout = options.HttpTimeout;
        });

        // 注册主客户端（Keyed 单例）
        services.AddKeyedSingleton<WecomClient>(name, (sp, _) =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient(httpClientName);
            return WecomClient.Create(options, httpClient);
        });

        // 注册各子服务接口（Keyed），代理到同 key 的 WecomClient
        services.AddKeyedSingleton<IUserService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).User);
        services.AddKeyedSingleton<IDepartmentService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Department);
        services.AddKeyedSingleton<ITagService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Tag);
        services.AddKeyedSingleton<IMessageService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Message);
        services.AddKeyedSingleton<IWebhookService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Webhook);
        services.AddKeyedSingleton<IAgentService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Agent);
        services.AddKeyedSingleton<IMediaService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Media);
        services.AddKeyedSingleton<IGroupChatService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).GroupChat);
        services.AddKeyedSingleton<IMenuService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Menu);
        services.AddKeyedSingleton<IOAuthService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).OAuth);
        services.AddKeyedSingleton<ICallbackService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Callback);
        services.AddKeyedSingleton<ISmartRobotService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).SmartRobot);
        services.AddKeyedSingleton<ICorpGroupService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).CorpGroup);
        services.AddKeyedSingleton<ILinkedCorpService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).LinkedCorp);
        services.AddKeyedSingleton<IKfService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Kf);
        services.AddKeyedSingleton<IMsgAuditService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).MsgAudit);
        services.AddKeyedSingleton<IJsSdkService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).JsSdk);
        services.AddKeyedSingleton<ICheckinService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Checkin);
        services.AddKeyedSingleton<IApprovalService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Approval);
        services.AddKeyedSingleton<IExportService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Export);
        services.AddKeyedSingleton<IAsyncImportService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).AsyncImport);
        services.AddKeyedSingleton<ISecondVerifyService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).SecondVerify);
        services.AddKeyedSingleton<ISecurityService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Security);
        services.AddKeyedSingleton<IAdvancedAccountService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).AdvancedAccount);
        services.AddKeyedSingleton<IOperationLogService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).OperationLog);
        services.AddKeyedSingleton<IAccountIdService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).AccountId);
        services.AddKeyedSingleton<IIpRangeService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).IpRange);
        services.AddKeyedSingleton<IExternalContactService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).ExternalContact);
        services.AddKeyedSingleton<ICorpPayService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).CorpPay);
        services.AddKeyedSingleton<IEmailService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Email);
        services.AddKeyedSingleton<IDocumentService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Document);
        services.AddKeyedSingleton<ICalendarService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Calendar);
        services.AddKeyedSingleton<IMeetingService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Meeting);
        services.AddKeyedSingleton<IWedriveService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Wedrive);
        services.AddKeyedSingleton<ILivingService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Living);
        services.AddKeyedSingleton<IDialService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Dial);
        services.AddKeyedSingleton<IReportService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Report);
        services.AddKeyedSingleton<IHrService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Hr);
        services.AddKeyedSingleton<IMeetingRoomService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).MeetingRoom);
        services.AddKeyedSingleton<IInvoiceService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).Invoice);
        services.AddKeyedSingleton<ISmartSheetService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).SmartSheet);
        services.AddKeyedSingleton<ICollectFormService>(name, (sp, key) => sp.GetRequiredKeyedService<WecomClient>(key).CollectForm);

        return services;
    }

    // ─── 内部辅助 ──────────────────────────────────────────────────────

    private static void ValidateOptions(WecomOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        if (string.IsNullOrWhiteSpace(options.CorpId))
            throw new ArgumentException("WecomOptions.CorpId 不能为空", nameof(options));
        if (string.IsNullOrWhiteSpace(options.CorpSecret))
            throw new ArgumentException("WecomOptions.CorpSecret 不能为空", nameof(options));
    }
}
