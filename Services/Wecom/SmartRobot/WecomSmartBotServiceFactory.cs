using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// <see cref="IWecomSmartBotServiceFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析智能机器人服务。
/// </summary>
internal sealed class WecomSmartBotServiceFactory(IServiceProvider serviceProvider) : IWecomSmartBotServiceFactory
{
    /// <inheritdoc/>
    public ISmartRobotService CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<ISmartRobotService>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的智能机器人服务。请确认已调用 AddWecomSmartBotService(\"{name}\", ...)。");
    }

    /// <inheritdoc/>
    public ISmartRobotWsClient? CreateWsClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        // 未配置 BotId/BotSecret 时不注册，返回 null 而非抛出
        return serviceProvider.GetKeyedService<ISmartRobotWsClient>(name);
    }
}
