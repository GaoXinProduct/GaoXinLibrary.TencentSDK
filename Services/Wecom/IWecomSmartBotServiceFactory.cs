namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 企业微信智能机器人服务工厂接口
/// <para>
/// 当通过 <c>AddWecomSmartBotService(name, ...)</c> 注册了多个具名智能机器人实例时，
/// 可通过此工厂在 <b>MVC Controller 构造函数</b>或普通服务中按名称获取对应的服务实例。
/// </para>
/// <para>
/// 适用场景：MVC Controller 构造函数不支持 <c>[FromKeyedServices]</c>，注入工厂后通过对应方法按名称解析实例。
/// </para>
/// <example>
/// <b>注册（Program.cs）：</b>
/// <code>
/// builder.Services.AddWecomSmartBotService("bot1", opt => { opt.BotId = "id1"; opt.BotSecret = "sec1"; ... });
/// builder.Services.AddWecomSmartBotService("bot2", opt => { opt.BotId = "id2"; opt.BotSecret = "sec2"; ... });
/// </code>
///
/// <b>注入（MVC Controller）：</b>
/// <code>
/// public class MyController(IWecomSmartBotServiceFactory botFactory) : ControllerBase
/// {
///     private readonly SmartRobotService _robot1 = botFactory.CreateClient("bot1");
///     private readonly ISmartRobotWsClient _ws1   = botFactory.CreateWsClient("bot1");
/// }
/// </code>
/// </example>
/// </summary>
public interface IWecomSmartBotServiceFactory
{
    /// <summary>
    /// 按名称获取指定智能机器人 API 服务实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomSmartBotService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="SmartRobotService"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的智能机器人服务未注册时抛出</exception>
    SmartRobotService CreateClient(string name);

    /// <summary>
    /// 按名称获取指定智能机器人 WebSocket 长连接客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomSmartBotService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="ISmartRobotWsClient"/> 实例，若未配置 BotId/BotSecret 则返回 <see langword="null"/></returns>
    ISmartRobotWsClient? CreateWsClient(string name);
}
