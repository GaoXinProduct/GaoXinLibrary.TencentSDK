
namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信 HTTP 请求封装
/// </summary>
public sealed class WecomHttpClient : TencentHttpClient<WecomBaseResponse>
{
    public WecomHttpClient(HttpClient httpClient, AccessTokenProvider tokenProvider, WecomOptions options, ILogger? logger = null)
        : this(httpClient, tokenProvider, options.BaseUrl, logger, options.RetryOptions) { }

    private WecomHttpClient(HttpClient httpClient, AccessTokenProvider tokenProvider, string baseUrl, ILogger? logger, TencentRetryOptions? retryOptions)
        : base(httpClient, tokenProvider, baseUrl, "企业微信", logger, retryOptions) { }

    internal WecomHttpClient WithTransport(HttpClient httpClient, AccessTokenProvider tokenProvider, string baseUrl)
        => new(httpClient, tokenProvider, baseUrl, Logger, RetryOptions);
}
