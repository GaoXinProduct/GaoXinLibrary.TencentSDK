using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Core;

/// <summary>
/// 微信 HTTP 请求封装
/// </summary>
public class WechatHttpClient : TencentHttpClient<WechatBaseResponse>
{
    public WechatHttpClient(HttpClient httpClient, AccessTokenProvider tokenProvider, WechatOptions options)
        : base(httpClient, tokenProvider, options.BaseUrl, "微信") { }
}
