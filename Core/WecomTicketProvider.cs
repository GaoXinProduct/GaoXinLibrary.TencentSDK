using System.Text.Json;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信 JS-SDK Ticket 获取与缓存管理（通用，可用于企业级和应用级 jsapi_ticket）
/// <para>
/// 提供线程安全的 Ticket 缓存、自动刷新、手动设置等能力。<br/>
/// 可选功能：
/// <list type="bullet">
///   <item>通过 <see cref="OnTicketChanged"/> 在 Ticket 刷新时获得通知（携带新 Ticket）。</item>
///   <item>通过 <see cref="ConfigureSharedTicket"/> 启用共享 Ticket 模式：
///     <list type="bullet">
///       <item>配置 <c>ShareSecret</c> 后，可用 <see cref="GetSharedTicketAsync"/> 对外暴露加密 Ticket。</item>
///       <item>同时配置 <c>ShareUrl</c> 后，刷新时将从该地址获取加密 Ticket 并自动解密，而非直接请求企业微信 API。</item>
///     </list>
///   </item>
/// </list>
/// </para>
/// </summary>
public class WecomTicketProvider
{
    private readonly Func<CancellationToken, Task<(string Ticket, int ExpiresIn)>> _fetchTicket;
    private readonly HttpClient _rawHttpClient;
    private string _cachedTicket = string.Empty;
    private DateTimeOffset _expireAt = DateTimeOffset.MinValue;
    private readonly SemaphoreSlim _lock = new(1, 1);

    // ─── 共享 Ticket ──────────────────────────────────────────────────────────
    private byte[]? _shareKey;
    private string? _ticketShareUrl;

    /// <summary>
    /// Ticket 变更通知回调
    /// <para>每次成功刷新 jsapi_ticket 后触发，第一个参数为新的明文 ticket。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTicketChanged { get; set; }

    /// <summary>
    /// 初始化 Ticket 提供程序
    /// </summary>
    /// <param name="fetchTicket">从企业微信 API 获取 Ticket 的委托，返回 (ticket, expiresIn)</param>
    /// <param name="rawHttpClient">用于共享 Ticket 模式下请求远端地址的 HttpClient</param>
    public WecomTicketProvider(
        Func<CancellationToken, Task<(string Ticket, int ExpiresIn)>> fetchTicket,
        HttpClient rawHttpClient)
    {
        _fetchTicket = fetchTicket;
        _rawHttpClient = rawHttpClient;
    }

    /// <summary>
    /// 配置共享 Ticket 模式
    /// </summary>
    /// <param name="shareSecret">共享密钥（任意字符串，SHA-256 派生为 32 字节 key）</param>
    /// <param name="ticketShareUrl">远端共享 Ticket 地址；设置后将从此地址获取加密 Ticket 而非直接请求企业微信 API</param>
    public void ConfigureSharedTicket(string? shareSecret, string? ticketShareUrl)
    {
        if (!string.IsNullOrWhiteSpace(shareSecret))
            _shareKey = TencentTokenCrypto.DeriveKey(shareSecret);

        if (!string.IsNullOrWhiteSpace(ticketShareUrl))
            _ticketShareUrl = ticketShareUrl;
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

            string newTicket;
            int expiresInSeconds;

            if (_ticketShareUrl is not null)
            {
                // 从远端共享地址获取加密 Ticket
                if (_shareKey is null)
                    throw new InvalidOperationException(
                        "设置了 TicketShareUrl 但未配置 TicketShareSecret，无法解密共享 Ticket。");

                var response = await _rawHttpClient.GetStringAsync(_ticketShareUrl, ct);
                var result = JsonSerializer.Deserialize<SharedTicketEndpointResponse>(response)
                             ?? throw new TencentException("共享 Ticket 接口返回为空");

                if (string.IsNullOrEmpty(result.Token))
                    throw new TencentException("共享 Ticket 接口返回的 token 字段为空");

                newTicket = TencentTokenCrypto.DecryptWithKey(result.Token, _shareKey);
                expiresInSeconds = result.ExpiresIn > 0 ? result.ExpiresIn : 7200;
            }
            else
            {
                // 直接向企业微信 API 请求 Ticket
                var (ticket, expiresIn) = await _fetchTicket(ct);
                newTicket = ticket ?? throw new TencentException("jsapi_ticket 为空");
                expiresInSeconds = expiresIn;
            }

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

    /// <summary>
    /// 获取当前 jsapi_ticket 的共享加密形式（ChaCha20-Poly1305），同时附带剩余有效秒数
    /// <para>
    /// 供主服务对外暴露 Ticket 共享接口使用，需配置共享密钥。<br/>
    /// 返回的 <see cref="SharedTokenResult.ExpiresIn"/> 为主服务侧 Ticket 的剩余秒数，<br/>
    /// 备服务应将此值原样写入响应 JSON 的 <c>expires_in</c> 字段。
    /// </para>
    /// </summary>
    /// <exception cref="InvalidOperationException">未配置共享密钥时抛出</exception>
    public async Task<SharedTokenResult> GetSharedTicketAsync(CancellationToken ct = default)
    {
        if (_shareKey is null)
            throw new InvalidOperationException("未配置 TicketShareSecret，无法获取共享 Ticket。");

        var ticket = await GetTicketAsync(ct);
        var encrypted = TencentTokenCrypto.EncryptWithKey(ticket, _shareKey);
        var remainingSeconds = Math.Max(0, (int)(_expireAt - DateTimeOffset.UtcNow).TotalSeconds);
        return new SharedTokenResult(encrypted, remainingSeconds);
    }

    // ─── 私有响应模型 ─────────────────────────────────────────────────────────

    private sealed class SharedTicketEndpointResponse
    {
        [JsonPropertyName("token")] public string? Token { get; set; }
        [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
    }
}
