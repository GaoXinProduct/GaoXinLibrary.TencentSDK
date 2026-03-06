using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序数据分析服务接口
/// </summary>
public interface IMiniProgramDataAnalysisService
{
    /// <summary>概况趋势（POST /datacube/getweanalysisappiddailysummarytrend）</summary>
    Task<DailySummaryTrendResponse> GetDailySummaryTrendAsync(DataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>访问趋势（日）（POST /datacube/getweanalysisappiddailyvisittrend）</summary>
    Task<DailyVisitTrendResponse> GetDailyVisitTrendAsync(DataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>访问页面（POST /datacube/getweanalysisappidvisitpage）</summary>
    Task<VisitPageResponse> GetVisitPageAsync(DataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>用户画像（POST /datacube/getweanalysisappiduserportrait）</summary>
    Task<UserPortraitResponse> GetUserPortraitAsync(DataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>访问分布（POST /datacube/getweanalysisappidvisitdistribution）</summary>
    Task<VisitDistributionResponse> GetVisitDistributionAsync(DataAnalysisRequest request, CancellationToken ct = default);
}

