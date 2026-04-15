using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号智能接口服务实现</summary>
public class OfficialAiService
{
    private readonly WechatHttpClient _http;
    public OfficialAiService(WechatHttpClient http) => _http = http;

    /// <summary>语义理解</summary>
    public Task<SemanticSearchResponse> SemanticSearchAsync(SemanticSearchRequest request, CancellationToken ct = default)
        => _http.PostAsync<SemanticSearchResponse>("/semantic/semproxy/search", request, ct);

    /// <summary>OCR — 身份证识别</summary>
    public Task<OfficialOcrIdCardResponse> OcrIdCardAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrIdCardResponse>("/cv/ocr/idcard", request, ct);

    /// <summary>OCR — 银行卡识别</summary>
    public Task<OfficialOcrBankCardResponse> OcrBankCardAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrBankCardResponse>("/cv/ocr/bankcard", request, ct);

    /// <summary>OCR — 行驶证识别</summary>
    public Task<OfficialOcrDrivingResponse> OcrDrivingAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrDrivingResponse>("/cv/ocr/driving", request, ct);

    /// <summary>OCR — 营业执照识别</summary>
    public Task<OfficialOcrBizLicenseResponse> OcrBizLicenseAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrBizLicenseResponse>("/cv/ocr/bizlicense", request, ct);
}
