using GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能表格服务接口</summary>
public interface ISmartSheetService
{
    // ─── 子表管理 ────────────────────────────────────────────

    /// <summary>添加子表</summary>
    Task<SheetInfo[]> AddSheetAsync(string docId, SheetInfo[] properties, CancellationToken ct = default);

    /// <summary>删除子表</summary>
    Task DeleteSheetAsync(string docId, string[] sheetIds, CancellationToken ct = default);

    /// <summary>修改子表标题</summary>
    Task UpdateSheetAsync(string docId, string sheetId, string title, CancellationToken ct = default);

    /// <summary>获取子表列表</summary>
    Task<SheetInfo[]> GetSheetsAsync(string docId, CancellationToken ct = default);

    // ─── 字段管理 ────────────────────────────────────────────

    /// <summary>添加字段</summary>
    Task<SheetField[]> AddFieldsAsync(string docId, string sheetId, SheetField[] fields, CancellationToken ct = default);

    /// <summary>删除字段</summary>
    Task DeleteFieldsAsync(string docId, string sheetId, string[] fieldIds, CancellationToken ct = default);

    /// <summary>更新字段</summary>
    Task UpdateFieldsAsync(string docId, string sheetId, SheetField[] fields, CancellationToken ct = default);

    /// <summary>获取字段列表</summary>
    Task<SheetField[]> GetFieldsAsync(string docId, string sheetId, CancellationToken ct = default);

    // ─── 记录管理 ────────────────────────────────────────────

    /// <summary>添加记录</summary>
    Task<SheetRecord[]> AddRecordsAsync(string docId, string sheetId, SheetRecord[] records, CancellationToken ct = default);

    /// <summary>删除记录</summary>
    Task DeleteRecordsAsync(string docId, string sheetId, string[] recordIds, CancellationToken ct = default);

    /// <summary>更新记录</summary>
    Task UpdateRecordsAsync(string docId, string sheetId, SheetRecord[] records, CancellationToken ct = default);

    /// <summary>获取记录列表</summary>
    Task<GetRecordsResponse> GetRecordsAsync(string docId, string sheetId, int? offset = null, int? limit = null, string[]? fieldIds = null, string? viewId = null, CancellationToken ct = default);

    // ─── 视图管理 ────────────────────────────────────────────

    /// <summary>获取视图列表</summary>
    Task<SheetView[]> GetViewsAsync(string docId, string sheetId, CancellationToken ct = default);
}
