using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// <see cref="IWecomSmartBotServiceFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析智能机器人服务。
/// </summary>
internal sealed class WecomSmartBotServiceFactory(IServiceProvider serviceProvider) : IWecomSmartBotServiceFactory
{
    /// <summary>
    /// 按名称获取指定智能机器人 API 服务实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomSmartBotService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="SmartRobotService"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的智能机器人服务未注册时抛出</exception>
    public SmartRobotService CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<SmartRobotService>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的智能机器人服务。请确认已调用 AddWecomSmartBotService(\"{name}\", ...)。");
    }

    /// <summary>
    /// 按名称获取指定智能机器人 WebSocket 长连接客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomSmartBotService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="ISmartRobotWsClient"/> 实例，若未配置 BotId/BotSecret 则返回 <see langword="null"/></returns>
    public ISmartRobotWsClient? CreateWsClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        // 未配置 BotId/BotSecret 时不注册，返回 null 而非抛出
        return serviceProvider.GetKeyedService<ISmartRobotWsClient>(name);
    }
}
