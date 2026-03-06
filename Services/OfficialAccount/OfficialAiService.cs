using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号智能接口服务实现</summary>
public class OfficialAiService : IOfficialAiService
{
    private readonly WechatHttpClient _http;
    public OfficialAiService(WechatHttpClient http) => _http = http;

    public Task<SemanticSearchResponse> SemanticSearchAsync(SemanticSearchRequest request, CancellationToken ct = default)
        => _http.PostAsync<SemanticSearchResponse>("/semantic/semproxy/search", request, ct);

    public Task<OfficialOcrIdCardResponse> OcrIdCardAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrIdCardResponse>("/cv/ocr/idcard", request, ct);

    public Task<OfficialOcrBankCardResponse> OcrBankCardAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrBankCardResponse>("/cv/ocr/bankcard", request, ct);

    public Task<OfficialOcrDrivingResponse> OcrDrivingAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrDrivingResponse>("/cv/ocr/driving", request, ct);

    public Task<OfficialOcrBizLicenseResponse> OcrBizLicenseAsync(OfficialOcrRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialOcrBizLicenseResponse>("/cv/ocr/bizlicense", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号微信门店服务

