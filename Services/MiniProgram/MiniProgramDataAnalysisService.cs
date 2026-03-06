using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序数据分析服务实现</summary>
public class MiniProgramDataAnalysisService : IMiniProgramDataAnalysisService
{
    private readonly WechatHttpClient _http;
    public MiniProgramDataAnalysisService(WechatHttpClient http) => _http = http;

    /// <inheritdoc/>
    public Task<DailySummaryTrendResponse> GetDailySummaryTrendAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<DailySummaryTrendResponse>("/datacube/getweanalysisappiddailysummarytrend", request, ct);
    /// <inheritdoc/>
    public Task<DailyVisitTrendResponse> GetDailyVisitTrendAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<DailyVisitTrendResponse>("/datacube/getweanalysisappiddailyvisittrend", request, ct);
    /// <inheritdoc/>
    public Task<VisitPageResponse> GetVisitPageAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<VisitPageResponse>("/datacube/getweanalysisappidvisitpage", request, ct);
    /// <inheritdoc/>
    public Task<UserPortraitResponse> GetUserPortraitAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserPortraitResponse>("/datacube/getweanalysisappiduserportrait", request, ct);
    /// <inheritdoc/>
    public Task<VisitDistributionResponse> GetVisitDistributionAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<VisitDistributionResponse>("/datacube/getweanalysisappidvisitdistribution", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序物流助手服务

