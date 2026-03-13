using GaoXinLibrary.TencentSDK.Core;
using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信 HTTP 请求封装
/// </summary>
public class WechatHttpClient : TencentHttpClient<WechatBaseResponse>
{
    public WechatHttpClient(HttpClient httpClient, AccessTokenProvider tokenProvider, WechatOptions options, ILogger? logger = null)
        : base(httpClient, tokenProvider, options.BaseUrl, "微信", logger, options.RetryOptions) { }
}
