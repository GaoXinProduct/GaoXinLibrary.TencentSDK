using GaoXinLibrary.TencentSDK.Wechat;
using Microsoft.Extensions.DependencyInjection;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// <see cref="IWechatOfficialClientFactory"/> 的默认实现，通过 <see cref="IServiceProvider"/> 按名称解析 <see cref="WechatOfficialClient"/>。
/// </summary>
internal sealed class WechatOfficialClientFactory(IServiceProvider serviceProvider) : IWechatOfficialClientFactory
{
    /// <summary>
    /// 按名称获取指定微信公众号客户端实例
    /// </summary>
    /// <param name="name">注册时使用的名称（与 <c>AddWechatOfficialService(name, ...)</c> 中的 <c>name</c> 一致）</param>
    /// <returns>对应的 <see cref="WechatOfficialClient"/> 实例</returns>
    /// <exception cref="InvalidOperationException">指定名称的公众号服务未注册时抛出</exception>
    public WechatOfficialClient CreateClient(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return serviceProvider.GetKeyedService<WechatOfficialClient>(name)
            ?? throw new InvalidOperationException(
                $"未找到名称为 \"{name}\" 的微信公众号客户端。请确认已调用 AddWechatOfficialService(\"{name}\", ...)。");
    }
}
