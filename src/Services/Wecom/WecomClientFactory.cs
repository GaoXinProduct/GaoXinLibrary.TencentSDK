using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// <see cref="IWecomClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WecomClient"/>。
/// </summary>
internal sealed class WecomClientFactory(IServiceProvider serviceProvider) : IWecomClientFactory
{
    /// <summary>
    /// 按名称获取指定企业微信客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWecomService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WecomClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的企业微信服务未注册时抛出</exception>
    public WecomClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WecomClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的企业微信客户端。请确认已调用 AddWecomService(\"{name}\", ...)。");
    }
}
