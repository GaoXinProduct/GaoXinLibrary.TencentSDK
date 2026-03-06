using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Export;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>异步导出接口服务实现</summary>
public class ExportService : IExportService
{
    private readonly WecomHttpClient _http;

    public ExportService(WecomHttpClient http) => _http = http;

    /// <inheritdoc/>
    public async Task<string> ExportSimpleUserAsync(string encodingAesKey, int? blockSize = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ExportJobResponse>(
            "/cgi-bin/export/simple_user",
            new ExportRequest { EncodingAesKey = encodingAesKey, BlockSize = blockSize }, ct);
        return resp.JobId;
    }

    /// <inheritdoc/>
    public async Task<string> ExportUserAsync(string encodingAesKey, int? blockSize = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ExportJobResponse>(
            "/cgi-bin/export/user",
            new ExportRequest { EncodingAesKey = encodingAesKey, BlockSize = blockSize }, ct);
        return resp.JobId;
    }

    /// <inheritdoc/>
    public async Task<string> ExportDepartmentAsync(string encodingAesKey, int? blockSize = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ExportJobResponse>(
            "/cgi-bin/export/department",
            new ExportRequest { EncodingAesKey = encodingAesKey, BlockSize = blockSize }, ct);
        return resp.JobId;
    }

    /// <inheritdoc/>
    public async Task<string> ExportTagUserAsync(int tagId, string encodingAesKey, int? blockSize = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ExportJobResponse>(
            "/cgi-bin/export/taguser",
            new ExportTagUserRequest { TagId = tagId, EncodingAesKey = encodingAesKey, BlockSize = blockSize }, ct);
        return resp.JobId;
    }

    /// <inheritdoc/>
    public async Task<GetExportResultResponse> GetExportResultAsync(string jobId, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetExportResultResponse>(
            "/cgi-bin/export/get_result",
            new GetExportResultRequest { JobId = jobId }, ct);
    }
}
