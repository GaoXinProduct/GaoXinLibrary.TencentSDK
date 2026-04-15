using GaoXinLibrary.TencentSDK.Wechat;
using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// <see cref="IWechatOpenClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WechatOpenClient"/>。
/// </summary>
internal sealed class WechatOpenClientFactory(IServiceProvider serviceProvider) : IWechatOpenClientFactory
{
    /// <summary>
    /// 按名称获取指定微信开放平台客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWechatOpenService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WechatOpenClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的开放平台服务未注册时抛出</exception>
    public WechatOpenClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WechatOpenClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的微信开放平台客户端。请确认已调用 AddWechatOpenService(\"{name}\", ...)。");
    }
}
