using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>操作日志服务实现</summary>
public class OperationLogService : IOperationLogService
{
    private readonly WecomHttpClient _http;

    public OperationLogService(WecomHttpClient http) => _http = http;

    public async Task<GetOperationLogResponse> GetUserOperationRecordAsync(long startTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetOperationLogResponse>("/cgi-bin/security/get_user_oper_record",
            new { start_time = startTime, end_time = endTime, cursor = cursor ?? "", limit }, ct);

    public async Task<GetOperationLogResponse> GetAdminOperationRecordAsync(long startTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetOperationLogResponse>("/cgi-bin/security/get_admin_oper_record",
            new { start_time = startTime, end_time = endTime, cursor = cursor ?? "", limit }, ct);
}
