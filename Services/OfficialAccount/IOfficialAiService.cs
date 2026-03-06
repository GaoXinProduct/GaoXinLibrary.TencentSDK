using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号智能接口服务接口（语义理解 / OCR）</summary>
public interface IOfficialAiService
{
    /// <summary>语义理解</summary>
    Task<SemanticSearchResponse> SemanticSearchAsync(SemanticSearchRequest request, CancellationToken ct = default);
    /// <summary>OCR — 身份证识别</summary>
    Task<OfficialOcrIdCardResponse> OcrIdCardAsync(OfficialOcrRequest request, CancellationToken ct = default);
    /// <summary>OCR — 银行卡识别</summary>
    Task<OfficialOcrBankCardResponse> OcrBankCardAsync(OfficialOcrRequest request, CancellationToken ct = default);
    /// <summary>OCR — 行驶证识别</summary>
    Task<OfficialOcrDrivingResponse> OcrDrivingAsync(OfficialOcrRequest request, CancellationToken ct = default);
    /// <summary>OCR — 营业执照识别</summary>
    Task<OfficialOcrBizLicenseResponse> OcrBizLicenseAsync(OfficialOcrRequest request, CancellationToken ct = default);
}

