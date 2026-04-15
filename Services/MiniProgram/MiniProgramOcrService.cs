using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序 OCR 与图像处理服务实现</summary>
public class MiniProgramOcrService
{
    private readonly WechatHttpClient _http;
    public MiniProgramOcrService(WechatHttpClient http) => _http = http;

    /// <summary>身份证 OCR（POST /cv/ocr/idcard）</summary>
    public Task<OcrIdCardResponse> IdCardAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrIdCardResponse>("/cv/ocr/idcard", request, ct);
    /// <summary>银行卡 OCR（POST /cv/ocr/bankcard）</summary>
    public Task<OcrBankCardResponse> BankCardAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrBankCardResponse>("/cv/ocr/bankcard", request, ct);
    /// <summary>行驶证 OCR（POST /cv/ocr/driving）</summary>
    public Task<OcrDrivingResponse> DrivingAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrDrivingResponse>("/cv/ocr/driving", request, ct);
    /// <summary>驾驶证 OCR（POST /cv/ocr/drivinglicense）</summary>
    public Task<OcrDrivingLicenseResponse> DrivingLicenseAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrDrivingLicenseResponse>("/cv/ocr/drivinglicense", request, ct);
    /// <summary>营业执照 OCR（POST /cv/ocr/bizlicense）</summary>
    public Task<OcrBizLicenseResponse> BizLicenseAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrBizLicenseResponse>("/cv/ocr/bizlicense", request, ct);
    /// <summary>通用印刷体 OCR（POST /cv/ocr/comm）</summary>
    public Task<OcrCommResponse> CommAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OcrCommResponse>("/cv/ocr/comm", request, ct);
    /// <summary>图片智能裁切（POST /cv/img/aicrop）</summary>
    public Task<AiCropResponse> AiCropAsync(OcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<AiCropResponse>("/cv/img/aicrop", request, ct);
}
