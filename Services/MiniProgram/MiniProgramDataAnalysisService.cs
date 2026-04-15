using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序数据分析服务实现</summary>
public class MiniProgramDataAnalysisService
{
    private readonly WechatHttpClient _http;
    public MiniProgramDataAnalysisService(WechatHttpClient http) => _http = http;

    /// <summary>概况趋势（POST /datacube/getweanalysisappiddailysummarytrend）</summary>
    public Task<DailySummaryTrendResponse> GetDailySummaryTrendAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<DailySummaryTrendResponse>("/datacube/getweanalysisappiddailysummarytrend", request, ct);
    /// <summary>访问趋势（日）（POST /datacube/getweanalysisappiddailyvisittrend）</summary>
    public Task<DailyVisitTrendResponse> GetDailyVisitTrendAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<DailyVisitTrendResponse>("/datacube/getweanalysisappiddailyvisittrend", request, ct);
    /// <summary>访问页面（POST /datacube/getweanalysisappidvisitpage）</summary>
    public Task<VisitPageResponse> GetVisitPageAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<VisitPageResponse>("/datacube/getweanalysisappidvisitpage", request, ct);
    /// <summary>用户画像（POST /datacube/getweanalysisappiduserportrait）</summary>
    public Task<UserPortraitResponse> GetUserPortraitAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserPortraitResponse>("/datacube/getweanalysisappiduserportrait", request, ct);
    /// <summary>访问分布（POST /datacube/getweanalysisappidvisitdistribution）</summary>
    public Task<VisitDistributionResponse> GetVisitDistributionAsync(DataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<VisitDistributionResponse>("/datacube/getweanalysisappidvisitdistribution", request, ct);
}
