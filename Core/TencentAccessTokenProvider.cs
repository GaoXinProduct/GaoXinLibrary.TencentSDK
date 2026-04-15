using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯平台 access_token 获取与缓存管理基类
/// <para>
/// 提供线程安全的 Token 缓存、自动刷新、手动设置等能力。<br/>
/// 子类仅需实现 <see cref="BuildTokenUrl"/> 提供平台特定逻辑。<br/>
/// 配置 <c>SecretShareUrl</c> 后进入备服务器模式，从主服务器拉取加密的 <see cref="SharedSecretPayload"/> 载荷。
/// </para>
/// </summary>
public abstract class TencentAccessTokenProvider
{
    private readonly HttpClient _httpClient;
    private readonly string? _platformName;
    private string _cachedToken = string.Empty;
    private DateTimeOffset _expireAt = DateTimeOffset.MinValue;
    private readonly SemaphoreSlim _lock = new(1, 1);

    #region 统一共享密钥（备服务器模式）
    private string? _secretShareUrl;
    private byte[]? _secretShareKey;

    /// <summary>
    /// Token 变更通知回调
    /// <para>每次成功刷新 access_token 后触发，第一个参数为新的明文 access_token。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

    /// <summary>
    /// 统一共享密钥载荷接收回调
    /// <para>
    /// 在备服务器模式下，每次成功拉取并解密 <see cref="SharedSecretPayload"/> 后触发。<br/>
    /// Client 构造时将此回调挂载到各 TicketProvider 的 <c>SetTicket</c>，以分发 jsapi_ticket。
    /// </para>
    /// </summary>
    public Func<SharedSecretPayload, CancellationToken, Task>? OnSecretPayloadReceived { get; set; }

    /// <summary>
    /// 初始化 Token 提供程序
    /// </summary>
    protected TencentAccessTokenProvider(HttpClient httpClient, string? platformName = null)
    {
        _httpClient = httpClient;
        _platformName = platformName;
    }

    /// <summary>
    /// 构建获取 access_token 的完整请求 URL
    /// </summary>
    protected abstract string BuildTokenUrl();

