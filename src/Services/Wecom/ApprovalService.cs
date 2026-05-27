using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Approval;
using GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>审批服务实现</summary>
public sealed class ApprovalService
{
    private readonly WecomHttpClient _http;

    public ApprovalService(WecomHttpClient http)
    {
        _http = http;
    }

    #region 审批

    /// <summary>获取审批模板详情</summary>
    /// <param name="templateId">模板 id</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>模板详情</returns>
    public async Task<GetTemplateDetailResponse> GetTemplateDetailAsync(string templateId, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetTemplateDetailResponse>(
            "/cgi-bin/oa/gettemplatedetail",
            new GetTemplateDetailRequest { TemplateId = templateId }, ct).ConfigureAwait(false);
    }

    /// <summary>提交审批申请</summary>
    /// <param name="request">审批申请请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批单号</returns>
    public async Task<string> ApplyEventAsync(ApplyEventRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ApplyEventResponse>(
            "/cgi-bin/oa/applyevent", request, ct).ConfigureAwait(false);
        return resp.SpNo ?? string.Empty;
    }

    /// <summary>提交审批申请</summary>
    /// <param name="request">审批申请请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批单号</returns>
    public async Task<string> ApplyEventAsync(Action<ApplyEventBuilder> configure, CancellationToken ct = default)
    {
        var builder = new ApplyEventBuilder();
        configure(builder);
        return await ApplyEventAsync(builder.Build(), ct).ConfigureAwait(false);
    }

    /// <summary>批量获取审批单号</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批单号列表及下一游标</returns>
    public async Task<GetApprovalInfoResponse> GetApprovalInfoAsync(GetApprovalInfoRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetApprovalInfoResponse>(
            "/cgi-bin/oa/getapprovalinfo", request, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// 批量获取审批单号（自动分页，获取所有结果）
    /// </summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="filters">筛选条件（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>所有审批单号列表</returns>
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
            }, ct).ConfigureAwait(false);

            if (resp.SpNoList is { Length: > 0 })
                allSpNos.AddRange(resp.SpNoList);

            if (resp.NewNextCursor is null or 0 || resp.SpNoList is null or { Length: 0 })
                break;

            cursor = resp.NewNextCursor.Value;
        }

        return allSpNos;
    }

    /// <summary>获取审批申请详情</summary>
    /// <param name="spNo">审批单号</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批详情</returns>
    public async Task<ApprovalDetailInfo?> GetApprovalDetailAsync(string spNo, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetApprovalDetailResponse>(
            "/cgi-bin/oa/getapprovaldetail",
            new GetApprovalDetailRequest { SpNo = spNo }, ct).ConfigureAwait(false);
        return resp.Info;
    }

    #endregion
    #region 假期管理

    /// <summary>获取企业假期管理配置</summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>假期配置列表</returns>
    public async Task<VacationConfig[]> GetCorpVacationConfAsync(CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCorpVacationConfResponse>(
            "/cgi-bin/oa/vacation/getcorpconf",
            EmptyRequest.Instance, ct).ConfigureAwait(false);
        return resp.Lists ?? [];
    }

    /// <summary>获取成员假期余额</summary>
    /// <param name="userId">成员 userid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>假期余额列表</returns>
    public async Task<UserVacationQuota[]> GetUserVacationQuotaAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetUserVacationQuotaResponse>(
            "/cgi-bin/oa/vacation/getuservacationquota",
            new GetUserVacationQuotaRequest { UserId = userId }, ct).ConfigureAwait(false);
        return resp.Lists ?? [];
    }

    /// <summary>修改成员假期余额</summary>
    /// <param name="request">修改请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task SetOneUserQuotaAsync(SetOneUserQuotaRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/oa/vacation/setoneuserquota", request, ct).ConfigureAwait(false);
    }

    #endregion
    #region 旧版审批接口

    /// <summary>获取审批数据（旧）</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批数据响应</returns>
    public async Task<GetApprovalDataResponse> GetApprovalDataAsync(GetApprovalDataRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetApprovalDataResponse>(
            "/cgi-bin/corp/getapprovaldata", request, ct).ConfigureAwait(false);
    }

    #endregion
    #region 审批模板管理

    /// <summary>创建审批模板</summary>
    /// <param name="request">创建请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>模板 id</returns>
    public async Task<string> CreateTemplateAsync(CreateTemplateRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateTemplateResponse>(
            "/cgi-bin/oa/approval/create_template", request, ct).ConfigureAwait(false);
        return resp.TemplateId ?? string.Empty;
    }

    /// <summary>更新审批模板</summary>
    /// <param name="request">更新请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateTemplateAsync(UpdateTemplateRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/oa/approval/update_template", request, ct).ConfigureAwait(false);
    }
    #endregion
    #region 审批模板管理（新版工作台引擎）

    /// <summary>创建审批模板（新版工作台引擎）</summary>
    /// <param name="request">创建请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>模板 id</returns>
    public async Task<string> CreateWorkflowTemplateAsync(CreateWorkflowRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateWorkflowResponse>(
            "/cgi-bin/oa/approval/create_workflow_template", request, ct).ConfigureAwait(false);
        return resp.TemplateId ?? string.Empty;
    }

    /// <summary>更新审批模板（新版工作台引擎）</summary>
    /// <param name="request">更新请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>更新时间</returns>
    public async Task<long> UpdateWorkflowTemplateAsync(UpdateWorkflowRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<UpdateWorkflowResponse>(
            "/cgi-bin/oa/approval/update_workflow_template", request, ct).ConfigureAwait(false);
        return resp.UpdateTime;
    }

    /// <summary>获取审批模板详情（新版工作台引擎）</summary>
    /// <param name="templateId">模板 id</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>模板详情</returns>
    public async Task<GetWorkflowDetailResponse> GetWorkflowTemplateDetailAsync(string templateId, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetWorkflowDetailResponse>(
            "/cgi-bin/oa/approval/get_workflow_template_detail",
            new GetWorkflowDetailRequest { TemplateId = templateId }, ct).ConfigureAwait(false);
    }

    #endregion
}
