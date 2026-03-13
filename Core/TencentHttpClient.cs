using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 腾讯平台 HTTP 请求封装基类
/// <para>
/// 提供 GET/POST 自动附加 access_token、JSON 序列化/反序列化、错误检测等共用逻辑。<br/>
/// 子类通过泛型参数 <typeparamref name="TResponse"/> 绑定平台特定的响应基类。
/// </para>
/// </summary>
/// <typeparam name="TResponse">平台特定的 API 响应基类（如 <c>WechatBaseResponse</c>、<c>WecomBaseResponse</c>）</typeparam>
public abstract class TencentHttpClient<TResponse> where TResponse : TencentBaseResponse
{
    private readonly HttpClient _httpClient;
    private readonly TencentAccessTokenProvider _tokenProvider;
    private readonly string _baseUrl;
    private readonly string? _platformName;
    private readonly TencentRetryOptions? _retryOptions;

    /// <summary>日志记录器（可选，未注入时使用 NullLogger）</summary>
    protected readonly ILogger Logger;

    internal static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    /// <summary>
    /// 初始化 HTTP 客户端
    /// </summary>
    protected TencentHttpClient(HttpClient httpClient, TencentAccessTokenProvider tokenProvider, string baseUrl, string? platformName = null, ILogger? logger = null, TencentRetryOptions? retryOptions = null)
    {
        _httpClient = httpClient;
        _tokenProvider = tokenProvider;
        _baseUrl = baseUrl.TrimEnd('/');
        _platformName = platformName;
        Logger = logger ?? NullLogger.Instance;
        _retryOptions = retryOptions;
    }

    /// <summary>创建平台特定的异常</summary>
    protected TencentException CreateException(string message) => new(message);

    /// <summary>创建平台特定的异常（含错误码）</summary>
    protected TencentException CreateException(int errCode, string errMsg) => new(errCode, errMsg, _platformName);

    // ─── 带 Token 请求（含 Token 失效自动重试） ─────────────────────────

