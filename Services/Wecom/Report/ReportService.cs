using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Report;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>汇报服务实现</summary>
public class ReportService : IReportService
{
    private readonly WecomHttpClient _http;

    public ReportService(WecomHttpClient http) => _http = http;

    public async Task<string[]> GetReportListAsync(GetReportListRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetReportListResponse>("/cgi-bin/oa/journal/get_record_list", request, ct);
        return resp.SpNoList ?? [];
    }

    public async Task<ReportInfo?> GetReportDetailAsync(GetReportDetailRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetReportDetailResponse>("/cgi-bin/oa/journal/get_record_detail", request, ct);
        return resp.ReportInfo;
    }
}
