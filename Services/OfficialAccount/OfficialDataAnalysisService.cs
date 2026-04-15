using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号数据统计服务实现</summary>
public class OfficialDataAnalysisService
{
    private readonly WechatHttpClient _http;
    public OfficialDataAnalysisService(WechatHttpClient http) => _http = http;

    /// <summary>获取用户增减数据</summary>
    public Task<UserSummaryResponse> GetUserSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserSummaryResponse>("/datacube/getusersummary", request, ct);

    /// <summary>获取累计用户数据</summary>
    public Task<UserCumulateResponse> GetUserCumulateAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserCumulateResponse>("/datacube/getusercumulate", request, ct);

    /// <summary>获取图文群发每日数据</summary>
    public Task<ArticleSummaryResponse> GetArticleSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<ArticleSummaryResponse>("/datacube/getarticlesummary", request, ct);

    /// <summary>获取图文群发总数据</summary>
    public Task<ArticleTotalResponse> GetArticleTotalAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<ArticleTotalResponse>("/datacube/getarticletotal", request, ct);

    /// <summary>获取图文统计数据</summary>
    public Task<UserReadResponse> GetUserReadAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserReadResponse>("/datacube/getuserread", request, ct);

    /// <summary>获取图文分享转发数据</summary>
    public Task<UserShareResponse> GetUserShareAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserShareResponse>("/datacube/getusershare", request, ct);

    /// <summary>获取消息发送概况数据</summary>
    public Task<UpstreamMsgResponse> GetUpstreamMsgAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<UpstreamMsgResponse>("/datacube/getupstreammsg", request, ct);

    /// <summary>获取接口分析数据</summary>
    public Task<InterfaceSummaryResponse> GetInterfaceSummaryAsync(OfficialDataAnalysisRequest request, CancellationToken ct = default)
        => _http.PostAsync<InterfaceSummaryResponse>("/datacube/getinterfacesummary", request, ct);
}
