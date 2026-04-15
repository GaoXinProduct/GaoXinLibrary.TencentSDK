using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Department;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class DepartmentService
{
    private readonly WecomHttpClient _http;

    public DepartmentService(WecomHttpClient http) => _http = http;

    /// <summary>
    /// 创建部门
    /// <para>对应接口：POST /cgi-bin/department/create</para>
    /// </summary>
    /// <param name="request">部门创建请求，包含名称、上级部门ID等</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>新创建的部门 ID</returns>
    public async Task<int> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateDepartmentResponse>("/cgi-bin/department/create", request, ct);
        return resp.Id;
    }

    /// <summary>
    /// 更新部门信息（名称、排序、负责人等）
    /// <para>对应接口：POST /cgi-bin/department/update</para>
    /// </summary>
    /// <param name="request">部门更新请求，id 字段为必填</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateDepartmentAsync(UpdateDepartmentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/department/update", request, ct);

    /// <summary>
    /// 删除部门（部门下不能有成员或子部门）
    /// <para>对应接口：GET /cgi-bin/department/delete</para>
    /// </summary>
    /// <param name="id">要删除的部门 ID</param>
    /// <param name="ct">取消令牌</param>
    public async Task DeleteDepartmentAsync(int id, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/department/delete",
            new() { ["id"] = id.ToString() }, ct);

    /// <summary>
    /// 获取部门列表
    /// <para>对应接口：GET /cgi-bin/department/list</para>
    /// </summary>
    /// <param name="id">部门 ID；填写后仅返回该部门及其子部门，不填则返回整个企业的部门列表</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>部门信息数组</returns>
    public async Task<DepartmentInfo[]> GetDepartmentListAsync(int? id = null, CancellationToken ct = default)
    {
        var query = new Dictionary<string, string?>();
        if (id.HasValue) query["id"] = id.Value.ToString();
        var resp = await _http.GetAsync<GetDepartmentListResponse>("/cgi-bin/department/list", query, ct);
        return resp.Department ?? [];
    }

    /// <summary>
    /// 获取子部门 ID 列表
    /// <para>对应接口：GET /cgi-bin/department/simplelist</para>
    /// </summary>
    /// <param name="id">父部门 ID</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>子部门信息数组（包含自身）</returns>
    public async Task<SubDeptInfo[]> GetSubDepartmentIdsAsync(int id, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetSubDeptIdListResponse>("/cgi-bin/department/simplelist",
            new() { ["id"] = id.ToString() }, ct);
        return resp.DepartmentIds ?? [];
    }

    /// <summary>
    /// 获取单个部门详细信息
    /// <para>对应接口：GET /cgi-bin/department/get</para>
    /// </summary>
    /// <param name="id">部门 ID</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>部门详细信息</returns>
    public async Task<DepartmentInfo> GetDepartmentAsync(int id, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetDepartmentResponse>("/cgi-bin/department/get",
            new() { ["id"] = id.ToString() }, ct);
        return resp.Department ?? new DepartmentInfo { Id = id };
    }
}
