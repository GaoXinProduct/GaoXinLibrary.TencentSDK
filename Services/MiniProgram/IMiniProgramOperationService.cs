using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序运维中心服务接口
/// </summary>
public interface IMiniProgramOperationService
{
    /// <summary>查询域名配置（GET /wxa/getwxadevinfo）</summary>
    Task<GetDomainInfoResponse> GetDomainInfoAsync(CancellationToken ct = default);
    /// <summary>获取性能数据（POST /wxaapi/log/get_performance）</summary>
    Task<GetPerformanceResponse> GetPerformanceAsync(GetPerformanceRequest request, CancellationToken ct = default);
    /// <summary>获取访问来源（POST /wxaapi/log/get_scene）</summary>
    Task<GetSceneListResponse> GetSceneListAsync(OperationTimeRangeRequest request, CancellationToken ct = default);
    /// <summary>获取客户端版本（POST /wxaapi/log/get_client_version）</summary>
    Task<GetVersionListResponse> GetVersionListAsync(OperationTimeRangeRequest request, CancellationToken ct = default);
    /// <summary>查询实时日志（GET /wxaapi/userlog/userlog_search）</summary>
    Task<RealtimeLogSearchResponse> RealtimeLogSearchAsync(RealtimeLogSearchRequest request, CancellationToken ct = default);
    /// <summary>获取用户反馈列表（GET /wxaapi/feedback/list）</summary>
    Task<GetFeedbackListResponse> GetFeedbackListAsync(int type = 0, int page = 1, int num = 10, CancellationToken ct = default);
    /// <summary>获取反馈 mediaId 图片（GET /cgi-bin/media/getfeedbackmedia，返回字节流）</summary>
    Task<byte[]> GetFeedbackMediaAsync(string mediaId, CancellationToken ct = default);
    /// <summary>查询错误列表（POST /wxaapi/log/jserr_list）</summary>
    Task<JsErrSearchResponse> JsErrSearchAsync(JsErrSearchRequest request, CancellationToken ct = default);
    /// <summary>查询JS错误详情（POST /wxaapi/log/jserr_detail）</summary>
    Task<GetJsErrDetailResponse> GetJsErrDetailAsync(GetJsErrDetailRequest request, CancellationToken ct = default);
    /// <summary>获取分阶段发布详情（GET /wxa/getgrayreleaseplan）</summary>
    Task<GetGrayReleasePlanResponse> GetGrayReleasePlanAsync(CancellationToken ct = default);
}

