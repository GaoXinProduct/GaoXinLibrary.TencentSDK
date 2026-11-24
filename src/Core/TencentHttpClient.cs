using System.Net;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯平台 HTTP 请求封装基类，提供 Token 注入、JSON 编解码及平台错误处理。
/// </summary>
/// <typeparam name="TResponse">平台的响应基类</typeparam>
public abstract class TencentHttpClient<TResponse> where TResponse : TencentBaseResponse
{
    private readonly HttpClient _httpClient;
    private readonly TencentAccessTokenProvider _tokenProvider;
    private readonly string _baseUrl;
    private readonly string? _platformName;

    /// <summary>日志记录器（未注入时使用 NullLogger）</summary>
    protected readonly ILogger Logger;

    internal TencentRetryOptions? RetryOptions { get; }

    internal static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    /// <summary>初始化 HTTP 客户端</summary>
    protected TencentHttpClient(HttpClient httpClient, TencentAccessTokenProvider tokenProvider, string baseUrl, string? platformName = null, ILogger? logger = null, TencentRetryOptions? retryOptions = null)
    {
        _httpClient = httpClient;
        _tokenProvider = tokenProvider;
        _baseUrl = baseUrl.TrimEnd('/');
        _platformName = platformName;
        Logger = logger ?? NullLogger.Instance;
        RetryOptions = retryOptions;
    }

    /// <summary>创建平台特定的异常</summary>
    protected TencentException CreateException(string message) => new(message);

    /// <summary>创建平台特定的异常（含错误码）</summary>
    protected TencentException CreateException(int errCode, string errMsg) => new(errCode, errMsg, _platformName);

