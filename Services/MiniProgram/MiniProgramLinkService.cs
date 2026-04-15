using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序链接生成服务实现</summary>
public class MiniProgramLinkService
{
    private readonly WechatHttpClient _http;
    public MiniProgramLinkService(WechatHttpClient http) => _http = http;

    /// <summary>生成 URL Scheme（POST /wxa/generatescheme）</summary>
    public Task<GenerateSchemeResponse> GenerateSchemeAsync(GenerateSchemeRequest request, CancellationToken ct = default)
        => _http.PostAsync<GenerateSchemeResponse>("/wxa/generatescheme", request, ct);
    /// <summary>生成 URL Link（POST /wxa/generate_urllink）</summary>
    public Task<GenerateUrlLinkResponse> GenerateUrlLinkAsync(GenerateUrlLinkRequest request, CancellationToken ct = default)
        => _http.PostAsync<GenerateUrlLinkResponse>("/wxa/generate_urllink", request, ct);
    /// <summary>生成 Short Link（POST /wxa/genwxashortlink）</summary>
    public Task<GenerateShortLinkResponse> GenerateShortLinkAsync(GenerateShortLinkRequest request, CancellationToken ct = default)
        => _http.PostAsync<GenerateShortLinkResponse>("/wxa/genwxashortlink", request, ct);
}
