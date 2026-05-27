using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// <see cref="WebhookServiceFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WebhookService"/>。
/// </summary>
internal sealed class WebhookServiceFactory(IServiceProvider serviceProvider) : IWebhookServiceFactory
{
    /// <summary>
    /// 按名称获取指定群机器人服务实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomWebHookService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WebhookService"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的群机器人服务未注册时抛出</exception>
    public WebhookService CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WebhookService>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的群机器人服务。请确认已调用 AddWecomWebHookService(\"{name}\", ...)。");
    }
}
