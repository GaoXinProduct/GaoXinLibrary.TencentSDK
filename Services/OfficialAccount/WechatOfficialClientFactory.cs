using GaoXinLibrary.TencentSDK.Wechat;
using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// <see cref="IWechatOfficialClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WechatOfficialClient"/>。
/// </summary>
internal sealed class WechatOfficialClientFactory(IServiceProvider serviceProvider) : IWechatOfficialClientFactory
{
    /// <inheritdoc/>
    public WechatOfficialClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WechatOfficialClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的微信公众号客户端。请确认已调用 AddWechatOfficialService(\"{name}\", ...)。");
    }
}
