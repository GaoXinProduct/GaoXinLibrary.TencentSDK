using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>上下游/互联企业服务实现</summary>
public class LinkedCorpService : ILinkedCorpService
{
    private readonly WecomHttpClient _http;

    public LinkedCorpService(WecomHttpClient http) => _http = http;

    /// <inheritdoc/>
    public async Task<GetPermListResponse> GetPermListAsync(CancellationToken ct = default)
    {
        return await _http.PostAsync<GetPermListResponse>(
            "/cgi-bin/linkedcorp/agent/get_perm_list",
            new { }, ct);
    }

    /// <inheritdoc/>
    public async Task<LinkedCorpUser?> GetUserAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpUserGetResponse>(
            "/cgi-bin/linkedcorp/user/get",
            new LinkedCorpUserGetRequest { UserId = userId }, ct);
        return resp.UserInfo;
    }

    /// <inheritdoc/>
    public async Task<LinkedCorpSimpleUser[]> GetUserSimpleListAsync(string departmentId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpSimpleListResponse>(
            "/cgi-bin/linkedcorp/user/simplelist",
            new LinkedCorpUserListRequest { DepartmentId = departmentId }, ct);
        return resp.UserList ?? [];
    }

    /// <inheritdoc/>
    public async Task<LinkedCorpUser[]> GetUserListAsync(string departmentId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpUserListResponse>(
            "/cgi-bin/linkedcorp/user/list",
            new LinkedCorpUserListRequest { DepartmentId = departmentId }, ct);
        return resp.UserList ?? [];
    }

    /// <inheritdoc/>
    public async Task<LinkedCorpDepartment[]> GetDepartmentListAsync(string departmentId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpDepartmentListResponse>(
            "/cgi-bin/linkedcorp/department/list",
            new LinkedCorpDepartmentListRequest { DepartmentId = departmentId }, ct);
        return resp.DepartmentList ?? [];
    }
}
