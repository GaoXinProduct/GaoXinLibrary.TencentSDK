using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Report;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>汇报服务实现</summary>
public class ReportService : IReportService
{
    private readonly WecomHttpClient _http;

    public ReportService(WecomHttpClient http) => _http = http;

    public async Task<string[]> GetReportListAsync(long startTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetReportListResponse>("/cgi-bin/oa/journal/get_record_list",
            new { starttime = startTime, endtime = endTime, cursor = cursor ?? "", limit }, ct);
        return resp.SpNoList ?? [];
    }

    public async Task<ReportInfo?> GetReportDetailAsync(string spNo, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetReportDetailResponse>("/cgi-bin/oa/journal/get_record_detail",
            new { journaluuid = spNo }, ct);
        return resp.ReportInfo;
    }
}
