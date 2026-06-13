
namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信客户端配置基类
/// </summary>
public class WechatOptions
{
    /// <summary>应用 ID（AppID）</summary>
    public string AppId { get; set; } = string.Empty;

    /// <summary>应用密钥（AppSecret）</summary>
    public string AppSecret { get; set; } = string.Empty;

    /// <summary>API 基础地址，默认 https://api.weixin.qq.com</summary>
    public string BaseUrl { get; set; } = "https://api.weixin.qq.com";

    /// <summary>HTTP 请求超时时间，默认 30 秒</summary>
    public TimeSpan HttpTimeout { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Token 变更通知回调
    /// <para>每次成功刷新 access_token 后触发，参数为新的明文 access_token 及 CancellationToken。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

    #region 瞬态故障重试配置

    /// <summary>
    /// 瞬态故障重试配置（网络抖动、连接超时、5xx 等临时性故障）
    /// <para>
    /// 默认最多重试 2 次、指数退避 500ms 起步。设为 <c>null</c> 或 <c>MaxRetries = 0</c> 禁用重试。<br/>
    /// Token 失效重试由 SDK 内部独立处理，不受此配置影响。
    /// </para>
    /// </summary>
    public TencentRetryOptions? RetryOptions { get; set; } = new();
    #endregion
}
