using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能表格服务实现</summary>
public class SmartSheetService
{
    private readonly WecomHttpClient _http;

    public SmartSheetService(WecomHttpClient http) => _http = http;

    #region 子表管理

    /// <summary>添加子表</summary>
    public async Task<SheetInfo[]> AddSheetAsync(AddSheetRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddSheetResponse>("/cgi-bin/wedoc/smartsheet/add_sheet", request, ct);
        return resp.Properties ?? [];
    }

    /// <summary>删除子表</summary>
    public async Task DeleteSheetAsync(DeleteSheetRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_sheet", request, ct);

    /// <summary>修改子表标题</summary>
    public async Task UpdateSheetAsync(UpdateSheetRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_sheet", request, ct);

    /// <summary>获取子表列表</summary>
    public async Task<SheetInfo[]> GetSheetsAsync(GetSheetsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetSheetsResponse>("/cgi-bin/wedoc/smartsheet/get_sheet", request, ct);
        return resp.Properties ?? [];
    }

    #endregion
    #region 字段管理

    /// <summary>添加字段</summary>
    public async Task<SheetField[]> AddFieldsAsync(AddFieldsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddFieldsResponse>("/cgi-bin/wedoc/smartsheet/add_fields", request, ct);
        return resp.Fields ?? [];
    }

    /// <summary>删除字段</summary>
    public async Task DeleteFieldsAsync(DeleteFieldsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_fields", request, ct);

    /// <summary>更新字段</summary>
    public async Task UpdateFieldsAsync(UpdateFieldsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_fields", request, ct);

    /// <summary>获取字段列表</summary>
    public async Task<SheetField[]> GetFieldsAsync(GetFieldsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetFieldsResponse>("/cgi-bin/wedoc/smartsheet/get_fields", request, ct);
        return resp.Fields ?? [];
    }

    #endregion
    #region 记录管理

    /// <summary>添加记录</summary>
    public async Task<SheetRecord[]> AddRecordsAsync(AddRecordsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddRecordsResponse>("/cgi-bin/wedoc/smartsheet/add_records", request, ct);
        return resp.Records ?? [];
    }

    /// <summary>删除记录</summary>
    public async Task DeleteRecordsAsync(DeleteRecordsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_records", request, ct);

    /// <summary>更新记录</summary>
    public async Task UpdateRecordsAsync(UpdateRecordsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_records", request, ct);

    /// <summary>获取记录列表</summary>
    public async Task<GetRecordsResponse> GetRecordsAsync(GetRecordsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRecordsResponse>("/cgi-bin/wedoc/smartsheet/get_records", request, ct);

    #endregion
    #region 视图管理

    /// <summary>获取视图列表</summary>
    public async Task<SheetView[]> GetViewsAsync(GetViewsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetViewsResponse>("/cgi-bin/wedoc/smartsheet/get_views", request, ct);
        return resp.Views ?? [];
    }
    #endregion
}
