using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Department;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class DepartmentService : IDepartmentService
{
    private readonly WecomHttpClient _http;

    public DepartmentService(WecomHttpClient http) => _http = http;

    public async Task<int> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateDepartmentResponse>("/cgi-bin/department/create", request, ct);
        return resp.Id;
    }

    public async Task UpdateDepartmentAsync(UpdateDepartmentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/department/update", request, ct);

    public async Task DeleteDepartmentAsync(int id, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/department/delete",
            new() { ["id"] = id.ToString() }, ct);

    public async Task<DepartmentInfo[]> GetDepartmentListAsync(int? id = null, CancellationToken ct = default)
    {
        var query = new Dictionary<string, string?>();
        if (id.HasValue) query["id"] = id.Value.ToString();
        var resp = await _http.GetAsync<GetDepartmentListResponse>("/cgi-bin/department/list", query, ct);
        return resp.Department ?? [];
    }

    public async Task<SubDeptInfo[]> GetSubDepartmentIdsAsync(int id, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetSubDeptIdListResponse>("/cgi-bin/department/simplelist",
            new() { ["id"] = id.ToString() }, ct);
        return resp.DepartmentIds ?? [];
    }

    public async Task<DepartmentInfo> GetDepartmentAsync(int id, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetDepartmentResponse>("/cgi-bin/department/get",
            new() { ["id"] = id.ToString() }, ct);
        return resp.Department ?? new DepartmentInfo { Id = id };
    }
}
