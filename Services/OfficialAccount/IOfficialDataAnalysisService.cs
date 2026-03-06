using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号数据统计服务接口</summary>
public interface IOfficialDataAnalysisService
{
    /// <summary>获取用户增减数据</summary>
    Task<UserSummaryResponse> GetUserSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>获取累计用户数据</summary>
    Task<UserCumulateResponse> GetUserCumulateAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>获取图文群发每日数据</summary>
    Task<ArticleSummaryResponse> GetArticleSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>获取图文群发总数据</summary>
    Task<ArticleTotalResponse> GetArticleTotalAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>获取图文统计数据</summary>
    Task<UserReadResponse> GetUserReadAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>获取图文分享转发数据</summary>
    Task<UserShareResponse> GetUserShareAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>获取消息发送概况数据</summary>
    Task<UpstreamMsgResponse> GetUpstreamMsgAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
    /// <summary>获取接口分析数据</summary>
    Task<InterfaceSummaryResponse> GetInterfaceSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default);
}

