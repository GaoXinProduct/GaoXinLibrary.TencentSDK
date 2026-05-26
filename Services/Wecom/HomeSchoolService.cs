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
/// 覆盖学生/家长/部门管理、学校通知、关注模式、班级群创建、家长范围、openid转换、标准年级、自动升级、健康上报、上课直播、班级收款等全部功能。
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
    /// 文档：https://developer.work.weixin.qq.com/document/path/90101
    /// </summary>
    public async Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateStudentResponse>("/cgi-bin/school/user/create_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90102
    /// </summary>
    public async Task DeleteStudentAsync(DeleteStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/user/delete_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90103
    /// </summary>
    public async Task UpdateStudentAsync(UpdateStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/user/update_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量创建学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90104
    /// </summary>
    public async Task<BatchCreateStudentResponse> BatchCreateStudentAsync(BatchCreateStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchCreateStudentResponse>("/cgi-bin/school/user/batch_create_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量删除学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90105
    /// </summary>
    public async Task<BatchDeleteStudentResponse> BatchDeleteStudentAsync(BatchDeleteStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchDeleteStudentResponse>("/cgi-bin/school/user/batch_delete_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量更新学生账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90106
    /// </summary>
    public async Task<BatchUpdateStudentResponse> BatchUpdateStudentAsync(BatchUpdateStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchUpdateStudentResponse>("/cgi-bin/school/user/batch_update_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取学生详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90107
    /// </summary>
    public async Task<GetStudentResponse> GetStudentAsync(GetStudentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetStudentResponse>("/cgi-bin/school/user/get_student", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取部门学生详情列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90108
    /// </summary>
    public async Task<GetDepartmentStudentsDetailResponse> GetDepartmentStudentsDetailAsync(GetDepartmentStudentsDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDepartmentStudentsDetailResponse>("/cgi-bin/school/user/get_department_students_detail", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取部门家长详情列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90109
    /// </summary>
    public async Task<GetDepartmentParentsDetailResponse> GetDepartmentParentsDetailAsync(GetDepartmentParentsDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDepartmentParentsDetailResponse>("/cgi-bin/school/user/get_department_parents_detail", request, ct).ConfigureAwait(false);

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
    /// 文档：https://developer.work.weixin.qq.com/document/path/90201
    /// </summary>
    public async Task<CreateParentResponse> CreateParentAsync(CreateParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateParentResponse>("/cgi-bin/school/user/create_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90202
    /// </summary>
    public async Task DeleteParentAsync(DeleteParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/user/delete_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90203
    /// </summary>
    public async Task UpdateParentAsync(UpdateParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/user/update_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量创建家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90204
    /// </summary>
    public async Task<BatchCreateParentResponse> BatchCreateParentAsync(BatchCreateParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchCreateParentResponse>("/cgi-bin/school/user/batch_create_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量删除家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90205
    /// </summary>
    public async Task<BatchDeleteParentResponse> BatchDeleteParentAsync(BatchDeleteParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchDeleteParentResponse>("/cgi-bin/school/user/batch_delete_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 批量更新家长账号。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90206
    /// </summary>
    public async Task<BatchUpdateParentResponse> BatchUpdateParentAsync(BatchUpdateParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchUpdateParentResponse>("/cgi-bin/school/user/batch_update_parent", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取家长详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90207
    /// </summary>
    public async Task<GetParentResponse> GetParentAsync(GetParentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetParentResponse>("/cgi-bin/school/user/get_parent", request, ct).ConfigureAwait(false);

    #endregion

    #region Department Management

    /// <summary>
    /// 创建部门（家校场景）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90301
    /// </summary>
    public async Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateDepartmentResponse>("/cgi-bin/school/department/create", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 更新部门。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90302
    /// </summary>
    public async Task UpdateDepartmentAsync(UpdateDepartmentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/department/update", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除部门。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90303
    /// </summary>
    public async Task DeleteDepartmentAsync(DeleteDepartmentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/school/department/delete", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取部门列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90304
    /// </summary>
    public async Task<GetDepartmentListResponse> GetDepartmentListAsync(GetDepartmentListRequest request, CancellationToken ct = default)
        => await _http.GetAsync<GetDepartmentListResponse>("/cgi-bin/school/department/list",
            new Dictionary<string, string?> { ["id"] = request.Id?.ToString() }, ct).ConfigureAwait(false);

    #endregion

    #region HealthReport

    /// <summary>
    /// 获取健康上报统计。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90401
    /// </summary>
    public async Task<GetHealthReportStatResponse> GetHealthReportStatAsync(GetHealthReportStatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetHealthReportStatResponse>("/cgi-bin/school/health_report/get_stat", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取健康上报任务ID列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90402
    /// </summary>
    public async Task<GetHealthReportTaskIdListResponse> GetHealthReportTaskIdListAsync(GetHealthReportTaskIdListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetHealthReportTaskIdListResponse>("/cgi-bin/school/health_report/get_task_id_list", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取健康上报任务详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90403
    /// </summary>
    public async Task<GetHealthReportTaskDetailResponse> GetHealthReportTaskDetailAsync(GetHealthReportTaskDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetHealthReportTaskDetailResponse>("/cgi-bin/school/health_report/get_task_detail", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取健康上报答题结果。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90404
    /// </summary>
    public async Task<GetHealthReportAnswersResponse> GetHealthReportAnswersAsync(GetHealthReportAnswersRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetHealthReportAnswersResponse>("/cgi-bin/school/health_report/get_answers", request, ct).ConfigureAwait(false);

    #endregion

    #region Living

    /// <summary>
    /// 获取上课直播ID列表。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90501
    /// </summary>
    public async Task<GetLivingIdListResponse> GetLivingIdListAsync(GetLivingIdListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetLivingIdListResponse>("/cgi-bin/school/living/get_livingid_list", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90502
    /// </summary>
    public async Task<GetLivingDetailResponse> GetLivingDetailAsync(GetLivingDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetLivingDetailResponse>("/cgi-bin/school/living/get_living_detail", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播观看统计。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90503
    /// </summary>
    public async Task<GetLivingWatchStatResponse> GetLivingWatchStatAsync(GetLivingWatchStatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetLivingWatchStatResponse>("/cgi-bin/school/living/get_watch_stat", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播未观看统计。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90504
    /// </summary>
    public async Task<GetLivingNotWatchStatResponse> GetLivingNotWatchStatAsync(GetLivingNotWatchStatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetLivingNotWatchStatResponse>("/cgi-bin/school/living/get_not_watch_stat", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 删除上课直播回放。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90505
    /// </summary>
    public async Task<DeleteReplayDataResponse> DeleteReplayDataAsync(DeleteReplayDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteReplayDataResponse>("/cgi-bin/school/living/delete_replay_data", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播观看统计（V2）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90506
    /// </summary>
    public async Task<GetLivingWatchStatV2Response> GetLivingWatchStatV2Async(GetLivingWatchStatV2Request request, CancellationToken ct = default)
        => await _http.PostAsync<GetLivingWatchStatV2Response>("/cgi-bin/school/living/get_watch_stat_v2", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取上课直播未观看统计（V2）。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90507
    /// </summary>
    public async Task<GetLivingNotWatchStatV2Response> GetLivingNotWatchStatV2Async(GetLivingNotWatchStatV2Request request, CancellationToken ct = default)
        => await _http.PostAsync<GetLivingNotWatchStatV2Response>("/cgi-bin/school/living/get_not_watch_stat_v2", request, ct).ConfigureAwait(false);

    #endregion

    #region ClassPayment

    /// <summary>
    /// 获取学生班级付款结果。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90601
    /// </summary>
    public async Task<GetStudentPaymentResultResponse> GetStudentPaymentResultAsync(GetStudentPaymentResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetStudentPaymentResultResponse>("/cgi-bin/school/class_pay/get_student_payment_result", request, ct).ConfigureAwait(false);

    /// <summary>
    /// 获取订单详情。
    /// 文档：https://developer.work.weixin.qq.com/document/path/90602
    /// </summary>
    public async Task<GetOrderDetailResponse> GetOrderDetailAsync(GetOrderDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetOrderDetailResponse>("/cgi-bin/school/class_pay/get_order_detail", request, ct).ConfigureAwait(false);

    #endregion
}
