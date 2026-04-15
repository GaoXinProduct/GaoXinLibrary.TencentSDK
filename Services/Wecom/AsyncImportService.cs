using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>异步导入接口服务实现</summary>
public class AsyncImportService
{
    private readonly WecomHttpClient _http;

    public AsyncImportService(WecomHttpClient http) => _http = http;

    /// <summary>增量更新成员</summary>
    public async Task<string> SyncUserAsync(AsyncImportRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AsyncImportJobResponse>("/cgi-bin/batch/syncuser", request, ct);
        return resp.JobId;
    }

    /// <summary>全量覆盖成员</summary>
    public async Task<string> ReplaceUserAsync(AsyncImportRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AsyncImportJobResponse>("/cgi-bin/batch/replaceuser", request, ct);
        return resp.JobId;
    }

    /// <summary>全量覆盖部门</summary>
    public async Task<string> ReplacePartyAsync(AsyncImportRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AsyncImportJobResponse>("/cgi-bin/batch/replaceparty", request, ct);
        return resp.JobId;
    }

    /// <summary>获取异步任务结果</summary>
    public async Task<GetAsyncJobResultResponse> GetResultAsync(string jobId, CancellationToken ct = default)
        => await _http.GetAsync<GetAsyncJobResultResponse>("/cgi-bin/batch/getresult",
            new() { ["jobid"] = jobId }, ct);
}
