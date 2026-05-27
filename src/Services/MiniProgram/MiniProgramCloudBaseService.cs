using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 小程序云开发服务实现
/// <para>
/// 提供云函数、数据库、存储等云端能力接口。
/// </para>
/// </summary>
public sealed class MiniProgramCloudBaseService
{
    private readonly WechatHttpClient _http;

    /// <summary>
    /// 初始化云开发服务
    /// </summary>
    /// <param name="http">微信HTTP客户端</param>
    public MiniProgramCloudBaseService(WechatHttpClient http) => _http = http;

    // ==================== 云函数 ====================

    /// <summary>
    /// 触发云函数（POST /tcb/invoke_cloud_function）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<InvokeCloudFunctionResponse> InvokeCloudFunctionAsync(InvokeCloudFunctionRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvokeCloudFunctionResponse>("/tcb/invoke_cloud_function", request, ct);

    /// <summary>
    /// 延时调用云函数（POST /tcb/add_delayed_function_task）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<AddDelayedFunctionTaskResponse> AddDelayedFunctionTaskAsync(AddDelayedFunctionTaskRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddDelayedFunctionTaskResponse>("/tcb/add_delayed_function_task", request, ct);

    // ==================== 数据库 - 集合操作 ====================

    /// <summary>
    /// 新增集合（POST /tcb/database_collection_add）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<AddDatabaseCollectionResponse> AddDatabaseCollectionAsync(AddDatabaseCollectionRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddDatabaseCollectionResponse>("/tcb/database_collection_add", request, ct);

    /// <summary>
    /// 删除集合（POST /tcb/database_collection_delete）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<DeleteDatabaseCollectionResponse> DeleteDatabaseCollectionAsync(DeleteDatabaseCollectionRequest request, CancellationToken ct = default)
        => _http.PostAsync<DeleteDatabaseCollectionResponse>("/tcb/database_collection_delete", request, ct);

    /// <summary>
    /// 获取集合信息（POST /tcb/database_collection_get）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetDatabaseCollectionResponse> GetDatabaseCollectionAsync(GetDatabaseCollectionRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetDatabaseCollectionResponse>("/tcb/database_collection_get", request, ct);

    // ==================== 数据库 - 记录操作 ====================

    /// <summary>
    /// 数据库插入记录（POST /tcb/database_insert）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<AddDatabaseItemResponse> AddDatabaseItemAsync(AddDatabaseItemRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddDatabaseItemResponse>("/tcb/database_insert", request, ct);

    /// <summary>
    /// 数据库查询记录（POST /tcb/database_query）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetDatabaseRecordResponse> GetDatabaseRecordAsync(GetDatabaseRecordRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetDatabaseRecordResponse>("/tcb/database_query", request, ct);

    /// <summary>
    /// 数据库更新记录（POST /tcb/database_update）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<UpdateDatabaseRecordResponse> UpdateDatabaseRecordAsync(UpdateDatabaseRecordRequest request, CancellationToken ct = default)
        => _http.PostAsync<UpdateDatabaseRecordResponse>("/tcb/database_update", request, ct);

    /// <summary>
    /// 数据库删除记录（POST /tcb/database_delete）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<DeleteDatabaseItemResponse> DeleteDatabaseItemAsync(DeleteDatabaseItemRequest request, CancellationToken ct = default)
        => _http.PostAsync<DeleteDatabaseItemResponse>("/tcb/database_delete", request, ct);

    /// <summary>
    /// 统计集合记录数（POST /tcb/database_count）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetDatabaseCountResponse> GetDatabaseCountAsync(GetDatabaseCountRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetDatabaseCountResponse>("/tcb/database_count", request, ct);

    /// <summary>
    /// 数据库聚合（POST /tcb/database_aggregate）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<AggregateDatabaseResponse> AggregateDatabaseAsync(AggregateDatabaseRequest request, CancellationToken ct = default)
        => _http.PostAsync<AggregateDatabaseResponse>("/tcb/database_aggregate", request, ct);

    // ==================== 数据库 - 导入导出 ====================

    /// <summary>
    /// 数据库导出（POST /tcb/database_migrate_export）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<ExportDatabaseItemResponse> ExportDatabaseItemAsync(ExportDatabaseItemRequest request, CancellationToken ct = default)
        => _http.PostAsync<ExportDatabaseItemResponse>("/tcb/database_migrate_export", request, ct);

    /// <summary>
    /// 数据库导入（POST /tcb/database_migrate_import）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<ImportDatabaseItemResponse> ImportDatabaseItemAsync(ImportDatabaseItemRequest request, CancellationToken ct = default)
        => _http.PostAsync<ImportDatabaseItemResponse>("/tcb/database_migrate_import", request, ct);

    /// <summary>
    /// 数据库迁移状态查询（POST /tcb/database_migrate_query）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetDatabaseMigrateStatusResponse> GetDatabaseMigrateStatusAsync(GetDatabaseMigrateStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetDatabaseMigrateStatusResponse>("/tcb/database_migrate_query", request, ct);

    /// <summary>
    /// 更新数据库索引（POST /tcb/database_index_update）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<UpdateDatabaseIndexResponse> UpdateDatabaseIndexAsync(UpdateDatabaseIndexRequest request, CancellationToken ct = default)
        => _http.PostAsync<UpdateDatabaseIndexResponse>("/tcb/database_index_update", request, ct);

    // ==================== 存储 ====================

    /// <summary>
    /// 获取文件上传链接（POST /tcb/upload_file）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetUploadTcbFileLinkResponse> GetUploadTcbFileLinkAsync(GetUploadTcbFileLinkRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetUploadTcbFileLinkResponse>("/tcb/upload_file", request, ct);

    /// <summary>
    /// 获取文件下载链接（POST /tcb/download_file）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetDownloadTcbFileLinkResponse> GetDownloadTcbFileLinkAsync(GetDownloadTcbFileLinkRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetDownloadTcbFileLinkResponse>("/tcb/download_file", request, ct);

    /// <summary>
    /// 删除文件（POST /tcb/delete_file）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<DeleteTcbCloudFileResponse> DeleteTcbCloudFileAsync(DeleteTcbCloudFileRequest request, CancellationToken ct = default)
        => _http.PostAsync<DeleteTcbCloudFileResponse>("/tcb/delete_file", request, ct);
}