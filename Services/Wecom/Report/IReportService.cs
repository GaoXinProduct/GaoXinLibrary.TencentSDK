using GaoXinLibrary.TencentSDK.Wecom.Models.Report;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>汇报服务接口</summary>
public interface IReportService
{
    /// <summary>批量获取汇报记录单号</summary>
    Task<string[]> GetReportListAsync(long startTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default);

    /// <summary>获取汇报记录详情</summary>
    Task<ReportInfo?> GetReportDetailAsync(string spNo, CancellationToken ct = default);
}
