using GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>操作日志服务接口</summary>
public interface IOperationLogService
{
    /// <summary>获取成员操作记录</summary>
    Task<GetOperationLogResponse> GetUserOperationRecordAsync(long startTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default);

    /// <summary>获取管理端操作日志</summary>
    Task<GetOperationLogResponse> GetAdminOperationRecordAsync(long startTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default);
}
