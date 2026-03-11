using GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>异步导入接口服务</summary>
public interface IAsyncImportService
{
    /// <summary>增量更新成员</summary>
    Task<string> SyncUserAsync(AsyncImportRequest request, CancellationToken ct = default);

    /// <summary>全量覆盖成员</summary>
    Task<string> ReplaceUserAsync(AsyncImportRequest request, CancellationToken ct = default);

    /// <summary>全量覆盖部门</summary>
    Task<string> ReplacePartyAsync(AsyncImportRequest request, CancellationToken ct = default);

    /// <summary>获取异步任务结果</summary>
    Task<GetAsyncJobResultResponse> GetResultAsync(string jobId, CancellationToken ct = default);
}
