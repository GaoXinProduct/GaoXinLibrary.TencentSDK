using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 审批服务接口
/// <para>
/// 提供审批模板查询、审批申请提交、审批单号批量获取、审批详情查询及假期管理等功能。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/91854"/>
/// </para>
/// </summary>
public interface IApprovalService
{
    // ─── 审批 ─────────────────────────────────────────────────────────────

    /// <summary>获取审批模板详情</summary>
    /// <param name="templateId">模板 id</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>模板详情</returns>
    Task<GetTemplateDetailResponse> GetTemplateDetailAsync(string templateId, CancellationToken ct = default);

    /// <summary>提交审批申请</summary>
    /// <param name="request">审批申请请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批单号</returns>
    Task<string> ApplyEventAsync(ApplyEventRequest request, CancellationToken ct = default);

    /// <summary>批量获取审批单号</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批单号列表及下一游标</returns>
    Task<GetApprovalInfoResponse> GetApprovalInfoAsync(GetApprovalInfoRequest request, CancellationToken ct = default);

    /// <summary>获取审批申请详情</summary>
    /// <param name="spNo">审批单号</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批详情</returns>
    Task<ApprovalDetailInfo?> GetApprovalDetailAsync(string spNo, CancellationToken ct = default);

    // ─── 假期管理 ──────────────────────────────────────────────────────────

    /// <summary>获取企业假期管理配置</summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>假期配置列表</returns>
    Task<VacationConfig[]> GetCorpVacationConfAsync(CancellationToken ct = default);

    /// <summary>获取成员假期余额</summary>
    /// <param name="userId">成员 userid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>假期余额列表</returns>
    Task<UserVacationQuota[]> GetUserVacationQuotaAsync(string userId, CancellationToken ct = default);

    /// <summary>修改成员假期余额</summary>
    /// <param name="request">修改请求</param>
    /// <param name="ct">取消令牌</param>
    Task SetOneUserQuotaAsync(SetOneUserQuotaRequest request, CancellationToken ct = default);

    // ─── 旧版审批接口 ──────────────────────────────────────────────────────

    /// <summary>获取审批数据（旧）</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批数据响应</returns>
    Task<GetApprovalDataResponse> GetApprovalDataAsync(GetApprovalDataRequest request, CancellationToken ct = default);

    // ─── 审批模板管理 ──────────────────────────────────────────────────────

    /// <summary>创建审批模板</summary>
    /// <param name="request">创建请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>模板 id</returns>
    Task<string> CreateTemplateAsync(CreateTemplateRequest request, CancellationToken ct = default);

    /// <summary>更新审批模板</summary>
    /// <param name="request">更新请求</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateTemplateAsync(UpdateTemplateRequest request, CancellationToken ct = default);
}
