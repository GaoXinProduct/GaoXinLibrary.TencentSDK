using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>异步导入接口服务实现</summary>
public class AsyncImportService : IAsyncImportService
{
    private readonly WecomHttpClient _http;

    public AsyncImportService(WecomHttpClient http) => _http = http;

    public async Task<string> SyncUserAsync(AsyncImportRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AsyncImportJobResponse>("/cgi-bin/batch/syncuser", request, ct);
        return resp.JobId;
    }

    public async Task<string> ReplaceUserAsync(AsyncImportRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AsyncImportJobResponse>("/cgi-bin/batch/replaceuser", request, ct);
        return resp.JobId;
    }

    public async Task<string> ReplacePartyAsync(AsyncImportRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AsyncImportJobResponse>("/cgi-bin/batch/replaceparty", request, ct);
        return resp.JobId;
    }

    public async Task<GetAsyncJobResultResponse> GetResultAsync(string jobId, CancellationToken ct = default)
        => await _http.GetAsync<GetAsyncJobResultResponse>("/cgi-bin/batch/getresult",
            new() { ["jobid"] = jobId }, ct);
}
