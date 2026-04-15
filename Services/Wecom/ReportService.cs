using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Report;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>汇报服务实现</summary>
public class ReportService
{
    private readonly WecomHttpClient _http;

    public ReportService(WecomHttpClient http) => _http = http;

    /// <summary>批量获取汇报记录单号</summary>
    public async Task<string[]> GetReportListAsync(GetReportListRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetReportListResponse>("/cgi-bin/oa/journal/get_record_list", request, ct);
        return resp.SpNoList ?? [];
    }

    /// <summary>获取汇报记录详情</summary>
    public async Task<ReportInfo?> GetReportDetailAsync(GetReportDetailRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetReportDetailResponse>("/cgi-bin/oa/journal/get_record_detail", request, ct);
        return resp.ReportInfo;
    }
}