    /// <summary>
    /// 配置统一共享密钥模式（备服务器）
    /// <para>配置后 <see cref="GetTokenAsync"/> 将从 <paramref name="secretShareUrl"/> 拉取加密载荷，而非直接请求腾讯 API。</para>
    /// </summary>
    /// <param name="secretShareUrl">主服务器暴露的统一共享密钥接口地址</param>
    /// <param name="shareSecret">与主服务器约定的共享密钥</param>
    public void ConfigureSharedSecret(string secretShareUrl, string shareSecret)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(secretShareUrl);
        ArgumentException.ThrowIfNullOrWhiteSpace(shareSecret);
        _secretShareUrl = secretShareUrl;
        _secretShareKey = TencentTokenCrypto.DeriveKey(shareSecret);
    }

    /// <summary>
    /// 获取有效的 access_token（自动缓存与刷新）
    /// <para>备服务器模式下从主服务器拉取加密载荷；主服务器模式下直接请求腾讯 API。</para>
    /// </summary>
    public async Task<string> GetTokenAsync(CancellationToken ct = default)
    {
        if (DateTimeOffset.UtcNow < _expireAt)
            return _cachedToken;

        await _lock.WaitAsync(ct);
        try
        {
            if (DateTimeOffset.UtcNow < _expireAt)
                return _cachedToken;

            if (_secretShareUrl is not null && _secretShareKey is not null)
                return await FetchFromSharedSecretAsync(ct);

            return await FetchFromTencentApiAsync(ct);
        }
        finally
        {
            _lock.Release();
        }
    }

    #endregion
    #region 从腾讯 API 直接获取（主服务器模式）

    private async Task<string> FetchFromTencentApiAsync(CancellationToken ct)
    {
        var url = BuildTokenUrl();
        var response = await _httpClient.GetStringAsync(url, ct);
        var result = JsonSerializer.Deserialize<AccessTokenResponse>(response)
                     ?? throw new TencentException("获取 access_token 返回为空");

        if (result.ErrCode != 0)
            throw new TencentException(result.ErrCode, result.ErrMsg ?? string.Empty, _platformName);

        var newToken = result.AccessToken ?? throw new TencentException("access_token 为空");
        var expiresInSeconds = result.ExpiresIn;

        _cachedToken = newToken;
        _expireAt = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds - 60);

        if (OnTokenChanged is not null)
            await OnTokenChanged(newToken, ct);

        return _cachedToken;
    }

    #endregion
    #region 从主服务器拉取加密载荷（备服务器模式）

    private async Task<string> FetchFromSharedSecretAsync(CancellationToken ct)
    {
        var json = await _httpClient.GetStringAsync(_secretShareUrl!, ct);
        var wrapper = JsonSerializer.Deserialize<SharedSecretWrapper>(json)
                      ?? throw new TencentException("统一共享密钥接口返回为空");

        if (string.IsNullOrWhiteSpace(wrapper.Data))
            throw new TencentException("统一共享密钥接口返回 data 为空");

        var payloadJson = TencentTokenCrypto.DecryptWithKey(wrapper.Data, _secretShareKey!);
        var payload = JsonSerializer.Deserialize<SharedSecretPayload>(payloadJson)
                      ?? throw new TencentException("统一共享密钥载荷解析失败");

        if (string.IsNullOrWhiteSpace(payload.AccessToken))
            throw new TencentException("统一共享密钥载荷中 access_token 为空");

        _cachedToken = payload.AccessToken;
        _expireAt = DateTimeOffset.UtcNow.AddSeconds(Math.Max(payload.TokenExpiresIn - 60, 1));

        if (OnTokenChanged is not null)
            await OnTokenChanged(_cachedToken, ct);

        if (OnSecretPayloadReceived is not null)
            await OnSecretPayloadReceived(payload, ct);

        return _cachedToken;
    }

    /// <summary>
    /// 构建统一共享密钥载荷（主服务器调用）
    /// <para>
    /// 将当前有效的 access_token 及剩余有效期打包，供子类/Client 继续填充 Ticket 等字段后加密。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>已填充 Token 的 <see cref="SharedSecretPayload"/>（Ticket 字段由调用方填充）</returns>
    protected internal async Task<SharedSecretPayload> BuildBasePayloadAsync(CancellationToken ct)
    {
        var token = await GetTokenAsync(ct);
        var remainingSeconds = Math.Max(0, (int)(_expireAt - DateTimeOffset.UtcNow).TotalSeconds);
        return new SharedSecretPayload
        {
            AccessToken = token,
            TokenExpiresIn = remainingSeconds
        };
    }

    /// <summary>使缓存失效（下次 GetTokenAsync 时自动重新获取）</summary>
    public void InvalidateCache() => _expireAt = DateTimeOffset.MinValue;

    /// <summary>
    /// 判断错误码是否为 Token 无效/过期相关（40001/40014/42001）
    /// <para>当 API 返回这些错误码时，应自动失效缓存并重试。</para>
    /// </summary>
    public static bool IsTokenInvalidError(int errCode)
        => errCode is 40001 or 40014 or 42001;

    /// <summary>
    /// 强制刷新 access_token（立即请求新 Token 并更新缓存）
    /// </summary>
    public async Task<string> RefreshTokenAsync(CancellationToken ct = default)
    {
        InvalidateCache();
        return await GetTokenAsync(ct);
    }

    /// <summary>
    /// 手动设置 access_token（适用于从外部令牌服务获取 Token 的场景）
    /// </summary>
    /// <param name="token">access_token 值</param>
    /// <param name="expiresIn">有效期，默认 7200 秒（提前 60 秒过期以留出安全余量）</param>
    public void SetToken(string token, TimeSpan? expiresIn = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(token);
        _cachedToken = token;
        var seconds = expiresIn?.TotalSeconds ?? 7200;
        _expireAt = DateTimeOffset.UtcNow.AddSeconds(seconds - 60);
    }

    #endregion
    #region 私有响应模型

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
    #endregion
}
