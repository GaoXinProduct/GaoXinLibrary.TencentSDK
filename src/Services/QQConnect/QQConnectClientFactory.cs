using GaoXinLibrary.TencentSDK.Wechat;
using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// <see cref="IQQConnectClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="QQConnectClient"/>。
/// </summary>
internal sealed class QQConnectClientFactory(IServiceProvider serviceProvider) : IQQConnectClientFactory
{
    /// <summary>
    /// 按名称获取指定 QQ 互联客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddQQConnectService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="QQConnectClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的 QQ 互联服务未注册时抛出</exception>
    public QQConnectClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<QQConnectClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的 QQ 互联客户端。请确认已调用 AddQQConnectService(\"{name}\", ...)。");
    }
}