    /// <summary>附加 access_token 的只读 GET 请求，瞬态故障时自动重试</summary>
    public Task<T> GetAsync<T>(string path, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
        => ExecuteWithTokenRetryAsync(token => GetWithoutTokenAsync<T>(BuildUrl(path, queryParams, token), ct), ct);

    // 用于以 GET 表达的写操作或一次性授权凭证。
    internal Task<T> GetWithoutTransientRetryAsync<T>(string path, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
        => ExecuteWithTokenRetryAsync(token => GetWithoutTokenOnceAsync<T>(BuildUrl(path, queryParams, token), ct), ct);

    /// <summary>POST 请求，自动附加 access_token</summary>
    public Task<T> PostAsync<T>(string path, object? body, CancellationToken ct = default)
        where T : TResponse
        => PostAsync<T>(path, body, null, ct);

    /// <summary>POST 请求，附加 access_token 及查询参数。服务端明确因 Token 失效拒绝请求时重试一次。</summary>
    public Task<T> PostAsync<T>(string path, object? body, Dictionary<string, string?>? queryParams, CancellationToken ct = default)
        where T : TResponse
        => PostJsonWithTokenAsync<T>(path, body, queryParams, retryTransient: false, ct);

    // 只给官方定义为只读查询的 POST 接口使用。
    internal Task<T> PostQueryAsync<T>(string path, object? body, CancellationToken ct = default)
        where T : TResponse
        => PostJsonWithTokenAsync<T>(path, body, null, retryTransient: true, ct);

    private async Task<T> PostJsonWithTokenAsync<T>(string path, object? body, Dictionary<string, string?>? queryParams, bool retryTransient, CancellationToken ct)
        where T : TResponse
    {
        using var content = body is null ? null : CreateJsonContent(body);
        return await ExecuteWithTokenRetryAsync(token =>
        {
            var url = BuildUrl(path, queryParams, token);
            return retryTransient
                ? ExecuteWithTransientRetryAsync(() => PostJsonAsync<T>(url, content, ct), ct)
                : PostJsonAsync<T>(url, content, ct);
        }, ct).ConfigureAwait(false);
    }

    /// <summary>不附加 access_token 的只读 GET 请求，瞬态故障时自动重试</summary>
    public Task<T> GetWithoutTokenAsync<T>(string url, CancellationToken ct = default)
        where T : TResponse
        => ExecuteWithTransientRetryAsync(() => GetWithoutTokenOnceAsync<T>(url, ct), ct);

    internal Task<T> GetWithoutTokenOnceAsync<T>(string url, CancellationToken ct = default)
        where T : TResponse
        => ReadBufferedAsync(HttpMethod.Get, url, null, ReadJsonAsync<T>, ct);

    /// <summary>不附加 access_token 的 POST 请求，发送一次</summary>
    public async Task<T> PostWithoutTokenAsync<T>(string url, object body, CancellationToken ct = default)
        where T : TResponse
    {
        using var content = CreateJsonContent(body);
        return await PostJsonAsync<T>(url, content, ct).ConfigureAwait(false);
    }

    /// <summary>使用完整地址发送不附加 access_token 的只读 GET 请求</summary>
    public Task<T> GetRawAsync<T>(string fullUrl, CancellationToken ct = default)
        where T : TResponse
        => GetWithoutTokenAsync<T>(fullUrl, ct);

    /// <summary>POST multipart/form-data 并附加 access_token。Token 失效重试需要可重复读取的内容。</summary>
    public Task<T> PostMultipartAsync<T>(string path, MultipartFormDataContent multipart, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
    {
        // 微信服务器要求 boundary 不带引号。
        var boundary = multipart.Headers.ContentType!.Parameters.First(p => p.Name == "boundary");
        boundary.Value = boundary.Value!.Trim('"');
        return ExecuteWithTokenRetryAsync(token => PostJsonAsync<T>(BuildUrl(path, queryParams, token), multipart, ct), ct);
    }

    /// <summary>POST 已构建的 multipart 内容并附加 access_token。调用方负责释放内容。</summary>
    public Task<T> PostRawFormAsync<T>(string path, ByteArrayContent rawForm, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
        => ExecuteWithTokenRetryAsync(token => PostJsonAsync<T>(BuildUrl(path, queryParams, token), rawForm, ct), ct);

    /// <summary>GET 请求，返回原始字节数组</summary>
    public Task<byte[]> GetForBytesAsync(string path, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        => ExecuteWithTokenRetryAsync(token => ExecuteWithTransientRetryAsync(
            () => ReadBufferedAsync(HttpMethod.Get, BuildUrl(path, queryParams, token), null, ReadBytesAsync, ct), ct), ct);

    /// <summary>POST 请求，返回原始字节。仅在 Token 被服务端明确拒绝后重试。</summary>
    public async Task<byte[]> PostForBytesAsync(string path, object body, CancellationToken ct = default)
    {
        using var content = CreateJsonContent(body);
        return await ExecuteWithTokenRetryAsync(
            token => ReadBufferedAsync(HttpMethod.Post, BuildUrl(path, null, token), content, ReadBytesAsync, ct), ct).ConfigureAwait(false);
    }

    // 瞬态重试限于读取响应头，避免重复写入调用方的流。
    internal Task<T> GetWithTokenAsync<T>(string path, Dictionary<string, string?>? queryParams,
        Func<HttpResponseMessage, CancellationToken, Task<T>> read, CancellationToken ct, Action<HttpRequestMessage>? configure = null)
        => ExecuteWithTokenRetryAsync(async token =>
        {
            var url = BuildUrl(path, queryParams, token);
            var (response, deadline) = await ExecuteWithTransientRetryAsync(
                () => SendForHeadersAsync(HttpMethod.Get, url, null, configure, ct), ct).ConfigureAwait(false);
            using (response)
            using (deadline)
                return await read(response, deadline.Token).ConfigureAwait(false);
        }, ct);

    private async Task<T> ReadBufferedAsync<T>(HttpMethod method, string url, HttpContent? content,
        Func<HttpResponseMessage, CancellationToken, Task<T>> read, CancellationToken ct)
    {
        var (response, deadline) = await SendForHeadersAsync(method, url, content, null, ct).ConfigureAwait(false);
        using (response)
        using (deadline)
        {
#if NET9_0_OR_GREATER
            await response.Content.LoadIntoBufferAsync(_httpClient.MaxResponseContentBufferSize, deadline.Token).ConfigureAwait(false);
#else
            await response.Content.LoadIntoBufferAsync(_httpClient.MaxResponseContentBufferSize).WaitAsync(deadline.Token).ConfigureAwait(false);
#endif
            return await read(response, deadline.Token).ConfigureAwait(false);
        }
    }

    private async Task<(HttpResponseMessage Response, CancellationTokenSource Deadline)> SendForHeadersAsync(
        HttpMethod method, string url, HttpContent? content, Action<HttpRequestMessage>? configure, CancellationToken ct)
    {
        // ResponseHeadersRead 只在收到响应头之前应用 HttpClient.Timeout。
        var deadline = CancellationTokenSource.CreateLinkedTokenSource(ct);
        HttpResponseMessage? response = null;
        try
        {
            deadline.CancelAfter(_httpClient.Timeout);
            using var request = new HttpRequestMessage(method, url)
            {
                Version = _httpClient.DefaultRequestVersion,
                VersionPolicy = _httpClient.DefaultVersionPolicy,
                Content = content
            };
            configure?.Invoke(request);
            try
            {
                response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, deadline.Token).ConfigureAwait(false);
            }
            finally
            {
                // 调用方管理请求内容的生命周期，Token 失效时可以重发同一份内容。
                request.Content = null;
            }
            response.EnsureSuccessStatusCode();
            return (response, deadline);
        }
        catch
        {
            response?.Dispose();
            deadline.Dispose();
            throw;
        }
    }

    private async Task<byte[]> ReadBytesAsync(HttpResponseMessage response, CancellationToken ct)
    {
        await ThrowIfApiErrorAsync(response, ct).ConfigureAwait(false);
        return await response.Content.ReadAsByteArrayAsync(ct).ConfigureAwait(false);
    }

    internal async Task ThrowIfApiErrorAsync(HttpResponseMessage response, CancellationToken ct)
    {
        if (response.Content.Headers.ContentType?.MediaType?.Contains("json", StringComparison.OrdinalIgnoreCase) != true)
            return;

        var json = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
        var error = JsonSerializer.Deserialize<TResponse>(json, JsonOptions);
        if (error is not null)
            ValidateError(error);
    }

    private async Task<T> ExecuteWithTokenRetryAsync<T>(Func<string, Task<T>> action, CancellationToken ct)
    {
        var token = await _tokenProvider.GetTokenSnapshotAsync(ct).ConfigureAwait(false);
        try
        {
            return await action(token.Value).ConfigureAwait(false);
        }
        catch (TencentException ex) when (_tokenProvider.IsRejectedTokenError(ex.ErrCode))
        {
            Logger.LogWarning("[{Platform}] Token 失效 (errcode={ErrCode})，正在自动刷新重试", _platformName, ex.ErrCode);
            token = await _tokenProvider.RefreshRejectedTokenAsync(token, ct).ConfigureAwait(false);
            return await action(token.Value).ConfigureAwait(false);
        }
    }

    private async Task<T> ExecuteWithTransientRetryAsync<T>(Func<Task<T>> action, CancellationToken ct)
    {
        if (RetryOptions is not { MaxRetries: > 0 } options)
            return await action().ConfigureAwait(false);

        var maxRetries = options.MaxRetries;
        var maxDelay = Math.Max(0, options.MaxDelay.Ticks);
        var delay = Math.Clamp(options.InitialDelay.Ticks, 0, maxDelay);

        for (var attempt = 0; ; attempt++)
        {
            try
            {
                return await action().ConfigureAwait(false);
            }
            catch (Exception ex) when (attempt < maxRetries && IsTransientException(ex, ct))
            {
                var wait = TimeSpan.FromTicks(delay);
                Logger.LogWarning("[{Platform}] 瞬态故障 ({ExceptionType}, HTTP {StatusCode})，第 {Attempt}/{MaxRetries} 次重试，等待 {Delay}ms",
                    _platformName, ex.GetType().Name, (ex as HttpRequestException)?.StatusCode, attempt + 1, maxRetries, wait.TotalMilliseconds);

                await Task.Delay(wait, ct).ConfigureAwait(false);
                delay += Math.Min(delay, maxDelay - delay);
            }
        }
    }

    private static bool IsTransientException(Exception ex, CancellationToken ct)
    {
        if (ct.IsCancellationRequested)
            return false;

        return ex switch
        {
            HttpRequestException { StatusCode: HttpStatusCode.RequestTimeout or HttpStatusCode.TooManyRequests } => true,
            HttpRequestException { StatusCode: >= HttpStatusCode.InternalServerError and < (HttpStatusCode)600 } => true,
            HttpRequestException { StatusCode: null, HttpRequestError: HttpRequestError.Unknown
                or HttpRequestError.ConnectionError or HttpRequestError.NameResolutionError or HttpRequestError.ResponseEnded } => true,
            TaskCanceledException => true,
            _ => false
        };
    }

    private Task<T> PostJsonAsync<T>(string url, HttpContent? content, CancellationToken ct) where T : TResponse
        => ReadBufferedAsync(HttpMethod.Post, url, content, ReadJsonAsync<T>, ct);

    private async Task<T> ReadJsonAsync<T>(HttpResponseMessage response, CancellationToken ct) where T : TResponse
    {
        var json = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<T>(json, JsonOptions)
                     ?? throw CreateException("API 响应反序列化失败");
        ValidateError(result);
        return result;
    }

    private void ValidateError(TResponse result)
    {
        if (result.ErrCode == 0)
            return;

        Logger.LogError("[{Platform}] API 调用失败: errcode={ErrCode}", _platformName, result.ErrCode);
        throw CreateException(result.ErrCode, result.ErrMsg ?? "未知错误");
    }

    private static ByteArrayContent CreateJsonContent(object body)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(body, body.GetType(), JsonOptions);
        var content = new ByteArrayContent(bytes);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
        return content;
    }

    private string BuildUrl(string path, Dictionary<string, string?>? extra, string token)
    {
        var url = $"{_baseUrl}{path}?access_token={Uri.EscapeDataString(token)}";
        if (extra is null or { Count: 0 })
            return url;

        var builder = new StringBuilder(url);
        foreach (var (key, value) in extra)
        {
            if (value is not null)
                builder.Append('&').Append(Uri.EscapeDataString(key)).Append('=').Append(Uri.EscapeDataString(value));
        }
        return builder.ToString();
    }
}
