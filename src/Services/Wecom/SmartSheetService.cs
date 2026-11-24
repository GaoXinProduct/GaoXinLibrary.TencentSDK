using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>智能表格服务实现</summary>
public sealed class SmartSheetService
{
    private readonly WecomHttpClient _http;

    public SmartSheetService(WecomHttpClient http) => _http = http;

    #region 子表管理

    /// <summary>添加子表</summary>
    public async Task<SheetInfo[]> AddSheetAsync(AddSheetRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddSheetResponse>("/cgi-bin/wedoc/smartsheet/add_sheet", request, ct).ConfigureAwait(false);
        return resp.Properties ?? [];
    }

    /// <summary>删除子表</summary>
    public async Task DeleteSheetAsync(DeleteSheetRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_sheet", request, ct).ConfigureAwait(false);

    /// <summary>修改子表标题</summary>
    public async Task UpdateSheetAsync(UpdateSheetRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_sheet", request, ct).ConfigureAwait(false);

    /// <summary>获取子表列表</summary>
    public async Task<SheetInfo[]> GetSheetsAsync(GetSheetsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostQueryAsync<GetSheetsResponse>("/cgi-bin/wedoc/smartsheet/get_sheet", request, ct).ConfigureAwait(false);
        return resp.Properties ?? [];
    }

    #endregion
    #region 字段管理

    /// <summary>添加字段</summary>
    public async Task<SheetField[]> AddFieldsAsync(AddFieldsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddFieldsResponse>("/cgi-bin/wedoc/smartsheet/add_fields", request, ct).ConfigureAwait(false);
        return resp.Fields ?? [];
    }

    /// <summary>删除字段</summary>
    public async Task DeleteFieldsAsync(DeleteFieldsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_fields", request, ct).ConfigureAwait(false);

    /// <summary>更新字段</summary>
    public async Task UpdateFieldsAsync(UpdateFieldsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_fields", request, ct).ConfigureAwait(false);

    /// <summary>获取字段列表</summary>
    public async Task<SheetField[]> GetFieldsAsync(GetFieldsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostQueryAsync<GetFieldsResponse>("/cgi-bin/wedoc/smartsheet/get_fields", request, ct).ConfigureAwait(false);
        return resp.Fields ?? [];
    }

    #endregion
    #region 记录管理

    /// <summary>添加记录</summary>
    public async Task<SheetRecord[]> AddRecordsAsync(AddRecordsRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<AddRecordsResponse>("/cgi-bin/wedoc/smartsheet/add_records", request, ct).ConfigureAwait(false);
        return resp.Records ?? [];
    }

    /// <summary>删除记录</summary>
    public async Task DeleteRecordsAsync(DeleteRecordsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/delete_records", request, ct).ConfigureAwait(false);

    /// <summary>更新记录</summary>
    public async Task UpdateRecordsAsync(UpdateRecordsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/update_records", request, ct).ConfigureAwait(false);

    /// <summary>获取记录列表</summary>
    public async Task<GetRecordsResponse> GetRecordsAsync(GetRecordsRequest request, CancellationToken ct = default)
        => await _http.PostQueryAsync<GetRecordsResponse>("/cgi-bin/wedoc/smartsheet/get_records", request, ct).ConfigureAwait(false);

    #endregion
    #region 视图管理

    /// <summary>获取本次查询返回的视图列表。</summary>
    public async Task<SheetView[]> GetViewsAsync(GetViewsRequest request, CancellationToken ct = default)
    {
        var resp = await GetViewsPageAsync(request, ct).ConfigureAwait(false);
        return resp.Views ?? [];
    }

    /// <summary>查询视图及分页状态。参考 <see href="https://developer.work.weixin.qq.com/document/path/101155"/>。</summary>
    public Task<GetViewsResponse> GetViewsPageAsync(GetViewsRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetViewsResponse>("/cgi-bin/wedoc/smartsheet/get_views", request, ct);
    #endregion
    #region 自动化群聊

    /// <summary>获取智能表格自动化创建的群聊列表。</summary>
    public Task<GetSmartSheetChatListResponse> GetSmartSheetChatListAsync(GetSmartSheetChatListRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.DocId, nameof(request.DocId));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(request.Limit, nameof(request.Limit));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(request.Limit, 200, nameof(request.Limit));
        if (!string.IsNullOrEmpty(request.SheetId) || request.Offset != 0)
            throw new ArgumentException("智能表格群聊按文档查询并使用 Cursor 分页，请清除 SheetId 和 Offset。", nameof(request));

        return _http.PostQueryAsync<GetSmartSheetChatListResponse>("/cgi-bin/wedoc/smartsheet/groupchat/list",
            new { docid = request.DocId, cursor = request.Cursor, limit = request.Limit }, ct);
    }

    /// <summary>获取智能表格自动化创建的群聊详情。</summary>
    public async Task<GetSmartSheetChatResponse> GetSmartSheetChatAsync(GetSmartSheetChatRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var chatId = request.ChatId;
        ArgumentException.ThrowIfNullOrWhiteSpace(request.DocId, nameof(request.DocId));
        ArgumentException.ThrowIfNullOrWhiteSpace(chatId, nameof(request.ChatId));

        var response = await _http.PostQueryAsync<GetSmartSheetChatResponse>("/cgi-bin/wedoc/smartsheet/groupchat/get", request, ct).ConfigureAwait(false);
        response.ChatInfo ??= new GroupChatInfo
        {
            ChatId = chatId,
            Name = response.Name,
            Owner = response.Owner,
            UserList = response.UserList
        };
        return response;
    }

    /// <summary>修改智能表格自动化群聊的群主与成员。同一群聊的修改需串行调用。</summary>
    public async Task UpdateSmartSheetChatAsync(UpdateSmartSheetChatRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.DocId, nameof(request.DocId));
        ArgumentException.ThrowIfNullOrWhiteSpace(request.ChatId, nameof(request.ChatId));
        if (request.Name is not null)
            throw new ArgumentException("智能表格群聊接口仅支持修改群主与成员，请清除 Name。", nameof(request));

        await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/groupchat/update", new
        {
            docid = request.DocId,
            chat_id = request.ChatId,
            owner = request.Owner,
            add_user_list = request.AddUserList,
            del_user_list = request.DelUserList
        }, ct).ConfigureAwait(false);
    }
    #endregion
    #region 内容权限

    /// <summary>查询智能表格的子表内容权限。参考 <see href="https://developer.work.weixin.qq.com/document/path/99935"/>。</summary>
    public Task<GetContentPermissionsResponse> GetContentPermissionsAsync(GetContentPermissionsRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetContentPermissionsResponse>("/cgi-bin/wedoc/smartsheet/content_priv/get_sheet_priv", request, ct);

    /// <summary>更新智能表格的子表内容权限。</summary>
    public async Task UpdateContentPermissionsAsync(UpdateContentPermissionsRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/content_priv/update_sheet_priv", request, ct).ConfigureAwait(false);

    /// <summary>创建一条成员额外权限规则。</summary>
    public Task<CreateContentPermissionRuleResponse> CreateContentPermissionRuleAsync(CreateContentPermissionRuleRequest request, CancellationToken ct = default)
        => _http.PostAsync<CreateContentPermissionRuleResponse>("/cgi-bin/wedoc/smartsheet/content_priv/create_rule", request, ct);

    /// <summary>修改成员额外权限规则的适用成员。</summary>
    public async Task UpdateContentPermissionMembersAsync(UpdateContentPermissionMembersRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/content_priv/mod_rule_member", request, ct).ConfigureAwait(false);

    /// <summary>删除成员额外权限规则。</summary>
    public async Task DeleteContentPermissionRulesAsync(DeleteContentPermissionRulesRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/smartsheet/content_priv/delete_rule", request, ct).ConfigureAwait(false);
    #endregion
}
