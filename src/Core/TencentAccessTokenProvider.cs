namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯平台 access_token 获取与缓存管理基类
/// <para>
/// 提供 Token 缓存、自动刷新、手动设置等能力。子类实现 <see cref="BuildTokenUrl"/> 提供平台特定逻辑。
/// 配置共享密钥后，备服务器从主服务器拉取加密的 <see cref="SharedSecretPayload"/>。
/// </para>
/// </summary>
public abstract class TencentAccessTokenProvider
{
    internal sealed record TokenSnapshot(string Value, DateTimeOffset ExpiresAt);
    private sealed record SharedSecretSettings(string Url, byte[] Key);

    private readonly HttpClient _httpClient;
    private readonly string? _platformName;
    private readonly SemaphoreSlim _lock = new(1, 1);
    private TokenSnapshot _cachedToken = new(string.Empty, DateTimeOffset.MinValue);
    private SharedSecretSettings? _sharedSecret;

    /// <summary>每次成功刷新 access_token 后触发，第一个参数为新的令牌。</summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

    /// <summary>备服务器成功从主服务器拉取并解密共享密钥载荷后触发。</summary>
    public Func<SharedSecretPayload, CancellationToken, Task>? OnSecretPayloadReceived { get; set; }

    /// <summary>初始化 Token 提供程序。</summary>
    protected TencentAccessTokenProvider(HttpClient httpClient, string? platformName = null)
    {
        _httpClient = httpClient;
        _platformName = platformName;
    }

    /// <summary>构建获取 access_token 的完整请求 URL。</summary>
    protected abstract string BuildTokenUrl();

