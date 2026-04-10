using GaoXinLibrary.TencentSDK.Wechat;
using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// <see cref="IWechatMiniProgramClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WechatMiniProgramClient"/>。
/// </summary>
internal sealed class WechatMiniProgramClientFactory(IServiceProvider serviceProvider) : IWechatMiniProgramClientFactory
{
    /// <inheritdoc/>
    public WechatMiniProgramClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WechatMiniProgramClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的微信小程序客户端。请确认已调用 AddWechatMiniProgramService(\"{name}\", ...)。");
    }
}