    /// <summary>GET 请求，自动附加 access_token（Token 失效时自动刷新重试一次，瞬态故障自动重试）</summary>
    public async Task<T> GetAsync<T>(string path, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
    {
        return await ExecuteWithTokenRetryAsync(async token =>
        {
            return await ExecuteWithTransientRetryAsync(async () =>
            {
                var query = BuildQuery(queryParams, token);
                var url = $"{_baseUrl}{path}?{query}";
                var json = await _httpClient.GetStringAsync(url, ct);
                return DeserializeAndValidate<T>(json);
            }, ct);
        }, ct);
    }

    /// <summary>POST 请求（JSON body），自动附加 access_token</summary>
    public Task<T> PostAsync<T>(string path, object body, CancellationToken ct = default)
        where T : TResponse
        => PostAsync<T>(path, body, null, ct);

    /// <summary>POST 请求（JSON body），自动附加 access_token 及额外查询参数（Token 失效时自动刷新重试一次，瞬态故障自动重试）</summary>
    public async Task<T> PostAsync<T>(string path, object body, Dictionary<string, string?>? queryParams, CancellationToken ct = default)
        where T : TResponse
    {
        return await ExecuteWithTokenRetryAsync(async token =>
        {
            return await ExecuteWithTransientRetryAsync(async () =>
            {
                var query = BuildQuery(queryParams, token);
                var url = $"{_baseUrl}{path}?{query}";
                var response = await _httpClient.PostAsync(url, CreateJsonContent(body), ct);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync(ct);
                return DeserializeAndValidate<T>(json);
            }, ct);
        }, ct);
    }

    // ─── 无 Token 请求 ──────────────────────────────────────────────────

    /// <summary>GET 请求，不附加 access_token（用于 SNS / OAuth 等场景，瞬态故障自动重试）</summary>
    public async Task<T> GetWithoutTokenAsync<T>(string url, CancellationToken ct = default)
        where T : TResponse
    {
        return await ExecuteWithTransientRetryAsync(async () =>
        {
            var json = await _httpClient.GetStringAsync(url, ct);
            return DeserializeAndValidate<T>(json);
        }, ct);
    }

    /// <summary>POST 请求（无 access_token，用于 Webhook 等，瞬态故障自动重试）</summary>
    public async Task<T> PostWithoutTokenAsync<T>(string url, object body, CancellationToken ct = default)
        where T : TResponse
    {
        return await ExecuteWithTransientRetryAsync(async () =>
        {
            var response = await _httpClient.PostAsync(url, CreateJsonContent(body), ct);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync(ct);
            return DeserializeAndValidate<T>(json);
        }, ct);
    }

    /// <summary>GET 请求（自定义完整 URL，不走 BaseUrl），不附加 token（瞬态故障自动重试）</summary>
    public async Task<T> GetRawAsync<T>(string fullUrl, CancellationToken ct = default)
        where T : TResponse
    {
        return await ExecuteWithTransientRetryAsync(async () =>
        {
            var json = await _httpClient.GetStringAsync(fullUrl, ct);
            return DeserializeAndValidate<T>(json);
        }, ct);
    }

    /// <summary>POST 请求（multipart/form-data），自动附加 access_token 及额外查询参数（Token 失效时自动刷新重试一次，瞬态故障自动重试）</summary>
    public async Task<T> PostMultipartAsync<T>(string path, MultipartFormDataContent multipart, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
    {
        return await ExecuteWithTokenRetryAsync(async token =>
        {
            return await ExecuteWithTransientRetryAsync(async () =>
            {
                var query = BuildQuery(queryParams, token);
                var url = $"{_baseUrl}{path}?{query}";

                // 微信服务器不支持 boundary 带引号，需要去除
                var boundary = multipart.Headers.ContentType!.Parameters.First(p => p.Name == "boundary");
                boundary.Value = boundary.Value!.Trim('"');

                var response = await _httpClient.PostAsync(url, multipart, ct);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync(ct);

                return DeserializeAndValidate<T>(json);
            }, ct);
        }, ct);
    }

    /// <summary>POST 请求（预构建原始 multipart 体），自动附加 access_token 及额外查询参数（Token 失效时自动刷新重试一次，瞬态故障自动重试）</summary>
    public async Task<T> PostRawFormAsync<T>(string path, ByteArrayContent rawForm, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
    {
        return await ExecuteWithTokenRetryAsync(async token =>
        {
            return await ExecuteWithTransientRetryAsync(async () =>
            {
                var query = BuildQuery(queryParams, token);
                var url = $"{_baseUrl}{path}?{query}";

                var response = await _httpClient.PostAsync(url, rawForm, ct);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync(ct);

                return DeserializeAndValidate<T>(json);
            }, ct);
        }, ct);
    }

    // ─── 二进制响应 ─────────────────────────────────────────────────────

    /// <summary>GET 请求，返回原始字节流（如获取反馈图片）（Token 失效时自动刷新重试一次，瞬态故障自动重试）</summary>
    public async Task<byte[]> GetForBytesAsync(string path, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
    {
        return await ExecuteWithTokenRetryAsync(async token =>
        {
            return await ExecuteWithTransientRetryAsync(async () =>
            {
                var query = BuildQuery(queryParams, token);
                var url = $"{_baseUrl}{path}?{query}";

                var response = await _httpClient.GetAsync(url, ct);
                response.EnsureSuccessStatusCode();

                var contentType = response.Content.Headers.ContentType?.MediaType;
                if (contentType != null && contentType.Contains("json", StringComparison.OrdinalIgnoreCase))
                {
                    var json = await response.Content.ReadAsStringAsync(ct);
                    var error = JsonSerializer.Deserialize<TResponse>(json, JsonOptions);
                    if (error is { ErrCode: not 0 })
                        throw CreateException(error.ErrCode, error.ErrMsg ?? "未知错误");
                }

                return await response.Content.ReadAsByteArrayAsync(ct);
            }, ct);
        }, ct);
    }

    /// <summary>POST 请求，返回原始字节流（如获取小程序码）（Token 失效时自动刷新重试一次，瞬态故障自动重试）</summary>
    public async Task<byte[]> PostForBytesAsync(string path, object body, CancellationToken ct = default)
    {
        return await ExecuteWithTokenRetryAsync(async token =>
        {
            return await ExecuteWithTransientRetryAsync(async () =>
            {
                var url = $"{_baseUrl}{path}?access_token={Uri.EscapeDataString(token)}";

                var response = await _httpClient.PostAsync(url, CreateJsonContent(body), ct);
                response.EnsureSuccessStatusCode();

                // 如果返回 JSON 则可能是错误
                var contentType = response.Content.Headers.ContentType?.MediaType;
                if (contentType != null && contentType.Contains("json", StringComparison.OrdinalIgnoreCase))
                {
                    var json = await response.Content.ReadAsStringAsync(ct);
                    var error = JsonSerializer.Deserialize<TResponse>(json, JsonOptions);
                    if (error is { ErrCode: not 0 })
                        throw CreateException(error.ErrCode, error.ErrMsg ?? "未知错误");
                }

                return await response.Content.ReadAsByteArrayAsync(ct);
            }, ct);
        }, ct);
    }

    // ─── Token 失效自动重试 ──────────────────────────────────────────────

    /// <summary>
    /// 执行带 Token 的请求，当遇到 Token 失效错误（40001/40014/42001）时自动刷新 Token 并重试一次
    /// </summary>
    private async Task<T> ExecuteWithTokenRetryAsync<T>(Func<string, Task<T>> action, CancellationToken ct)
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        try
        {
            return await action(token);
        }
        catch (TencentException ex) when (TencentAccessTokenProvider.IsTokenInvalidError(ex.ErrCode))
        {
            Logger.LogWarning("[{Platform}] Token 失效 (errcode={ErrCode})，正在自动刷新重试", _platformName, ex.ErrCode);
            _tokenProvider.InvalidateCache();
            token = await _tokenProvider.GetTokenAsync(ct);
            return await action(token);
        }
    }

    // ─── 瞬态故障自动重试 ────────────────────────────────────────────────

    /// <summary>
    /// 执行请求，网络抖动、连接超时、5xx 等瞬态故障时按指数退避自动重试
    /// </summary>
    private async Task<T> ExecuteWithTransientRetryAsync<T>(Func<Task<T>> action, CancellationToken ct)
    {
        if (_retryOptions is not { MaxRetries: > 0 })
            return await action();

        var maxRetries = _retryOptions.MaxRetries;
        var delay = _retryOptions.InitialDelay;
        var maxDelay = _retryOptions.MaxDelay;

        for (var attempt = 0; ; attempt++)
        {
            try
            {
                return await action();
            }
            catch (Exception ex) when (attempt < maxRetries && IsTransientException(ex, ct))
            {
                Logger.LogWarning("[{Platform}] 瞬态故障 ({ExceptionType}: {Message})，第 {Attempt}/{MaxRetries} 次重试，等待 {Delay}ms",
                    _platformName, ex.GetType().Name, ex.Message, attempt + 1, maxRetries, (int)delay.TotalMilliseconds);

                await Task.Delay(delay, ct);
                delay = TimeSpan.FromTicks(Math.Min(delay.Ticks * 2, maxDelay.Ticks));
            }
        }
    }

    /// <summary>
    /// 判断异常是否为可重试的瞬态故障
    /// </summary>
    private static bool IsTransientException(Exception ex, CancellationToken ct)
    {
        // 用户主动取消不重试
        if (ct.IsCancellationRequested)
            return false;

        return ex switch
        {
            // 连接失败、DNS 解析失败、HTTP 5xx 等网络层与服务端错误
            HttpRequestException => true,
            // HttpClient 超时（非用户主动取消）
            TaskCanceledException when !ct.IsCancellationRequested => true,
            _ => false
        };
    }

    // ─── 辅助方法 ───────────────────────────────────────────────────────

    private T DeserializeAndValidate<T>(string json) where T : TResponse
    {
        var result = JsonSerializer.Deserialize<T>(json, JsonOptions)
                     ?? throw CreateException("API 响应反序列化失败");

        if (result.ErrCode != 0)
        {
            Logger.LogError("[{Platform}] API 调用失败: errcode={ErrCode}, errmsg={ErrMsg}", _platformName, result.ErrCode, result.ErrMsg);
            throw CreateException(result.ErrCode, result.ErrMsg ?? "未知错误");
        }

        return result;
    }

    private static ByteArrayContent CreateJsonContent(object body)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(body, body.GetType(), JsonOptions);
        var content = new ByteArrayContent(bytes);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
        return content;
    }

    private static string BuildQuery(Dictionary<string, string?>? extra, string token)
    {
        var escapedToken = Uri.EscapeDataString(token);
        if (extra is null or { Count: 0 })
            return string.Concat("access_token=", escapedToken);

        var sb = new StringBuilder(128);
        sb.Append("access_token=").Append(escapedToken);
        foreach (var kv in extra)
        {
            if (kv.Value is not null)
                sb.Append('&').Append(Uri.EscapeDataString(kv.Key)).Append('=').Append(Uri.EscapeDataString(kv.Value));
        }
        return sb.ToString();
    }
}
