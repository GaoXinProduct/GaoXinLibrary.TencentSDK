using System.Text.Json;
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 共享 Token 接口响应结果
/// <para>
/// 主服务调用 <see cref="TencentAccessTokenProvider.GetSharedTokenAsync"/> 后，
/// 将此结果序列化为 JSON 返回给备服务，备服务据此正确设置本地缓存过期时间。
/// </para>
/// </summary>
/// <param name="Token">ChaCha20-Poly1305 加密后的 access_token（Base64 格式）</param>
/// <param name="ExpiresIn">主服务侧 Token 的剩余有效秒数（备服务应以此值设置本地缓存）</param>
public sealed record SharedTokenResult(string Token, int ExpiresIn);

/// <summary>
/// 统一共享密钥接口响应结果
/// <para>
/// 主服务调用 <see cref="TencentAccessTokenProvider.GetSharedSecretAsync"/> 后，
/// 将此结果序列化为 JSON 返回给备服务。<br/>
/// 响应格式：<c>{"data":"BASE64加密数据"}</c>，密文解密后为 <see cref="SharedSecretPayload"/> JSON。
/// </para>
/// </summary>
/// <param name="Data">ChaCha20-Poly1305 加密后的 <see cref="SharedSecretPayload"/> JSON（Base64 格式）</param>
public sealed record SharedSecretResult(string Data);

/// <summary>
/// 腾讯平台 access_token 获取与缓存管理基类
/// <para>
/// 提供线程安全的 Token 缓存、自动刷新、手动设置等能力。<br/>
/// 子类仅需实现 <see cref="BuildTokenUrl"/> 提供平台特定逻辑。<br/>
/// 可选功能：
/// <list type="bullet">
///   <item>通过 <see cref="OnTokenChanged"/> 在 Token 刷新时获得通知（携带新 Token）。</item>
///   <item>通过 <see cref="ConfigureSharedToken"/> 启用共享 Token 模式：
///     <list type="bullet">
///       <item>配置 <c>ShareSecret</c> 后，可用 <see cref="GetSharedTokenAsync"/> 对外暴露加密 Token。</item>
///       <item>同时配置 <c>TokenShareUrl</c> 后，刷新时将从该地址获取加密 Token 并自动解密，而非直接请求腾讯 API。</item>
///     </list>
///   </item>
///   <item>通过 <see cref="ConfigureSharedToken(string?, string?, string?)"/> 启用统一共享密钥模式：
///     <list type="bullet">
///       <item>配置 <c>SecretShareUrl</c> 后，刷新时将从该地址获取加密的 <see cref="SharedSecretPayload"/> 并自动解密，
///         Token 自动缓存，其余字段通过 <see cref="OnSecretPayloadReceived"/> 回调分发。</item>
///       <item>主服务可用 <see cref="GetSharedSecretAsync"/> 对外暴露加密的统一密钥。</item>
///     </list>
///   </item>
/// </list>
/// </para>
/// </summary>
public abstract class TencentAccessTokenProvider
{
    private readonly HttpClient _httpClient;
    private readonly string? _platformName;
    private string _cachedToken = string.Empty;
    private DateTimeOffset _expireAt = DateTimeOffset.MinValue;
    private readonly SemaphoreSlim _lock = new(1, 1);

    // ─── 共享 Token / 统一共享密钥 ────────────────────────────────────────────
    private byte[]? _shareKey;
    private string? _tokenShareUrl;
    private string? _secretShareUrl;

    /// <summary>
    /// Token 变更通知回调
    /// <para>每次成功刷新 access_token 后触发，第一个参数为新的明文 access_token。</para>
    /// </summary>
    public Func<string, CancellationToken, Task>? OnTokenChanged { get; set; }

    /// <summary>
    /// 统一共享密钥载荷回调
    /// <para>
    /// 当使用 <c>SecretShareUrl</c> 模式时，每次从远端获取并解密 <see cref="SharedSecretPayload"/> 后触发。<br/>
    /// 上层客户端可通过此回调将 AppId、AppSecret、JsApiTicket 等分发给各子服务。
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
    /// 配置共享 Token 模式
    /// <para>
    /// 子类在构造函数中调用此方法，将 Options 中的 <c>ShareSecret</c> 和 <c>TokenShareUrl</c> 透传。
    /// </para>
    /// </summary>
    /// <param name="shareSecret">共享密钥（任意字符串，SHA-256 派生为 32 字节 key）</param>
    /// <param name="tokenShareUrl">远端共享 Token 地址；设置后将跳过 <see cref="BuildTokenUrl"/> 改从此地址获取加密 Token</param>
    protected void ConfigureSharedToken(string? shareSecret, string? tokenShareUrl)
    {
        if (!string.IsNullOrWhiteSpace(shareSecret))
            _shareKey = TencentTokenCrypto.DeriveKey(shareSecret);

        if (!string.IsNullOrWhiteSpace(tokenShareUrl))
            _tokenShareUrl = tokenShareUrl;
    }

