using GaoXinLibrary.TencentSDK.Wechat;
using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// <see cref="IWechatMiniProgramClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WechatMiniProgramClient"/>。
/// </summary>
internal sealed class WechatMiniProgramClientFactory(IServiceProvider serviceProvider) : IWechatMiniProgramClientFactory
{
    /// <summary>
    /// 按名称获取指定微信小程序客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWechatMiniProgramService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WechatMiniProgramClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的小程序服务未注册时抛出</exception>
    public WechatMiniProgramClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WechatMiniProgramClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的微信小程序客户端。请确认已调用 AddWechatMiniProgramService(\"{name}\", ...)。");
    }
}
