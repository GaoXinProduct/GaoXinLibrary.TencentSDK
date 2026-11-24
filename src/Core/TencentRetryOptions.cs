namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 瞬态故障重试配置
/// <para>
/// 适用于可重放的只读操作，覆盖网络抖动、连接超时、HTTP 408、429 及 5xx。<br/>
/// Token 失效重试由 SDK 独立处理。
/// </para>
/// </summary>
public sealed class TencentRetryOptions
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
