using System.Globalization;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Student;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Parent;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Department;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.HealthReport;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Living;
using GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.ClassPayment;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 家校沟通服务实现。
/// 提供家校通讯录、学校通知、健康上报、上课直播和班级收款相关操作。
/// </summary>
public sealed class HomeSchoolService
{
    private readonly WecomHttpClient _http;

    public HomeSchoolService(WecomHttpClient http) => _http = http;

    #region SchoolNotification

    /// <summary>
    /// 获取家长二维码。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90001
    /// </summary>
    public async Task<QrCodeResponse> GetQrCodeAsync(QrCodeRequest request, CancellationToken ct = default)
        => await _http.GetAsync<QrCodeResponse>("/cgi-bin/school/qrcode/get",
            new Dictionary<string, string?>
            {
                ["department_id"] = request.DepartmentId.ToString(),
                ["qrcode_type"] = request.QrcodeType,
                ["school_logo"] = request.SchoolLogo?.ToString()
            }, ct).ConfigureAwait(false);

    /// <summary>
    /// 发送学校通知。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90002
    /// </summary>
    public async Task<SchoolNotificationResponse> SendSchoolNotificationAsync(SchoolNotificationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SchoolNotificationResponse>("/cgi-bin/school/school_notifysend", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新家长关注模式。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90003
    /// </summary>
    public async Task<SchoolAttentionModeResponse> UpdateAttentionModeAsync(SchoolAttentionModeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SchoolAttentionModeResponse>("/cgi-bin/school/subscribe_mode/update", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新班级群创建模式。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90004
    /// </summary>
    public async Task<ClassGroupCreationResponse> UpdateClassGroupCreationModeAsync(ClassGroupCreationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ClassGroupCreationResponse>("/cgi-bin/school/classgroup/create_mode/update", request, ct).ConfigureAwait(false);

    #endregion

    #region ExternalContact

    /// <summary>
    /// 转换家校沟通外部联系人openid。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90005
    /// </summary>
    public async Task<ExternalContactOpenIdResponse> ConvertOpenIdAsync(ExternalContactOpenIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ExternalContactOpenIdResponse>("/cgi-bin/school/externalcontact/get_corp_conversation_list", request, ct).ConfigureAwait(false);

    #endregion

    #region ParentScope

    /// <summary>
    /// 获取家长范围。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90006
    /// </summary>
    public async Task<ParentScopeResponse> GetParentScopeAsync(ParentScopeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ParentScopeResponse>("/cgi-bin/school/parent/get_permit_user_list", request, ct).ConfigureAwait(false);

    #endregion

    #region Student Management

    /// <summary>
    /// 创建学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92325
    /// </summary>
    public async Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateStudentResponse>("/cgi-bin/school/user/create_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92326
    /// </summary>
    public async Task DeleteStudentAsync(DeleteStudentRequest request, CancellationToken ct = default)
        => await _http.GetWithoutTransientRetryAsync<WecomBaseResponse>("/cgi-bin/school/user/delete_student",
            new() { ["userid"] = request.StudentUserid }, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92327
    /// </summary>
    public async Task UpdateStudentAsync(UpdateStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/user/update_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量创建学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92328
    /// </summary>
    public Task<BatchCreateStudentResponse> BatchCreateStudentAsync(BatchCreateStudentRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchCreateStudentResponse>("/cgi-bin/school/user/batch_create_student", new
        {
            Students = request.Students.Select(student => new
            {
                student.StudentUserid,
                student.Mobile,
                student.ToInvite,
                student.Name,
                student.Department
            })
        }, ct);

    /// <summary>
    /// 批量删除学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92329
    /// </summary>
    public async Task<BatchDeleteStudentResponse> BatchDeleteStudentAsync(BatchDeleteStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchDeleteStudentResponse>("/cgi-bin/school/user/batch_delete_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量更新学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92330
    /// </summary>
    public Task<BatchUpdateStudentResponse> BatchUpdateStudentAsync(BatchUpdateStudentRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchUpdateStudentResponse>("/cgi-bin/school/user/batch_update_student", new
        {
            Students = request.Students.Select(student => new
            {
                student.StudentUserid,
                student.Mobile,
                student.NewStudentUserid,
                student.Name,
                student.Department
            })
        }, ct);

    /// <summary>
    /// 获取学生详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92337
    /// </summary>
    public Task<GetStudentResponse> GetStudentAsync(GetStudentRequest request, CancellationToken ct = default)
        => _http.GetAsync<GetStudentResponse>("/cgi-bin/school/user/get",
            new() { ["userid"] = request.StudentUserid }, ct);

    /// <summary>
    /// 获取部门学生详情列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92338
    /// </summary>
    public Task<GetDepartmentStudentsDetailResponse> GetDepartmentStudentsDetailAsync(GetDepartmentStudentsDetailRequest request, CancellationToken ct = default)
        => _http.GetAsync<GetDepartmentStudentsDetailResponse>("/cgi-bin/school/user/list",
            new() { ["department_id"] = request.DepartmentId.ToString(CultureInfo.InvariantCulture) }, ct);

    /// <summary>
    /// 获取部门家长详情列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92446
    /// </summary>
    public Task<GetDepartmentParentsDetailResponse> GetDepartmentParentsDetailAsync(GetDepartmentParentsDetailRequest request, CancellationToken ct = default)
        => _http.GetAsync<GetDepartmentParentsDetailResponse>("/cgi-bin/school/user/list_parent",
            new() { ["department_id"] = request.DepartmentId.ToString(CultureInfo.InvariantCulture) }, ct);

    /// <summary>
    /// 设置自动同步模式。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90110
    /// </summary>
    public async Task<SetAutoSyncModeResponse> SetAutoSyncModeAsync(SetAutoSyncModeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetAutoSyncModeResponse>("/cgi-bin/school/address_sync/set_auto_sync", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取标准年级。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90111
    /// </summary>
    public async Task<StandardGradeResponse> GetStandardGradeAsync(StandardGradeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<StandardGradeResponse>("/cgi-bin/school/grade/get_standard_grade", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新自动升级配置。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90112
    /// </summary>
    public async Task<UpdateAutoUpgradeConfigResponse> UpdateAutoUpgradeConfigAsync(UpdateAutoUpgradeConfigRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UpdateAutoUpgradeConfigResponse>("/cgi-bin/school/grade/update_auto_upgrade_config", request, ct).ConfigureAwait(false);

    #endregion

    #region Parent Management

    /// <summary>
    /// 创建家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92331
    /// </summary>
    public async Task<CreateParentResponse> CreateParentAsync(CreateParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateParentResponse>("/cgi-bin/school/user/create_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92332
    /// </summary>
    public async Task DeleteParentAsync(DeleteParentRequest request, CancellationToken ct = default)
        => await _http.GetWithoutTransientRetryAsync<WecomBaseResponse>("/cgi-bin/school/user/delete_parent",
            new() { ["userid"] = request.ParentUserid }, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92333
    /// </summary>
    public async Task UpdateParentAsync(UpdateParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/user/update_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量创建家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92334
    /// </summary>
    public Task<BatchCreateParentResponse> BatchCreateParentAsync(BatchCreateParentRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchCreateParentResponse>("/cgi-bin/school/user/batch_create_parent", new
        {
            Parents = request.Parents.Select(parent => new
            {
                parent.ParentUserid,
                parent.Mobile,
                parent.ToInvite,
                parent.Children
            })
        }, ct);

    /// <summary>
    /// 批量删除家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92335
    /// </summary>
    public async Task<BatchDeleteParentResponse> BatchDeleteParentAsync(BatchDeleteParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchDeleteParentResponse>("/cgi-bin/school/user/batch_delete_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量更新家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92336
    /// </summary>
    public Task<BatchUpdateParentResponse> BatchUpdateParentAsync(BatchUpdateParentRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchUpdateParentResponse>("/cgi-bin/school/user/batch_update_parent", new
        {
            Parents = request.Parents.Select(parent => new
            {
                parent.ParentUserid,
                parent.Mobile,
                parent.NewParentUserid,
                parent.Children
            })
        }, ct);

    /// <summary>
    /// 获取家长详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92337
    /// </summary>
    public Task<GetParentResponse> GetParentAsync(GetParentRequest request, CancellationToken ct = default)
        => _http.GetAsync<GetParentResponse>("/cgi-bin/school/user/get",
            new() { ["userid"] = request.ParentUserid }, ct);

    #endregion

    #region Department Management

    /// <summary>
    /// 创建部门（家校场景）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92340
    /// </summary>
    public async Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateDepartmentResponse>("/cgi-bin/school/department/create", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新部门。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92341
    /// </summary>
    public async Task UpdateDepartmentAsync(UpdateDepartmentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/department/update", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除部门。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92342
    /// </summary>
    public async Task DeleteDepartmentAsync(DeleteDepartmentRequest request, CancellationToken ct = default)
        => await _http.GetWithoutTransientRetryAsync<WecomBaseResponse>("/cgi-bin/school/department/delete",
            new() { ["id"] = request.Id.ToString(CultureInfo.InvariantCulture) }, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取部门列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/92343
    /// </summary>
    public async Task<GetDepartmentListResponse> GetDepartmentListAsync(GetDepartmentListRequest request, CancellationToken ct = default)
        => await _http.GetAsync<GetDepartmentListResponse>("/cgi-bin/school/department/list",
            new() { ["id"] = request.Id?.ToString(CultureInfo.InvariantCulture) }, ct).ConfigureAwait(false);

    #endregion

    #region HealthReport

    /// <summary>
    /// 获取健康上报统计。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93676
    /// </summary>
    public Task<GetHealthReportStatResponse> GetHealthReportStatAsync(GetHealthReportStatRequest request, CancellationToken ct = default)
    {
        ValidateHealthReportDate(request.Date);
        return _http.PostQueryAsync<GetHealthReportStatResponse>("/cgi-bin/health/get_health_report_stat", request, ct);
    }

    /// <summary>
    /// 获取健康上报任务ID列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93677
    /// </summary>
    public async Task<GetHealthReportTaskIdListResponse> GetHealthReportTaskIdListAsync(GetHealthReportTaskIdListRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostQueryAsync<GetHealthReportTaskIdListResponse>("/cgi-bin/health/get_report_jobids", request, ct).ConfigureAwait(false);
        response.TaskIdList = response.JobIds?.Select(id => new TaskIdItem { TaskId = id }).ToArray();
        return response;
    }

    /// <summary>
    /// 获取健康上报任务详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93678
    /// </summary>
    public async Task<GetHealthReportTaskDetailResponse> GetHealthReportTaskDetailAsync(GetHealthReportTaskDetailRequest request, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.TaskId);
        ValidateHealthReportDate(request.Date);
        var response = await _http.PostQueryAsync<GetHealthReportTaskDetailResponse>("/cgi-bin/health/get_report_job_info", request, ct).ConfigureAwait(false);
        if (response.TaskInfo is not null)
            response.TaskInfo = response.TaskInfo with { TaskId = request.TaskId };
        return response;
    }

    /// <summary>
    /// 获取健康上报答题结果。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93679
    /// </summary>
    public Task<GetHealthReportAnswersResponse> GetHealthReportAnswersAsync(GetHealthReportAnswersRequest request, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.TaskId);
        ValidateHealthReportDate(request.Date);
        return _http.PostQueryAsync<GetHealthReportAnswersResponse>("/cgi-bin/health/get_report_answer", request, ct);
    }

    private static void ValidateHealthReportDate(string? date)
    {
        if (!DateOnly.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            throw new ArgumentException("健康上报日期须使用 yyyy-MM-dd 格式。", nameof(date));
    }

    #endregion

    #region Living

    /// <summary>
    /// 获取上课直播ID列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93739
    /// </summary>
    public async Task<GetLivingIdListResponse> GetLivingIdListAsync(GetLivingIdListRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostQueryAsync<GetLivingIdListResponse>("/cgi-bin/living/get_user_all_livingid", request, ct).ConfigureAwait(false);
        response.LivingidList = response.LivingIds?.Select(id => new LivingIdItem { Livingid = id }).ToArray();
        return response;
    }

    /// <summary>
    /// 获取上课直播详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93740
    /// </summary>
    public async Task<GetLivingDetailResponse> GetLivingDetailAsync(GetLivingDetailRequest request, CancellationToken ct = default)
    {
        var response = await _http.GetAsync<GetLivingDetailResponse>("/cgi-bin/school/living/get_living_info",
            new() { ["livingid"] = request.Livingid }, ct).ConfigureAwait(false);
        if (response.LivingInfo is not null)
            response.LivingInfo = response.LivingInfo with { Livingid = request.Livingid };
        return response;
    }

    /// <summary>
    /// 获取上课直播观看统计。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93741
    /// </summary>
    public async Task<GetLivingWatchStatResponse> GetLivingWatchStatAsync(GetLivingWatchStatRequest request, CancellationToken ct = default)
        => await _http.PostQueryAsync<GetLivingWatchStatResponse>("/cgi-bin/school/living/get_watch_stat", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播未观看统计。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93742
    /// </summary>
    public async Task<GetLivingNotWatchStatResponse> GetLivingNotWatchStatAsync(GetLivingNotWatchStatRequest request, CancellationToken ct = default)
        => await _http.PostQueryAsync<GetLivingNotWatchStatResponse>("/cgi-bin/school/living/get_unwatch_stat", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除上课直播回放。
    /// 文档：https://developer.work.weixin.qq.com/document/path/93743
    /// </summary>
    public async Task<DeleteReplayDataResponse> DeleteReplayDataAsync(DeleteReplayDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteReplayDataResponse>("/cgi-bin/living/delete_replay_data", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播观看统计（V2）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/95793
    /// </summary>
    public async Task<GetLivingWatchStatV2Response> GetLivingWatchStatV2Async(GetLivingWatchStatV2Request request, CancellationToken ct = default)
        => await _http.PostQueryAsync<GetLivingWatchStatV2Response>("/cgi-bin/school/living/get_watch_stat_v2", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播未观看统计（V2）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/95795
    /// </summary>
    public async Task<GetLivingNotWatchStatV2Response> GetLivingNotWatchStatV2Async(GetLivingNotWatchStatV2Request request, CancellationToken ct = default)
        => await _http.PostQueryAsync<GetLivingNotWatchStatV2Response>("/cgi-bin/school/living/get_unwatch_stat_v2", request, ct).ConfigureAwait(false);

    #endregion

    #region ClassPayment

    /// <summary>
    /// 获取学生班级付款结果。
    /// 文档：https://developer.work.weixin.qq.com/document/path/94470
    /// </summary>
    public async Task<GetStudentPaymentResultResponse> GetStudentPaymentResultAsync(GetStudentPaymentResultRequest request, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.PaymentId);
        var response = await _http.PostQueryAsync<GetStudentPaymentResultResponse>("/cgi-bin/school/get_payment_result", request, ct).ConfigureAwait(false);
        if (!string.IsNullOrEmpty(request.StudentUserid) && response.PaymentResult is not null)
        {
            response.PaymentResult = response.PaymentResult
                .Where(item => string.Equals(item.StudentUserid, request.StudentUserid, StringComparison.OrdinalIgnoreCase))
                .ToArray();
            response.PayStatus = response.PaymentResult.FirstOrDefault()?.TradeState ?? 0;
        }
        return response;
    }

    /// <summary>
    /// 获取订单详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/94471
    /// </summary>
    public Task<GetOrderDetailResponse> GetOrderDetailAsync(GetOrderDetailRequest request, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.PaymentId);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.TradeNo);
        return _http.PostQueryAsync<GetOrderDetailResponse>("/cgi-bin/school/get_trade", request, ct);
    }

    #endregion
}
