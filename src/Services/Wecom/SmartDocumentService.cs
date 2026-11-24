using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>管理智能文档的页面、内容块、数据源、导出和发布。</summary>
public sealed class SmartDocumentService
{
    private const string BasePath = "/cgi-bin/wedoc/smartdoc";
    private readonly WecomHttpClient _http;

    public SmartDocumentService(WecomHttpClient http)
    {
        ArgumentNullException.ThrowIfNull(http);
        _http = http;
    }

    /// <summary>获取页面层级列表。根页面的父页面 ID 为空。</summary>
    public Task<GetSmartDocumentPageHierarchyResponse> GetPageHierarchyAsync(DocIdRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetSmartDocumentPageHierarchyResponse>(BasePath + "/get_page_hierarchy", request, ct);

    /// <summary>添加页面并返回新页面的信息。</summary>
    public Task<SmartDocumentPageResponse> AddPageAsync(AddSmartDocumentPageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SmartDocumentPageResponse>(BasePath + "/add_page", request, ct);

    /// <summary>更新页面的标题、布局或位置。</summary>
    public Task<SmartDocumentPageResponse> UpdatePageAsync(UpdateSmartDocumentPageRequest request, CancellationToken ct = default)
        => _http.PostAsync<SmartDocumentPageResponse>(BasePath + "/update_page", request, ct);

    /// <summary>删除页面及其所有子页面。</summary>
    public Task DeletePageAsync(DeleteSmartDocumentPageRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>(BasePath + "/delete_page", request, ct);

    /// <summary>获取内容块列表及分页信息。</summary>
    public Task<GetSmartDocumentBlocksResponse> GetBlocksAsync(GetSmartDocumentBlocksRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetSmartDocumentBlocksResponse>(BasePath + "/get_block_list", request, ct);

    /// <summary>批量添加内容块并返回生成的内容块 ID。</summary>
    public Task<SmartDocumentBlocksResponse> AddBlocksAsync(AddSmartDocumentBlocksRequest request, CancellationToken ct = default)
        => _http.PostAsync<SmartDocumentBlocksResponse>(BasePath + "/add_blocks", request, ct);

    /// <summary>批量更新内容块。</summary>
    public Task<SmartDocumentBlocksResponse> UpdateBlocksAsync(UpdateSmartDocumentBlocksRequest request, CancellationToken ct = default)
        => _http.PostAsync<SmartDocumentBlocksResponse>(BasePath + "/update_blocks", request, ct);

    /// <summary>批量删除内容块。</summary>
    public Task DeleteBlocksAsync(DeleteSmartDocumentBlocksRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>(BasePath + "/delete_blocks", request, ct);

    /// <summary>提交 Markdown 异步导出任务。</summary>
    public Task<CreateSmartDocumentExportTaskResponse> CreateExportTaskAsync(CreateSmartDocumentExportTaskRequest request, CancellationToken ct = default)
        => _http.PostAsync<CreateSmartDocumentExportTaskResponse>(BasePath + "/export_task", request, ct);

    /// <summary>查询导出任务状态和导出的内容。</summary>
    public Task<GetSmartDocumentExportResultResponse> GetExportResultAsync(GetSmartDocumentExportResultRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetSmartDocumentExportResultResponse>(BasePath + "/get_export_result", request, ct);

    /// <summary>获取绑定的数据源 ID。文档没有数据源时，企业微信会创建一个。</summary>
    public Task<GetSmartDocumentDataSourceResponse> GetDataSourceAsync(DocIdRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetSmartDocumentDataSourceResponse>(BasePath + "/get_smartsheet_info", request, ct);

    /// <summary>在智能文档中添加数据表。</summary>
    public Task<SmartDocumentDataTableResponse> AddDataTableAsync(AddSmartDocumentDataTableRequest request, CancellationToken ct = default)
        => _http.PostAsync<SmartDocumentDataTableResponse>(BasePath + "/add_smartsheet", request, ct);

    /// <summary>更新关联数据表的标题或位置。</summary>
    public Task<SmartDocumentDataTableResponse> UpdateDataTableAsync(UpdateSmartDocumentDataTableRequest request, CancellationToken ct = default)
        => _http.PostAsync<SmartDocumentDataTableResponse>(BasePath + "/update_smartsheet", request, ct);

    /// <summary>删除智能文档中的数据表关联。</summary>
    public Task DeleteDataTableAsync(DeleteSmartDocumentDataTableRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>(BasePath + "/delete_smartsheet", request, ct);

    /// <summary>发布智能文档或更新已发布的版本。</summary>
    /// <remarks>官方建议客户端超时大于 10 秒。</remarks>
    public Task<SmartDocumentPublishResponse> PublishAsync(SmartDocumentPublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<SmartDocumentPublishResponse>(BasePath + "/publish", request, ct);

    /// <summary>修改已发布文档的可查看范围。</summary>
    public Task UpdatePublishSettingsAsync(SmartDocumentPublishRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>(BasePath + "/publish_setting", request, ct);

    /// <summary>取消发布智能文档。</summary>
    public Task CancelPublishAsync(DocIdRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>(BasePath + "/cancel_publish", request, ct);
}
