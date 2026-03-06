using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序 OCR 与图像处理服务实现</summary>
public class MiniProgramOcrService : IMiniProgramOcrService
{
    private readonly WechatHttpClient _http;
    public MiniProgramOcrService(WechatHttpClient http) => _http = http;

    /// <inheritdoc/>
    public Task<OcrIdCardResponse> IdCardAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrIdCardResponse>("/cv/ocr/idcard", request, ct);
    /// <inheritdoc/>
    public Task<OcrBankCardResponse> BankCardAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrBankCardResponse>("/cv/ocr/bankcard", request, ct);
    /// <inheritdoc/>
    public Task<OcrDrivingResponse> DrivingAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrDrivingResponse>("/cv/ocr/driving", request, ct);
    /// <inheritdoc/>
    public Task<OcrDrivingLicenseResponse> DrivingLicenseAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrDrivingLicenseResponse>("/cv/ocr/drivinglicense", request, ct);
    /// <inheritdoc/>
    public Task<OcrBizLicenseResponse> BizLicenseAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrBizLicenseResponse>("/cv/ocr/bizlicense", request, ct);
    /// <inheritdoc/>
    public Task<OcrCommResponse> CommAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrCommResponse>("/cv/ocr/comm", request, ct);
    /// <inheritdoc/>
    public Task<AiCropResponse> AiCropAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<AiCropResponse>("/cv/img/aicrop", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序链接服务（URL Scheme / URL Link / Short Link）

