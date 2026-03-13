using GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能表格服务接口</summary>
public interface ISmartSheetService
{
    // ─── 子表管理 ────────────────────────────────────────────

    /// <summary>添加子表</summary>
    Task<SheetInfo[]> AddSheetAsync(AddSheetRequest request, CancellationToken ct = default);

    /// <summary>删除子表</summary>
    Task DeleteSheetAsync(DeleteSheetRequest request, CancellationToken ct = default);

    /// <summary>修改子表标题</summary>
    Task UpdateSheetAsync(UpdateSheetRequest request, CancellationToken ct = default);

    /// <summary>获取子表列表</summary>
    Task<SheetInfo[]> GetSheetsAsync(GetSheetsRequest request, CancellationToken ct = default);

    // ─── 字段管理 ────────────────────────────────────────────

    /// <summary>添加字段</summary>
    Task<SheetField[]> AddFieldsAsync(AddFieldsRequest request, CancellationToken ct = default);

    /// <summary>删除字段</summary>
    Task DeleteFieldsAsync(DeleteFieldsRequest request, CancellationToken ct = default);

    /// <summary>更新字段</summary>
    Task UpdateFieldsAsync(UpdateFieldsRequest request, CancellationToken ct = default);

    /// <summary>获取字段列表</summary>
    Task<SheetField[]> GetFieldsAsync(GetFieldsRequest request, CancellationToken ct = default);

    // ─── 记录管理 ────────────────────────────────────────────

    /// <summary>添加记录</summary>
    Task<SheetRecord[]> AddRecordsAsync(AddRecordsRequest request, CancellationToken ct = default);

    /// <summary>删除记录</summary>
    Task DeleteRecordsAsync(DeleteRecordsRequest request, CancellationToken ct = default);

    /// <summary>更新记录</summary>
    Task UpdateRecordsAsync(UpdateRecordsRequest request, CancellationToken ct = default);

    /// <summary>获取记录列表</summary>
    Task<GetRecordsResponse> GetRecordsAsync(GetRecordsRequest request, CancellationToken ct = default);

    // ─── 视图管理 ────────────────────────────────────────────

    /// <summary>获取视图列表</summary>
    Task<SheetView[]> GetViewsAsync(GetViewsRequest request, CancellationToken ct = default);
}
