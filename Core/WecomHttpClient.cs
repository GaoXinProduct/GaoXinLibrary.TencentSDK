using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Core;

/// <summary>
/// 企业微信 HTTP 请求封装
/// </summary>
public class WecomHttpClient : TencentHttpClient<WecomBaseResponse>
{
    public WecomHttpClient(HttpClient httpClient, AccessTokenProvider tokenProvider, WecomOptions options)
        : base(httpClient, tokenProvider, options.BaseUrl, "企业微信") { }
}
