using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序链接生成服务接口
/// </summary>
public interface IMiniProgramLinkService
{
    /// <summary>生成 URL Scheme（POST /wxa/generatescheme）</summary>
    Task<GenerateSchemeResponse> GenerateSchemeAsync(GenerateSchemeRequest request, CancellationToken ct = default);
    /// <summary>生成 URL Link（POST /wxa/generate_urllink）</summary>
    Task<GenerateUrlLinkResponse> GenerateUrlLinkAsync(GenerateUrlLinkRequest request, CancellationToken ct = default);
    /// <summary>生成 Short Link（POST /wxa/genwxashortlink）</summary>
    Task<GenerateShortLinkResponse> GenerateShortLinkAsync(GenerateShortLinkRequest request, CancellationToken ct = default);
}

