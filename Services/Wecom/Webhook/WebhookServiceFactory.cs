using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// <see cref="IWebhookServiceFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="IWebhookService"/>。
/// </summary>
internal sealed class WebhookServiceFactory(IServiceProvider serviceProvider) : IWebhookServiceFactory
{
    /// <inheritdoc/>
    public IWebhookService CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<IWebhookService>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的群机器人服务。请确认已调用 AddWecomWebHookService(\"{name}\", ...)。");
    }
}
