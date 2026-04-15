using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序运维中心服务实现</summary>
public class MiniProgramOperationService
{
    private readonly WechatHttpClient _http;
    public MiniProgramOperationService(WechatHttpClient http) => _http = http;

    /// <summary>查询域名配置（GET /wxa/getwxadevinfo）</summary>
    public Task<GetDomainInfoResponse> GetDomainInfoAsync(CancellationToken ct = default)
        => _http.GetAsync<GetDomainInfoResponse>("/wxa/getwxadevinfo", null, ct);
    /// <summary>获取性能数据（POST /wxaapi/log/get_performance）</summary>
    public Task<GetPerformanceResponse> GetPerformanceAsync(GetPerformanceRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetPerformanceResponse>("/wxaapi/log/get_performance", request, ct);
    /// <summary>获取访问来源（POST /wxaapi/log/get_scene）</summary>
    public Task<GetSceneListResponse> GetSceneListAsync(OperationTimeRangeRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetSceneListResponse>("/wxaapi/log/get_scene", request, ct);
    /// <summary>获取客户端版本（POST /wxaapi/log/get_client_version）</summary>
    public Task<GetVersionListResponse> GetVersionListAsync(OperationTimeRangeRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetVersionListResponse>("/wxaapi/log/get_client_version", request, ct);
    /// <summary>查询实时日志（GET /wxaapi/userlog/userlog_search）</summary>
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
    /// <summary>获取用户反馈列表（GET /wxaapi/feedback/list）</summary>
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
    /// <summary>获取反馈 mediaId 图片（GET /cgi-bin/media/getfeedbackmedia，返回字节流）</summary>
    public Task<byte[]> GetFeedbackMediaAsync(string mediaId, CancellationToken ct = default)
        => _http.GetForBytesAsync("/cgi-bin/media/getfeedbackmedia",
            new Dictionary<string, string?> { ["media_id"] = mediaId }, ct);
    /// <summary>查询错误列表（POST /wxaapi/log/jserr_list）</summary>
    public Task<JsErrSearchResponse> JsErrSearchAsync(JsErrSearchRequest request, CancellationToken ct = default)
        => _http.PostAsync<JsErrSearchResponse>("/wxaapi/log/jserr_list", request, ct);
    /// <summary>查询JS错误详情（POST /wxaapi/log/jserr_detail）</summary>
    public Task<GetJsErrDetailResponse> GetJsErrDetailAsync(GetJsErrDetailRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetJsErrDetailResponse>("/wxaapi/log/jserr_detail", request, ct);
    /// <summary>获取分阶段发布详情（GET /wxa/getgrayreleaseplan）</summary>
    public Task<GetGrayReleasePlanResponse> GetGrayReleasePlanAsync(CancellationToken ct = default)
        => _http.GetAsync<GetGrayReleasePlanResponse>("/wxa/getgrayreleaseplan", null, ct);
}
