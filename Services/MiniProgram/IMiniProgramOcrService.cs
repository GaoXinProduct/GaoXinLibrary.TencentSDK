using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序 OCR 与图像处理服务接口
/// </summary>
public interface IMiniProgramOcrService
{
    /// <summary>身份证 OCR（POST /cv/ocr/idcard）</summary>
    Task<OcrIdCardResponse> IdCardAsync(OcrRequest request, CancellationToken ct = default);
    /// <summary>银行卡 OCR（POST /cv/ocr/bankcard）</summary>
    Task<OcrBankCardResponse> BankCardAsync(OcrRequest request, CancellationToken ct = default);
    /// <summary>行驶证 OCR（POST /cv/ocr/driving）</summary>
    Task<OcrDrivingResponse> DrivingAsync(OcrRequest request, CancellationToken ct = default);
    /// <summary>驾驶证 OCR（POST /cv/ocr/drivinglicense）</summary>
    Task<OcrDrivingLicenseResponse> DrivingLicenseAsync(OcrRequest request, CancellationToken ct = default);
    /// <summary>营业执照 OCR（POST /cv/ocr/bizlicense）</summary>
    Task<OcrBizLicenseResponse> BizLicenseAsync(OcrRequest request, CancellationToken ct = default);
    /// <summary>通用印刷体 OCR（POST /cv/ocr/comm）</summary>
    Task<OcrCommResponse> CommAsync(OcrRequest request, CancellationToken ct = default);
    /// <summary>图片智能裁切（POST /cv/img/aicrop）</summary>
    Task<AiCropResponse> AiCropAsync(OcrRequest request, CancellationToken ct = default);
}

