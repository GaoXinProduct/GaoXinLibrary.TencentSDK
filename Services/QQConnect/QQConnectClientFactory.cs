using GaoXinLibrary.TencentSDK.Wechat;
using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// <see cref="IQQConnectClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="QQConnectClient"/>。
/// </summary>
internal sealed class QQConnectClientFactory(IServiceProvider serviceProvider) : IQQConnectClientFactory
{
    /// <inheritdoc/>
    public QQConnectClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<QQConnectClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的 QQ 互联客户端。请确认已调用 AddQQConnectService(\"{name}\", ...)。");
    }
}
