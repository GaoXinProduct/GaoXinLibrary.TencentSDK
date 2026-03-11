using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能表格服务实现</summary>
public class SmartSheetService : ISmartSheetService
{
    private readonly WecomHttpClient _http;

    public SmartSheetService(WecomHttpClient http) => _http = http;

    // ─── 子表管理 ────────────────────────────────────────────

    public async Task<SheetInfo[]> AddSheetAsync(string docId, SheetInfo[] properties, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddSheetResponse>("/cgi-bin/wedoc/smartsheet/add_sheet",
            new { docid = docId, properties }, ct);
        return resp.Properties ?? [];
    }

    public async Task DeleteSheetAsync(string docId, string[] sheetIds, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_sheet",
            new { docid = docId, sheet_ids = sheetIds }, ct);

    public async Task UpdateSheetAsync(string docId, string sheetId, string title, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_sheet",
            new { docid = docId, properties = new[] { new { sheet_id = sheetId, title } } }, ct);

    public async Task<SheetInfo[]> GetSheetsAsync(string docId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetSheetsResponse>("/cgi-bin/wedoc/smartsheet/get_sheet",
            new { docid = docId }, ct);
        return resp.Properties ?? [];
    }

    // ─── 字段管理 ────────────────────────────────────────────

    public async Task<SheetField[]> AddFieldsAsync(string docId, string sheetId, SheetField[] fields, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddFieldsResponse>("/cgi-bin/wedoc/smartsheet/add_fields",
            new { docid = docId, sheet_id = sheetId, fields }, ct);
        return resp.Fields ?? [];
    }

    public async Task DeleteFieldsAsync(string docId, string sheetId, string[] fieldIds, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_fields",
            new { docid = docId, sheet_id = sheetId, field_ids = fieldIds }, ct);

    public async Task UpdateFieldsAsync(string docId, string sheetId, SheetField[] fields, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_fields",
            new { docid = docId, sheet_id = sheetId, fields }, ct);

    public async Task<SheetField[]> GetFieldsAsync(string docId, string sheetId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetFieldsResponse>("/cgi-bin/wedoc/smartsheet/get_fields",
            new { docid = docId, sheet_id = sheetId }, ct);
        return resp.Fields ?? [];
    }

    // ─── 记录管理 ────────────────────────────────────────────

    public async Task<SheetRecord[]> AddRecordsAsync(string docId, string sheetId, SheetRecord[] records, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddRecordsResponse>("/cgi-bin/wedoc/smartsheet/add_records",
            new { docid = docId, sheet_id = sheetId, records }, ct);
        return resp.Records ?? [];
    }

    public async Task DeleteRecordsAsync(string docId, string sheetId, string[] recordIds, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_records",
            new { docid = docId, sheet_id = sheetId, record_ids = recordIds }, ct);

    public async Task UpdateRecordsAsync(string docId, string sheetId, SheetRecord[] records, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_records",
            new { docid = docId, sheet_id = sheetId, records }, ct);

    public async Task<GetRecordsResponse> GetRecordsAsync(string docId, string sheetId, int? offset = null, int? limit = null, string[]? fieldIds = null, string? viewId = null, CancellationToken ct = default)
        => await _http.PostAsync<GetRecordsResponse>("/cgi-bin/wedoc/smartsheet/get_records",
            new { docid = docId, sheet_id = sheetId, offset, limit, field_ids = fieldIds, view_id = viewId }, ct);

    // ─── 视图管理 ────────────────────────────────────────────

    public async Task<SheetView[]> GetViewsAsync(string docId, string sheetId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetViewsResponse>("/cgi-bin/wedoc/smartsheet/get_views",
            new { docid = docId, sheet_id = sheetId }, ct);
        return resp.Views ?? [];
    }
}
