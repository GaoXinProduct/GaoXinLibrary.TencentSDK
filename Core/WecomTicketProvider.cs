using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信 JS-SDK Ticket 获取与缓存管理（通用，可用于企业级和应用级 jsapi_ticket）
/// <para>
/// 提供线程安全的 Ticket 缓存、自动刷新、手动设置等能力。<br/>
/// 可通过 <see cref="OnTicketChanged"/> 在 Ticket 刷新时获得通知（携带新 Ticket）。
/// </para>
/// </summary>
public class WecomTicketProvider
{
    private readonly Func<CancellationToken, Task<(string Ticket, int ExpiresIn)>> _fetchTicket;
    private string _cachedTicket = string.Empty;
    private DateTimeOffset _expireAt = DateTimeOffset.MinValue;
    private readonly SemaphoreSlim _lock = new(1, 1);

    /// <summary>
    /// Ticket 变更通知回调
    /// <para>每次成功刷新 jsapi_ticket 后触发，第一个参数为新的明文 ticket。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTicketChanged { get; set; }

    /// <summary>
    /// 初始化 Ticket 提供程序
    /// </summary>
    /// <param name="fetchTicket">从企业微信 API 获取 Ticket 的委托，返回 (ticket, expiresIn)</param>
    public WecomTicketProvider(
        Func<CancellationToken, Task<(string Ticket, int ExpiresIn)>> fetchTicket)
    {
        _fetchTicket = fetchTicket;
    }

    /// <summary>
    /// 获取有效的 jsapi_ticket（自动缓存与刷新）
    /// </summary>
    public async Task<string> GetTicketAsync(CancellationToken ct = default)
    {
        if (DateTimeOffset.UtcNow < _expireAt)
            return _cachedTicket;

        await _lock.WaitAsync(ct);
        try
        {
            if (DateTimeOffset.UtcNow < _expireAt)
                return _cachedTicket;

            var (ticket, expiresIn) = await _fetchTicket(ct);
            var newTicket = ticket ?? throw new TencentException("jsapi_ticket 为空");
            var expiresInSeconds = expiresIn;

            _cachedTicket = newTicket;
            _expireAt = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds - 60);

            if (OnTicketChanged is not null)
                await OnTicketChanged(newTicket, ct);

            return _cachedTicket;
        }
        finally
        {
            _lock.Release();
        }
    }

    /// <summary>使缓存失效（下次 GetTicketAsync 时自动重新获取）</summary>
    public void InvalidateCache() => _expireAt = DateTimeOffset.MinValue;

    /// <summary>获取当前 jsapi_ticket 的剩余有效秒数</summary>
    public int GetRemainingSeconds() => Math.Max(0, (int)(_expireAt - DateTimeOffset.UtcNow).TotalSeconds);

    /// <summary>
    /// 强制刷新 jsapi_ticket（立即请求新 Ticket 并更新缓存）
    /// </summary>
    public async Task<string> RefreshTicketAsync(CancellationToken ct = default)
    {
        InvalidateCache();
        return await GetTicketAsync(ct);
    }

    /// <summary>
    /// 手动设置 jsapi_ticket（适用于从外部服务获取 Ticket 的场景）
    /// </summary>
    /// <param name="ticket">jsapi_ticket 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（提前 60 秒过期以留出安全余量）</param>
    public void SetTicket(string ticket, TimeSpan? expiresIn = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ticket);
        _cachedTicket = ticket;
        var seconds = expiresIn?.TotalSeconds ?? 7200;
        _expireAt = DateTimeOffset.UtcNow.AddSeconds(seconds - 60);
    }
}
