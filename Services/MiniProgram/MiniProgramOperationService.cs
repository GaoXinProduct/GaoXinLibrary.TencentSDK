using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序运维中心服务实现</summary>
public class MiniProgramOperationService : IMiniProgramOperationService
{
    private readonly WechatHttpClient _http;
    public MiniProgramOperationService(WechatHttpClient http) => _http = http;

    /// <inheritdoc/>
    public Task<GetDomainInfoResponse> GetDomainInfoAsync(CancellationToken ct = default)
        => _http.GetAsync<GetDomainInfoResponse>("/wxa/getwxadevinfo", null, ct);
    /// <inheritdoc/>
    public Task<GetPerformanceResponse> GetPerformanceAsync(GetPerformanceRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetPerformanceResponse>("/wxaapi/log/get_performance", request, ct);
    /// <inheritdoc/>
    public Task<GetSceneListResponse> GetSceneListAsync(OperationTimeRangeRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetSceneListResponse>("/wxaapi/log/get_scene", request, ct);
    /// <inheritdoc/>
    public Task<GetVersionListResponse> GetVersionListAsync(OperationTimeRangeRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetVersionListResponse>("/wxaapi/log/get_client_version", request, ct);
    /// <inheritdoc/>
    public Task<RealtimeLogSearchResponse> RealtimeLogSearchAsync(RealtimeLogSearchRequest request, CancellationToken ct = default)
    {
        var query = new Dictionary<string, string?>
        {
            ["date"]       = request.Date,
            ["begintime"]  = request.BeginTime.ToString(),
            ["endtime"]    = request.EndTime.ToString(),
            ["limit"]      = request.Limit.ToString(),
            ["start"]      = request.Start.ToString(),
            ["topic"]      = request.Topic,
            ["env"]        = request.Env,
            ["traceId"]    = request.TraceId,
            ["filterMsg"]  = request.FilterMsg,
        };
        return _http.GetAsync<RealtimeLogSearchResponse>("/wxaapi/userlog/userlog_search", query, ct);
    }
    /// <inheritdoc/>
    public Task<GetFeedbackListResponse> GetFeedbackListAsync(int type = 0, int page = 1, int num = 10, CancellationToken ct = default)
    {
        var query = new Dictionary<string, string?>
        {
            ["type"] = type.ToString(),
            ["page"] = page.ToString(),
            ["num"]  = num.ToString(),
        };
        return _http.GetAsync<GetFeedbackListResponse>("/wxaapi/feedback/list", query, ct);
    }
    /// <inheritdoc/>
    public Task<byte[]> GetFeedbackMediaAsync(string mediaId, CancellationToken ct = default)
        => _http.GetForBytesAsync("/cgi-bin/media/getfeedbackmedia",
            new Dictionary<string, string?> { ["media_id"] = mediaId }, ct);
    /// <inheritdoc/>
    public Task<JsErrSearchResponse> JsErrSearchAsync(JsErrSearchRequest request, CancellationToken ct = default)
        => _http.PostAsync<JsErrSearchResponse>("/wxaapi/log/jserr_list", request, ct);
    /// <inheritdoc/>
    public Task<GetJsErrDetailResponse> GetJsErrDetailAsync(GetJsErrDetailRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetJsErrDetailResponse>("/wxaapi/log/jserr_detail", request, ct);
    /// <inheritdoc/>
    public Task<GetGrayReleasePlanResponse> GetGrayReleasePlanAsync(CancellationToken ct = default)
        => _http.GetAsync<GetGrayReleasePlanResponse>("/wxa/getgrayreleaseplan", null, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序硬件设备服务