    /// <summary>
    /// 配置共享 Token 模式（含统一共享密钥）
    /// <para>
    /// 子类在构造函数中调用此方法，将 Options 中的 <c>ShareSecret</c>、<c>TokenShareUrl</c>、<c>SecretShareUrl</c> 透传。<br/>
    /// 当同时设置 <c>SecretShareUrl</c> 与 <c>TokenShareUrl</c> 时，<c>SecretShareUrl</c> 优先。
    /// </para>
    /// </summary>
    /// <param name="shareSecret">共享密钥（任意字符串，SHA-256 派生为 32 字节 key）</param>
    /// <param name="tokenShareUrl">远端共享 Token 地址</param>
    /// <param name="secretShareUrl">远端统一共享密钥地址；响应格式 <c>{"data":"BASE64加密数据"}</c></param>
    protected void ConfigureSharedToken(string? shareSecret, string? tokenShareUrl, string? secretShareUrl)
    {
        ConfigureSharedToken(shareSecret, tokenShareUrl);

        if (!string.IsNullOrWhiteSpace(secretShareUrl))
            _secretShareUrl = secretShareUrl;
    }

    /// <summary>
    /// 构建获取 access_token 的完整请求 URL（仅在未配置 <c>TokenShareUrl</c> 时使用）
    /// </summary>
    protected abstract string BuildTokenUrl();

    /// <summary>
    /// 获取有效的 access_token（自动缓存与刷新）
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

            string newToken;
            int expiresInSeconds;

            if (_secretShareUrl is not null)
            {
                // 从远端统一共享密钥地址获取加密载荷
                if (_shareKey is null)
                    throw new InvalidOperationException(
                        "设置了 SecretShareUrl 但未配置 ShareSecret，无法解密统一共享密钥。");

                var response = await _httpClient.GetStringAsync(_secretShareUrl, ct);
                var envelope = JsonSerializer.Deserialize<SharedSecretEndpointResponse>(response)
                               ?? throw new TencentException("统一共享密钥接口返回为空");

                if (string.IsNullOrEmpty(envelope.Data))
                    throw new TencentException("统一共享密钥接口返回的 data 字段为空");

                var payloadJson = TencentTokenCrypto.DecryptWithKey(envelope.Data, _shareKey);
                var payload = JsonSerializer.Deserialize<SharedSecretPayload>(payloadJson)
                              ?? throw new TencentException("统一共享密钥解密后载荷为空");

                newToken = payload.AccessToken;
                expiresInSeconds = payload.TokenExpiresIn > 0 ? payload.TokenExpiresIn : 7200;

                if (OnSecretPayloadReceived is not null)
                    await OnSecretPayloadReceived(payload, ct);
            }
            else if (_tokenShareUrl is not null)
            {
                // 从远端共享地址获取加密 Token
                if (_shareKey is null)
                    throw new InvalidOperationException(
                        "设置了 TokenShareUrl 但未配置 ShareSecret，无法解密共享 Token。");

                var response = await _httpClient.GetStringAsync(_tokenShareUrl, ct);
                var result = JsonSerializer.Deserialize<SharedTokenEndpointResponse>(response)
                             ?? throw new TencentException("共享 Token 接口返回为空");

                if (string.IsNullOrEmpty(result.Token))
                    throw new TencentException("共享 Token 接口返回的 token 字段为空");

                newToken = TencentTokenCrypto.DecryptWithKey(result.Token, _shareKey);
                expiresInSeconds = result.ExpiresIn > 0 ? result.ExpiresIn : 7200;
            }
            else
            {
                // 直接向腾讯 API 请求 Token
                var url = BuildTokenUrl();
                var response = await _httpClient.GetStringAsync(url, ct);
                var result = JsonSerializer.Deserialize<AccessTokenResponse>(response)
                             ?? throw new TencentException("获取 access_token 返回为空");

                if (result.ErrCode != 0)
                    throw new TencentException(result.ErrCode, result.ErrMsg ?? string.Empty, _platformName);

                newToken = result.AccessToken ?? throw new TencentException("access_token 为空");
                expiresInSeconds = result.ExpiresIn;
            }

