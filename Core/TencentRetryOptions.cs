namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 瞬态故障重试配置
/// <para>
/// 适用于网络抖动、连接超时、服务端 5xx 错误等临时性故障的自动重试。<br/>
/// Token 失效重试由 SDK 内部独立处理，不受此配置影响。
/// </para>
/// </summary>
public class TencentRetryOptions
{
    /// <summary>
    /// 最大重试次数（不含首次请求），默认 2 次
    /// <para>设置为 0 表示不进行重试。</para>
    /// </summary>
    public int MaxRetries { get; set; } = 2;

    /// <summary>
    /// 首次重试前的等待时间，默认 500 毫秒
    /// <para>后续重试将按指数退避递增（每次翻倍）。</para>
    /// </summary>
    public TimeSpan InitialDelay { get; set; } = TimeSpan.FromMilliseconds(500);

    /// <summary>
    /// 单次重试等待时间上限，默认 5 秒
    /// <para>指数退避不会超过此值。</para>
    /// </summary>
    public TimeSpan MaxDelay { get; set; } = TimeSpan.FromSeconds(5);
}
