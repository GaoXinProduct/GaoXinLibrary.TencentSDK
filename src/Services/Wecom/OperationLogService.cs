using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>操作日志服务实现</summary>
public sealed class OperationLogService
{
    private readonly WecomHttpClient _http;

    public OperationLogService(WecomHttpClient http) => _http = http;

    /// <summary>获取成员操作记录。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/100178">成员操作记录接口</see></remarks>
    public Task<GetOperationLogResponse> GetUserOperationRecordAsync(GetOperationLogRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetOperationLogResponse>("/cgi-bin/security/member_oper_log/list", request, ct);

    /// <summary>获取管理端操作日志。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/100179">管理端操作日志接口</see></remarks>
    public Task<GetOperationLogResponse> GetAdminOperationRecordAsync(GetOperationLogRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetOperationLogResponse>("/cgi-bin/security/admin_oper_log/list", request, ct);
}
