namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信备服务器共享密钥配置基类
/// </summary>
public class WechatShareOptions
{
    /// <summary>备服务器共享密钥</summary>
    public string ShareSecret { get; set; } = string.Empty;

    /// <summary>主服务器共享密钥载荷地址</summary>
    public string SecretShareUrl { get; set; } = string.Empty;

    /// <summary>API 基础地址，默认 https://api.weixin.qq.com</summary>
    public string BaseUrl { get; set; } = "https://api.weixin.qq.com";

    /// <summary>HTTP 请求超时时间，默认 30 秒</summary>
    public TimeSpan HttpTimeout { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>Token 变更通知回调</summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

    /// <summary>瞬态故障重试配置</summary>
    public TencentRetryOptions? RetryOptions { get; set; } = new();
}

/// <summary>
/// 微信公众号备服务器共享密钥配置
/// </summary>
public sealed class WechatOfficialShareOptions : WechatShareOptions
{
    /// <summary>Ticket 变更通知回调</summary>
    public Func<string, CancellationToken, Task>? OnTicketChanged { get; set; }
}

/// <summary>
/// 微信小程序备服务器共享密钥配置
/// </summary>
public sealed class WechatMiniProgramShareOptions : WechatShareOptions
{
}
