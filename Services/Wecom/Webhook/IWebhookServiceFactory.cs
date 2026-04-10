namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 群机器人（Webhook）服务工厂接口
/// <para>
/// 当通过 <c>AddWecomWebHookService(name, ...)</c> 注册了多个具名群机器人实例时，
/// 可通过此工厂在 <b>MVC Controller 构造函数</b>或普通服务中按名称获取对应的 <see cref="IWebhookService"/> 实例。
/// </para>
/// <para>
/// 适用场景：MVC Controller 构造函数不支持 <c>[FromKeyedServices]</c>，注入工厂后通过 <see cref="CreateClient"/> 解析指定实例。
/// </para>
/// <example>
/// <b>注册（Program.cs）：</b>
/// <code>
/// builder.Services.AddWecomWebHookService("bot1", opt => { opt.WebhookKey = "key1"; });
/// builder.Services.AddWecomWebHookService("bot2", opt => { opt.WebhookKey = "key2"; });
/// </code>
///
/// <b>注入（MVC Controller）：</b>
/// <code>
/// public class MyController(IWebhookServiceFactory webhookFactory)
/// {
///     private readonly IWebhookService _bot1 = webhookFactory.CreateClient("bot1");
///     private readonly IWebhookService _bot2 = webhookFactory.CreateClient("bot2");
/// }
/// </code>
/// </example>
/// </summary>
public interface IWebhookServiceFactory
{
    /// <summary>
    /// 按名称获取指定群机器人服务实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomWebHookService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="IWebhookService"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的群机器人服务未注册时抛出</exception>
    IWebhookService CreateClient(string name);
}
