using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// <see cref="IWecomClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WecomClient"/>。
/// </summary>
internal sealed class WecomClientFactory(IServiceProvider serviceProvider) : IWecomClientFactory
{
    /// <inheritdoc/>
    public WecomClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WecomClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的企业微信客户端。请确认已调用 AddWecomService(\"{name}\", ...)。");
    }
}