    /// <summary>配置从主服务器拉取加密共享密钥载荷。</summary>
    /// <param name="secretShareUrl">主服务器的共享密钥接口。</param>
    /// <param name="shareSecret">与主服务器约定的共享密钥。</param>
    public void ConfigureSharedSecret(string secretShareUrl, string shareSecret)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(secretShareUrl);
        ArgumentException.ThrowIfNullOrWhiteSpace(shareSecret);
        Volatile.Write(ref _sharedSecret, new SharedSecretSettings(secretShareUrl, TencentTokenCrypto.DeriveKey(shareSecret)));
    }

    /// <summary>获取有效的 access_token，自动缓存并刷新。</summary>
    public async Task<string> GetTokenAsync(CancellationToken ct = default)
        => (await GetTokenSnapshotAsync(ct).ConfigureAwait(false)).Value;

    internal async Task<TokenSnapshot> GetTokenSnapshotAsync(CancellationToken ct)
    {
        var cached = Volatile.Read(ref _cachedToken);
        if (DateTimeOffset.UtcNow < cached.ExpiresAt)
            return cached;

        await _lock.WaitAsync(ct).ConfigureAwait(false);
        try
        {
            while (true)
            {
                cached = Volatile.Read(ref _cachedToken);
                if (DateTimeOffset.UtcNow < cached.ExpiresAt)
                    return cached;

                var settings = Volatile.Read(ref _sharedSecret);
                var payload = settings is null ? null : await FetchFromSharedSecretAsync(settings, ct).ConfigureAwait(false);
                var refreshed = payload is null
                    ? await FetchFromTencentApiAsync(ct).ConfigureAwait(false)
                    : new TokenSnapshot(payload.AccessToken!, DateTimeOffset.UtcNow.AddSeconds(Math.Max(payload.TokenExpiresIn - 60, 1)));

                // 请求期间显式设置或失效的缓存优先于这次拉取的结果。
                if (!ReferenceEquals(Interlocked.CompareExchange(ref _cachedToken, refreshed, cached), cached))
                    continue;

                if (OnTokenChanged is { } onTokenChanged)
                    await onTokenChanged(refreshed.Value, ct).ConfigureAwait(false);
                if (payload is not null && OnSecretPayloadReceived is { } onPayloadReceived)
                    await onPayloadReceived(payload, ct).ConfigureAwait(false);

                var current = Volatile.Read(ref _cachedToken);
                return DateTimeOffset.UtcNow < current.ExpiresAt ? current : refreshed;
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    internal Task<TokenSnapshot> RefreshRejectedTokenAsync(TokenSnapshot rejected, CancellationToken ct)
    {
        // 腾讯可能返回相同的 Token 字符串。快照引用用来识别请求实际使用的那一代缓存。
        Interlocked.CompareExchange(ref _cachedToken, new TokenSnapshot(string.Empty, DateTimeOffset.MinValue), rejected);
        return GetTokenSnapshotAsync(ct);
    }

    private async Task<TokenSnapshot> FetchFromTencentApiAsync(CancellationToken ct)
    {
        var result = await GetJsonAsync<AccessTokenResponse>(BuildTokenUrl(), "获取 access_token 返回为空", ct).ConfigureAwait(false);

        if (result.ErrCode != 0)
            throw new TencentException(result.ErrCode, result.ErrMsg ?? string.Empty, _platformName);
        if (string.IsNullOrWhiteSpace(result.AccessToken))
            throw new TencentException("access_token 为空");

        return new TokenSnapshot(result.AccessToken, DateTimeOffset.UtcNow.AddSeconds(result.ExpiresIn - 60));
    }

    private async Task<SharedSecretPayload> FetchFromSharedSecretAsync(SharedSecretSettings settings, CancellationToken ct)
    {
        var wrapper = await GetJsonAsync<SharedSecretWrapper>(settings.Url, "统一共享密钥接口返回为空", ct).ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(wrapper.Data))
            throw new TencentException("统一共享密钥接口返回 data 为空");

        var payloadJson = TencentTokenCrypto.DecryptWithKey(wrapper.Data, settings.Key);
        var payload = JsonSerializer.Deserialize<SharedSecretPayload>(payloadJson)
                      ?? throw new TencentException("统一共享密钥载荷解析失败");

        if (string.IsNullOrWhiteSpace(payload.AccessToken))
            throw new TencentException("统一共享密钥载荷中 access_token 为空");

        return payload;
    }

    private async Task<T> GetJsonAsync<T>(string url, string emptyResponseMessage, CancellationToken ct) where T : class
    {
        using var response = await _httpClient.GetAsync(url, ct).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(json) ?? throw new TencentException(emptyResponseMessage);
    }

    /// <summary>构建主服务器的共享密钥载荷，供客户端补充 Ticket 等字段后加密。</summary>
    protected internal async Task<SharedSecretPayload> BuildBasePayloadAsync(CancellationToken ct)
    {
        var token = await GetTokenSnapshotAsync(ct).ConfigureAwait(false);
        var remainingSeconds = Math.Max(0, (int)(token.ExpiresAt - DateTimeOffset.UtcNow).TotalSeconds);
        return new SharedSecretPayload
        {
            AccessToken = token.Value,
            TokenExpiresIn = remainingSeconds
        };
    }

    /// <summary>使缓存失效，下次获取令牌时重新拉取。</summary>
    public void InvalidateCache() => Volatile.Write(ref _cachedToken, new TokenSnapshot(string.Empty, DateTimeOffset.MinValue));

    /// <summary>判断腾讯平台通用的 Token 失效错误码。具体平台可能采用更精确的规则。</summary>
    public static bool IsTokenInvalidError(int errCode) => errCode is 40001 or 40014 or 42001;

    internal virtual bool IsRejectedTokenError(int errCode) => IsTokenInvalidError(errCode);

    /// <summary>立即重新获取 access_token 并更新缓存。</summary>
    public async Task<string> RefreshTokenAsync(CancellationToken ct = default)
    {
        InvalidateCache();
        return await GetTokenAsync(ct).ConfigureAwait(false);
    }

    /// <summary>从外部令牌服务手动写入 access_token。</summary>
    /// <param name="token">access_token 值。</param>
    /// <param name="expiresIn">有效期，默认 7200 秒，提前 60 秒刷新。</param>
    public void SetToken(string token, TimeSpan? expiresIn = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(token);
        var seconds = expiresIn?.TotalSeconds ?? 7200;
        Volatile.Write(ref _cachedToken, new TokenSnapshot(token, DateTimeOffset.UtcNow.AddSeconds(seconds - 60)));
    }

    private sealed class AccessTokenResponse
    {
        [JsonPropertyName("errcode")] public int ErrCode { get; set; }
        [JsonPropertyName("errmsg")] public string? ErrMsg { get; set; }
        [JsonPropertyName("access_token")] public string? AccessToken { get; set; }
        [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
    }

    private sealed class SharedSecretWrapper
    {
        [JsonPropertyName("data")] public string? Data { get; set; }
    }
}
