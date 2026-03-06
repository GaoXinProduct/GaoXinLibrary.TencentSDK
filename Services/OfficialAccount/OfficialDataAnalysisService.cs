using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号数据统计服务实现</summary>
public class OfficialDataAnalysisService : IOfficialDataAnalysisService
{
    private readonly WechatHttpClient _http;
    public OfficialDataAnalysisService(WechatHttpClient http) => _http = http;

    public Task<UserSummaryResponse> GetUserSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserSummaryResponse>("/datacube/getusersummary", request, ct);

    public Task<UserCumulateResponse> GetUserCumulateAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserCumulateResponse>("/datacube/getusercumulate", request, ct);

    public Task<ArticleSummaryResponse> GetArticleSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<ArticleSummaryResponse>("/datacube/getarticlesummary", request, ct);

    public Task<ArticleTotalResponse> GetArticleTotalAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<ArticleTotalResponse>("/datacube/getarticletotal", request, ct);

    public Task<UserReadResponse> GetUserReadAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserReadResponse>("/datacube/getuserread", request, ct);

    public Task<UserShareResponse> GetUserShareAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserShareResponse>("/datacube/getusershare", request, ct);

    public Task<UpstreamMsgResponse> GetUpstreamMsgAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UpstreamMsgResponse>("/datacube/getupstreammsg", request, ct);

    public Task<InterfaceSummaryResponse> GetInterfaceSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<InterfaceSummaryResponse>("/datacube/getinterfacesummary", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号智能接口服务

