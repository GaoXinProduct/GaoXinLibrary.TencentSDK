using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document.Spreadsheet;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;
using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 文档服务实现
/// </summary>
public class DocumentService
{
    private readonly WecomHttpClient _http;

    public DocumentService(WecomHttpClient http) => _http = http;

    #region 文档管理

    /// <summary>
    /// 新建文档
    /// </summary>
    public async Task<CreateDocResponse> CreateDocAsync(CreateDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateDocResponse>("/cgi-bin/wedoc/create_doc", request, ct);

    /// <summary>
    /// 获取文档基础信息
    /// </summary>
    public async Task<GetDocBaseInfoResponse> GetDocBaseInfoAsync(DocIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDocBaseInfoResponse>("/cgi-bin/wedoc/get_doc_base_info", request, ct);

    /// <summary>
    /// 重命名文档
    /// </summary>
    public async Task<RenameDocResponse> RenameDocAsync(RenameDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<RenameDocResponse>("/cgi-bin/wedoc/rename_doc", request, ct);

    /// <summary>
    /// 删除文档
    /// </summary>
    public async Task<DeleteDocResponse> DeleteDocAsync(DeleteDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteDocResponse>("/cgi-bin/wedoc/del_doc", request, ct);

    /// <summary>
    /// 分享文档
    /// </summary>
    public async Task<ShareDocResponse> ShareDocAsync(ShareDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ShareDocResponse>("/cgi-bin/wedoc/doc_share", request, ct);

    /// <summary>
    /// 获取文档基础信息（新版）
    /// </summary>
    public async Task<GetDocBasicInfoResponse> GetDocBasicInfoAsync(GetDocBasicInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDocBasicInfoResponse>("/cgi-bin/wedoc/get_doc_basic_info", request, ct);

    #endregion
    #region 文档内容

    /// <summary>
    /// 编辑文档内容
    /// </summary>
    public async Task<EditDocContentResponse> EditDocContentAsync(EditDocContentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<EditDocContentResponse>("/cgi-bin/wedoc/edit_doc", request, ct);

    /// <summary>
    /// 获取文档数据
    /// </summary>
    public async Task<GetDocDataResponse> GetDocDataAsync(GetDocDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDocDataResponse>("/cgi-bin/wedoc/get_doc_data", request, ct);

    #endregion
    #region 表格

    /// <summary>
    /// 编辑表格内容
    /// </summary>
    public async Task<EditSpreadsheetContentResponse> EditSpreadsheetContentAsync(EditSpreadsheetContentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<EditSpreadsheetContentResponse>("/cgi-bin/wedoc/spreadsheet/edit_cells", request, ct);

    /// <summary>
    /// 获取表格行列信息
    /// </summary>
    public async Task<GetSpreadsheetRowColInfoResponse> GetSpreadsheetRowColInfoAsync(GetSpreadsheetRowColInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetSpreadsheetRowColInfoResponse>("/cgi-bin/wedoc/spreadsheet/get_row_col_info", request, ct);

    /// <summary>
    /// 获取表格数据
    /// </summary>
    public async Task<GetSpreadsheetDataResponse> GetSpreadsheetDataAsync(GetSpreadsheetDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetSpreadsheetDataResponse>("/cgi-bin/wedoc/spreadsheet/get_data", request, ct);

    #endregion
    #region 智能表格 - 子表

    /// <summary>
    /// 添加子表
    /// </summary>
    public async Task<AddSubTableResponse> AddSubTableAsync(AddSubTableRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddSubTableResponse>("/cgi-bin/wedoc/smartsheet/add_sheet", request, ct);

    /// <summary>
    /// 删除子表
    /// </summary>
    public async Task<DeleteSubTableResponse> DeleteSubTableAsync(DeleteSubTableRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteSubTableResponse>("/cgi-bin/wedoc/smartsheet/delete_sheet", request, ct);

    /// <summary>
    /// 更新子表
    /// </summary>
    public async Task<UpdateSubTableResponse> UpdateSubTableAsync(UpdateSubTableRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UpdateSubTableResponse>("/cgi-bin/wedoc/smartsheet/update_sheet", request, ct);

    /// <summary>
    /// 查询子表
    /// </summary>
    public async Task<GetSubTableResponse> GetSubTableAsync(GetSubTableRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetSubTableResponse>("/cgi-bin/wedoc/smartsheet/get_sheet", request, ct);

    #endregion
    #region 智能表格 - 视图

    /// <summary>
    /// 添加视图
    /// </summary>
    public async Task<AddViewResponse> AddViewAsync(AddViewRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddViewResponse>("/cgi-bin/wedoc/smartsheet/add_view", request, ct);

    /// <summary>
    /// 删除视图
    /// </summary>
    public async Task<DeleteViewResponse> DeleteViewAsync(DeleteViewRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteViewResponse>("/cgi-bin/wedoc/smartsheet/delete_view", request, ct);

    /// <summary>
    /// 更新视图
    /// </summary>
    public async Task<UpdateViewResponse> UpdateViewAsync(UpdateViewRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UpdateViewResponse>("/cgi-bin/wedoc/smartsheet/update_view", request, ct);

    /// <summary>
    /// 查询视图
    /// </summary>
    public async Task<GetViewResponse> GetViewAsync(GetViewRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetViewResponse>("/cgi-bin/wedoc/smartsheet/get_view", request, ct);

    #endregion
    #region 智能表格 - 字段

    /// <summary>
    /// 添加字段
    /// </summary>
    public async Task<AddFieldResponse> AddFieldAsync(AddFieldRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddFieldResponse>("/cgi-bin/wedoc/smartsheet/add_fields", request, ct);

    /// <summary>
    /// 删除字段
    /// </summary>
    public async Task<DeleteFieldResponse> DeleteFieldAsync(DeleteFieldRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteFieldResponse>("/cgi-bin/wedoc/smartsheet/delete_fields", request, ct);

    /// <summary>
    /// 更新字段
    /// </summary>
    public async Task<UpdateFieldResponse> UpdateFieldAsync(UpdateFieldRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UpdateFieldResponse>("/cgi-bin/wedoc/smartsheet/update_fields", request, ct);

    /// <summary>
    /// 查询字段
    /// </summary>
    public async Task<GetFieldResponse> GetFieldAsync(GetFieldRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFieldResponse>("/cgi-bin/wedoc/smartsheet/get_fields", request, ct);

    #endregion
    #region 智能表格 - 记录

    /// <summary>
    /// 添加记录
    /// </summary>
    public async Task<AddRecordResponse> AddRecordAsync(AddRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddRecordResponse>("/cgi-bin/wedoc/smartsheet/add_records", request, ct);

    /// <summary>
    /// 删除记录
    /// </summary>
    public async Task<DeleteRecordResponse> DeleteRecordAsync(DeleteRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteRecordResponse>("/cgi-bin/wedoc/smartsheet/delete_records", request, ct);

    /// <summary>
    /// 更新记录
    /// </summary>
    public async Task<UpdateRecordResponse> UpdateRecordAsync(UpdateRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UpdateRecordResponse>("/cgi-bin/wedoc/smartsheet/update_records", request, ct);

    /// <summary>
    /// 查询记录
    /// </summary>
    public async Task<GetRecordResponse> GetRecordAsync(GetRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRecordResponse>("/cgi-bin/wedoc/smartsheet/get_records", request, ct);

    #endregion
    #region 智能表格 - 编组

    /// <summary>
    /// 添加编组
    /// </summary>
    public async Task<AddGroupResponse> AddGroupAsync(AddGroupRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddGroupResponse>("/cgi-bin/wedoc/smartsheet/add_group", request, ct);

    /// <summary>
    /// 删除编组
    /// </summary>
    public async Task<DeleteGroupResponse> DeleteGroupAsync(DeleteGroupRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DeleteGroupResponse>("/cgi-bin/wedoc/smartsheet/delete_group", request, ct);

    /// <summary>
    /// 更新编组
    /// </summary>
    public async Task<UpdateGroupResponse> UpdateGroupAsync(UpdateGroupRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UpdateGroupResponse>("/cgi-bin/wedoc/smartsheet/update_group", request, ct);

    /// <summary>
    /// 查询编组
    /// </summary>
    public async Task<GetGroupResponse> GetGroupAsync(GetGroupRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupResponse>("/cgi-bin/wedoc/smartsheet/get_group", request, ct);

    #endregion
    #region 智能表格 - 权限

    /// <summary>
    /// 管理智能表格内容权限
    /// </summary>
    public async Task<ModifyPermissionRuleResponse> ModifyPermissionRuleAsync(ModifyPermissionRuleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ModifyPermissionRuleResponse>("/cgi-bin/wedoc/smartsheet/modify_permission_rule", request, ct);

    #endregion
    #region 收集表

    /// <summary>
    /// 创建收集表
    /// </summary>
    public async Task<CreateCollectFormResponse> CreateCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateCollectFormResponse>("/cgi-bin/wedoc/create_collect", request, ct);

    /// <summary>
    /// 编辑收集表
    /// </summary>
    public async Task<EditCollectFormResponse> EditCollectFormAsync(EditCollectFormRequest request, CancellationToken ct = default)
        => await _http.PostAsync<EditCollectFormResponse>("/cgi-bin/wedoc/modify_collect", request, ct);

    /// <summary>
    /// 获取收集表信息
    /// </summary>
    public async Task<CollectFormInfo?> GetCollectFormInfoAsync(GetCollectFormRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCollectFormResponse>("/cgi-bin/wedoc/get_collect", request, ct);
        return resp.FormInfo;
    }

    /// <summary>
    /// 获取收集表统计信息
    /// </summary>
    public async Task<GetCollectFormStatResponse> GetCollectFormStatAsync(GetCollectFormStatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetCollectFormStatResponse>("/cgi-bin/wedoc/get_collect_stat", request, ct);

    /// <summary>
    /// 读取收集表答案
    /// </summary>
    public async Task<ReadCollectFormAnswersResponse> ReadCollectFormAnswersAsync(ReadCollectFormAnswersRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ReadCollectFormAnswersResponse>("/cgi-bin/wedoc/get_form_answer", request, ct);

    #endregion
    #region 文档权限

    /// <summary>
    /// 获取文档权限
    /// </summary>
    public async Task<DocPermissionInfo?> GetDocPermissionAsync(DocIdRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetDocPermissionResponse>("/cgi-bin/wedoc/get_doc_permission", request, ct);
        return resp.PermissionInfo;
    }

    /// <summary>
    /// 修改文档成员权限
    /// </summary>
    public async Task<WecomBaseResponse> ModifyDocMemberPermissionAsync(ModifyDocMemberPermissionRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/modify_doc_member_permission", request, ct);

    /// <summary>
    /// 修改文档安全设置
    /// </summary>
    public async Task<WecomBaseResponse> ModifyDocSecurityAsync(ModifyDocSecurityRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/modify_doc_security", request, ct);

    #endregion
}
