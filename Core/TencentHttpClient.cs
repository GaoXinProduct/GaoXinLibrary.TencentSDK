using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    internal static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    /// <summary>
    /// 初始化 HTTP 客户端
    /// </summary>
    protected TencentHttpClient(HttpClient httpClient, TencentAccessTokenProvider tokenProvider, string baseUrl, string? platformName = null)
    {
        _httpClient = httpClient;
        _tokenProvider = tokenProvider;
        _baseUrl = baseUrl.TrimEnd('/');
        _platformName = platformName;
    }

    /// <summary>创建平台特定的异常</summary>
    protected TencentException CreateException(string message) => new(message);

    /// <summary>创建平台特定的异常（含错误码）</summary>
    protected TencentException CreateException(int errCode, string errMsg) => new(errCode, errMsg, _platformName);

    // ─── 带 Token 请求 ──────────────────────────────────────────────────

    /// <summary>GET 请求，自动附加 access_token</summary>
    public async Task<T> GetAsync<T>(string path, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var query = BuildQuery(queryParams, token);
        var url = $"{_baseUrl}{path}?{query}";

        var json = await _httpClient.GetStringAsync(url, ct);
        return DeserializeAndValidate<T>(json);
    }

    /// <summary>POST 请求（JSON body），自动附加 access_token</summary>
    public Task<T> PostAsync<T>(string path, object body, CancellationToken ct = default)
        where T : TResponse
        => PostAsync<T>(path, body, null, ct);

    /// <summary>POST 请求（JSON body），自动附加 access_token 及额外查询参数</summary>
    public async Task<T> PostAsync<T>(string path, object body, Dictionary<string, string?>? queryParams, CancellationToken ct = default)
        where T : TResponse
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var query = BuildQuery(queryParams, token);
        var url = $"{_baseUrl}{path}?{query}";
        var content = new StringContent(JsonSerializer.Serialize(body, JsonOptions), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content, ct);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct);

        return DeserializeAndValidate<T>(json);
    }

    // ─── 无 Token 请求 ──────────────────────────────────────────────────

    /// <summary>GET 请求，不附加 access_token（用于 SNS / OAuth 等场景）</summary>
    public async Task<T> GetWithoutTokenAsync<T>(string url, CancellationToken ct = default)
        where T : TResponse
    {
        var json = await _httpClient.GetStringAsync(url, ct);
        return DeserializeAndValidate<T>(json);
    }

    /// <summary>POST 请求（无 access_token，用于 Webhook 等）</summary>
    public async Task<T> PostWithoutTokenAsync<T>(string url, object body, CancellationToken ct = default)
        where T : TResponse
    {
        var content = new StringContent(JsonSerializer.Serialize(body, JsonOptions), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content, ct);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct);

        return DeserializeAndValidate<T>(json);
    }

    /// <summary>GET 请求（自定义完整 URL，不走 BaseUrl），不附加 token</summary>
    public async Task<T> GetRawAsync<T>(string fullUrl, CancellationToken ct = default)
        where T : TResponse
    {
        var json = await _httpClient.GetStringAsync(fullUrl, ct);
        return DeserializeAndValidate<T>(json);
    }

    /// <summary>POST 请求（multipart/form-data），自动附加 access_token 及额外查询参数</summary>
    public async Task<T> PostMultipartAsync<T>(string path, MultipartFormDataContent multipart, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var query = BuildQuery(queryParams, token);
        var url = $"{_baseUrl}{path}?{query}";

        // 微信服务器不支持 boundary 带引号，需要去除
        var boundary = multipart.Headers.ContentType!.Parameters.First(p => p.Name == "boundary");
        boundary.Value = boundary.Value!.Trim('"');

        var response = await _httpClient.PostAsync(url, multipart, ct);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct);

        return DeserializeAndValidate<T>(json);
    }

    /// <summary>POST 请求（预构建原始 multipart 体），自动附加 access_token 及额外查询参数</summary>
    public async Task<T> PostRawFormAsync<T>(string path, ByteArrayContent rawForm, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
        where T : TResponse
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var query = BuildQuery(queryParams, token);
        var url = $"{_baseUrl}{path}?{query}";

        var response = await _httpClient.PostAsync(url, rawForm, ct);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct);

        return DeserializeAndValidate<T>(json);
    }

    // ─── 二进制响应 ─────────────────────────────────────────────────────

    /// <summary>GET 请求，返回原始字节流（如获取反馈图片）</summary>
    public async Task<byte[]> GetForBytesAsync(string path, Dictionary<string, string?>? queryParams = null, CancellationToken ct = default)
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
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
    }

    /// <summary>POST 请求，返回原始字节流（如获取小程序码）</summary>
    public async Task<byte[]> PostForBytesAsync(string path, object body, CancellationToken ct = default)
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var url = $"{_baseUrl}{path}?access_token={Uri.EscapeDataString(token)}";
        var content = new StringContent(JsonSerializer.Serialize(body, JsonOptions), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content, ct);
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
    }

    // ─── 辅助方法 ───────────────────────────────────────────────────────

    private T DeserializeAndValidate<T>(string json) where T : TResponse
    {
        var result = JsonSerializer.Deserialize<T>(json, JsonOptions)
                     ?? throw CreateException("API 响应反序列化失败");

        if (result.ErrCode != 0)
            throw CreateException(result.ErrCode, result.ErrMsg ?? "未知错误");

        return result;
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
