using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序链接生成服务实现</summary>
public class MiniProgramLinkService : IMiniProgramLinkService
{
    private readonly WechatHttpClient _http;
    public MiniProgramLinkService(WechatHttpClient http) => _http = http;

    /// <inheritdoc/>
    public Task<GenerateSchemeResponse> GenerateSchemeAsync(GenerateSchemeRequest request, CancellationToken ct = default)
        => _http.PostAsync<GenerateSchemeResponse>("/wxa/generatescheme", request, ct);
    /// <inheritdoc/>
    public Task<GenerateUrlLinkResponse> GenerateUrlLinkAsync(GenerateUrlLinkRequest request, CancellationToken ct = default)
        => _http.PostAsync<GenerateUrlLinkResponse>("/wxa/generate_urllink", request, ct);
    /// <inheritdoc/>
    public Task<GenerateShortLinkResponse> GenerateShortLinkAsync(GenerateShortLinkRequest request, CancellationToken ct = default)
        => _http.PostAsync<GenerateShortLinkResponse>("/wxa/genwxashortlink", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序数据分析服务

