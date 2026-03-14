using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>审批服务实现</summary>
public class ApprovalService : IApprovalService
{
    private readonly WecomHttpClient _http;

    public ApprovalService(WecomHttpClient http)
    {
        _http = http;
    }

    // ─── 审批 ─────────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<GetTemplateDetailResponse> GetTemplateDetailAsync(string templateId, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetTemplateDetailResponse>(
            "/cgi-bin/oa/gettemplatedetail",
            new GetTemplateDetailRequest { TemplateId = templateId }, ct);
    }

    /// <inheritdoc/>
    public async Task<string> ApplyEventAsync(ApplyEventRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ApplyEventResponse>(
            "/cgi-bin/oa/applyevent", request, ct);
        return resp.SpNo ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task<string> ApplyEventAsync(Action<ApplyEventBuilder> configure, CancellationToken ct = default)
    {
        var builder = new ApplyEventBuilder();
        configure(builder);
        return await ApplyEventAsync(builder.Build(), ct);
    }

    /// <inheritdoc/>
    public async Task<GetApprovalInfoResponse> GetApprovalInfoAsync(GetApprovalInfoRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetApprovalInfoResponse>(
            "/cgi-bin/oa/getapprovalinfo", request, ct);
    }

    /// <inheritdoc/>
    public async Task<List<string>> GetAllApprovalNoAsync(long startTime, long endTime, ApprovalFilter[]? filters = null, CancellationToken ct = default)
    {
        var allSpNos = new List<string>();
        var cursor = 0;

        while (true)
        {
            ct.ThrowIfCancellationRequested();

            var resp = await GetApprovalInfoAsync(new GetApprovalInfoRequest
            {
                StartTime = startTime,
                EndTime = endTime,
                Cursor = cursor,
                Size = 100,
                Filters = filters
            }, ct);

            if (resp.SpNoList is { Length: > 0 })
                allSpNos.AddRange(resp.SpNoList);

            if (resp.NewNextCursor is null or 0 || resp.SpNoList is null or { Length: 0 })
                break;

            cursor = resp.NewNextCursor.Value;
        }

        return allSpNos;
    }

    /// <inheritdoc/>
    public async Task<ApprovalDetailInfo?> GetApprovalDetailAsync(string spNo, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetApprovalDetailResponse>(
            "/cgi-bin/oa/getapprovaldetail",
            new GetApprovalDetailRequest { SpNo = spNo }, ct);
        return resp.Info;
    }

    // ─── 假期管理 ──────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<VacationConfig[]> GetCorpVacationConfAsync(CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCorpVacationConfResponse>(
            "/cgi-bin/oa/vacation/getcorpconf",
            EmptyRequest.Instance, ct);
        return resp.Lists ?? [];
    }

    /// <inheritdoc/>
    public async Task<UserVacationQuota[]> GetUserVacationQuotaAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetUserVacationQuotaResponse>(
            "/cgi-bin/oa/vacation/getuservacationquota",
            new GetUserVacationQuotaRequest { UserId = userId }, ct);
        return resp.Lists ?? [];
    }

    /// <inheritdoc/>
    public async Task SetOneUserQuotaAsync(SetOneUserQuotaRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/oa/vacation/setoneuserquota", request, ct);
    }

    // ─── 旧版审批接口 ──────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<GetApprovalDataResponse> GetApprovalDataAsync(GetApprovalDataRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetApprovalDataResponse>(
            "/cgi-bin/corp/getapprovaldata", request, ct);
    }

    // ─── 审批模板管理 ──────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<string> CreateTemplateAsync(CreateTemplateRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateTemplateResponse>(
            "/cgi-bin/oa/approval/create_template", request, ct);
        return resp.TemplateId ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task UpdateTemplateAsync(UpdateTemplateRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/oa/approval/update_template", request, ct);
    }
}
