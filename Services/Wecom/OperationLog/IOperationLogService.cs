using GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>操作日志服务接口</summary>
public interface IOperationLogService
{
    /// <summary>获取成员操作记录</summary>
    Task<GetOperationLogResponse> GetUserOperationRecordAsync(GetOperationLogRequest request, CancellationToken ct = default);

    /// <summary>获取管理端操作日志</summary>
    Task<GetOperationLogResponse> GetAdminOperationRecordAsync(GetOperationLogRequest request, CancellationToken ct = default);
}