            _cachedToken = newToken;
            _expireAt = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds - 60);

            if (OnTokenChanged is not null)
                await OnTokenChanged(newToken, ct);

            return _cachedToken;
        }
        finally
        {
            _lock.Release();
        }
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

    /// <summary>
    /// 获取当前 access_token 的共享加密形式（ChaCha20-Poly1305），同时附带剩余有效秒数
    /// <para>
    /// 供主服务对外暴露 Token 共享接口使用，需在 Options 中配置 <c>ShareSecret</c>。<br/>
    /// 返回的 <see cref="SharedTokenResult.ExpiresIn"/> 为主服务侧 Token 的剩余秒数，<br/>
    /// 备服务应将此值原样写入响应 JSON 的 <c>expires_in</c> 字段，
    /// SDK 在 <see cref="GetTokenAsync"/> 中会据此设置本地缓存过期时间，避免与主服务不同步。
    /// </para>
    /// </summary>
    /// <exception cref="InvalidOperationException">未配置 ShareSecret 时抛出</exception>
    public async Task<SharedTokenResult> GetSharedTokenAsync(CancellationToken ct = default)
    {
        if (_shareKey is null)
            throw new InvalidOperationException("未配置 ShareSecret，无法获取共享 Token。");

        var token = await GetTokenAsync(ct);
        var encrypted = TencentTokenCrypto.EncryptWithKey(token, _shareKey);
        var remainingSeconds = Math.Max(0, (int)(_expireAt - DateTimeOffset.UtcNow).TotalSeconds);
        return new SharedTokenResult(encrypted, remainingSeconds);
    }

    /// <summary>
    /// 获取统一共享密钥的加密形式（ChaCha20-Poly1305）
    /// <para>
    /// 供主服务对外暴露统一共享密钥接口使用，需在 Options 中配置 <c>ShareSecret</c>。<br/>
    /// 返回的 <see cref="SharedSecretResult.Data"/> 为加密后的 <see cref="SharedSecretPayload"/> JSON，
    /// 备服务配置 <c>SecretShareUrl</c> 后将自动获取并解密。<br/>
    /// 调用方需通过 <paramref name="payloadBuilder"/> 提供完整的载荷信息（含 Ticket、AppId、AppSecret 等），
    /// Token 部分由本方法自动填充。
    /// </para>
    /// </summary>
    /// <param name="payloadBuilder">载荷构建委托，调用方应填充 AppId、AppSecret、JsApiTicket 等字段（Token 和 TokenExpiresIn 由本方法自动设置）</param>
    /// <param name="ct">取消令牌</param>
    /// <exception cref="InvalidOperationException">未配置 ShareSecret 时抛出</exception>
    public async Task<SharedSecretResult> GetSharedSecretAsync(
        Action<SharedSecretPayload> payloadBuilder,
        CancellationToken ct = default)
    {
        if (_shareKey is null)
            throw new InvalidOperationException("未配置 ShareSecret，无法获取统一共享密钥。");

        var token = await GetTokenAsync(ct);
        var remainingSeconds = Math.Max(0, (int)(_expireAt - DateTimeOffset.UtcNow).TotalSeconds);

        var payload = new SharedSecretPayload
        {
            AccessToken = token,
            TokenExpiresIn = remainingSeconds
        };
        payloadBuilder(payload);

        var json = JsonSerializer.Serialize(payload);
        var encrypted = TencentTokenCrypto.EncryptWithKey(json, _shareKey);
        return new SharedSecretResult(encrypted);
    }

    // ─── 私有响应模型 ─────────────────────────────────────────────────────────

    private sealed class AccessTokenResponse
    {
        [JsonPropertyName("errcode")] public int ErrCode { get; set; }
        [JsonPropertyName("errmsg")] public string? ErrMsg { get; set; }
        [JsonPropertyName("access_token")] public string? AccessToken { get; set; }
        [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
    }

    private sealed class SharedTokenEndpointResponse
    {
        [JsonPropertyName("token")] public string? Token { get; set; }
        [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
    }

    private sealed class SharedSecretEndpointResponse
    {
        [JsonPropertyName("data")] public string? Data { get; set; }
    }
}
