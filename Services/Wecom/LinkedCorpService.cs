using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>上下游/互联企业服务实现</summary>
public class LinkedCorpService
{
    private readonly WecomHttpClient _http;

    public LinkedCorpService(WecomHttpClient http) => _http = http;

    /// <summary>
    /// 获取应用的可见范围
    /// <para>本接口只返回互联企业中非本企业内的成员和部门的信息。</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>可见的 userids 和 department_ids</returns>
    public async Task<GetPermListResponse> GetPermListAsync(CancellationToken ct = default)
    {
        return await _http.PostAsync<GetPermListResponse>(
            "/cgi-bin/linkedcorp/agent/get_perm_list",
            EmptyRequest.Instance, ct);
    }

    /// <summary>
    /// 获取互联企业成员详细信息
    /// </summary>
    /// <param name="userId">CorpId/UserId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>成员详细信息</returns>
    public async Task<LinkedCorpUser?> GetUserAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpUserGetResponse>(
            "/cgi-bin/linkedcorp/user/get",
            new LinkedCorpUserGetRequest { UserId = userId }, ct);
        return resp.UserInfo;
    }

    /// <summary>
    /// 获取互联企业部门成员（简要信息）
    /// </summary>
    /// <param name="departmentId">CorpId/DepartmentId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>成员简要信息列表</returns>
    public async Task<LinkedCorpSimpleUser[]> GetUserSimpleListAsync(string departmentId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpSimpleListResponse>(
            "/cgi-bin/linkedcorp/user/simplelist",
            new LinkedCorpUserListRequest { DepartmentId = departmentId }, ct);
        return resp.UserList ?? [];
    }

    /// <summary>
    /// 获取互联企业部门成员详情
    /// </summary>
    /// <param name="departmentId">CorpId/DepartmentId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>成员详细信息列表</returns>
    public async Task<LinkedCorpUser[]> GetUserListAsync(string departmentId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpUserListResponse>(
            "/cgi-bin/linkedcorp/user/list",
            new LinkedCorpUserListRequest { DepartmentId = departmentId }, ct);
        return resp.UserList ?? [];
    }

    /// <summary>
    /// 获取互联企业部门列表
    /// </summary>
    /// <param name="departmentId">CorpId/DepartmentId 拼接的字符串</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>部门列表</returns>
    public async Task<LinkedCorpDepartment[]> GetDepartmentListAsync(string departmentId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<LinkedCorpDepartmentListResponse>(
            "/cgi-bin/linkedcorp/department/list",
            new LinkedCorpDepartmentListRequest { DepartmentId = departmentId }, ct);
        return resp.DepartmentList ?? [];
    }
}
