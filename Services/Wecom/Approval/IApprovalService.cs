using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 审批服务接口
/// <para>
/// 提供审批模板查询、审批申请提交、审批单号批量获取、审批详情查询及假期管理等功能。<br/>
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/91854"/>
/// </para>
/// <para>
/// <b>快速提交审批：</b>
/// <code>
/// var spNo = await approval.ApplyEventAsync(b => b
///     .SetCreator("zhangsan")
///     .SetTemplate("3TkZjxugodbqpEMk5bRCFTHEHidgwegDnhVj4")
///     .UseTemplateApprover()
///     .AddText("Text-1", "出差事由：拜访客户")
///     .AddDateRange("DateRange-1", "day", start, end)
///     .AddSummary("出差申请", "张三", "2天"));
/// </code>
/// </para>
/// <para>
/// <b>回调处理：</b>
/// <code>
/// var msg = callback.DecryptAndParse(signature, timestamp, nonce, body);
/// if (msg is CallbackApprovalEvent approval)
/// {
///     Console.WriteLine($"审批单号={approval.SpNo}, 状态={approval.SpStatus}");
/// }
/// </code>
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

    /// <summary>
    /// 通过构建器提交审批申请（简化版）
    /// <para>
    /// <code>
    /// var spNo = await approval.ApplyEventAsync(b => b
    ///     .SetCreator("zhangsan")
    ///     .SetTemplate("templateId")
    ///     .UseTemplateApprover()
    ///     .AddText("Text-1", "出差事由")
    ///     .AddSummary("出差申请"));
    /// </code>
    /// </para>
    /// </summary>
    /// <param name="configure">构建器配置委托</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批单号</returns>
    Task<string> ApplyEventAsync(Action<ApplyEventBuilder> configure, CancellationToken ct = default);

    /// <summary>批量获取审批单号</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>审批单号列表及下一游标</returns>
    Task<GetApprovalInfoResponse> GetApprovalInfoAsync(GetApprovalInfoRequest request, CancellationToken ct = default);

    /// <summary>
    /// 批量获取审批单号（自动分页，获取所有结果）
    /// </summary>
    /// <param name="startTime">开始时间（Unix 时间戳）</param>
    /// <param name="endTime">结束时间（Unix 时间戳）</param>
    /// <param name="filters">筛选条件（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>所有审批单号列表</returns>
    Task<List<string>> GetAllApprovalNoAsync(long startTime, long endTime, ApprovalFilter[]? filters = null, CancellationToken ct = default);

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
