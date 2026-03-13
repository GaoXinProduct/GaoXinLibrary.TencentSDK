using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>操作日志服务实现</summary>
public class OperationLogService : IOperationLogService
{
    private readonly WecomHttpClient _http;

    public OperationLogService(WecomHttpClient http) => _http = http;

    public async Task<GetOperationLogResponse> GetUserOperationRecordAsync(GetOperationLogRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetOperationLogResponse>("/cgi-bin/security/get_user_oper_record", request, ct);

    public async Task<GetOperationLogResponse> GetAdminOperationRecordAsync(GetOperationLogRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetOperationLogResponse>("/cgi-bin/security/get_admin_oper_record", request, ct);
}
