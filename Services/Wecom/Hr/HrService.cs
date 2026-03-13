using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>人事助手服务实现</summary>
public class HrService : IHrService
{
    private readonly WecomHttpClient _http;

    public HrService(WecomHttpClient http) => _http = http;

    public async Task<HrFieldGroup[]> GetFieldConfigAsync(CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetFieldConfigResponse>("/cgi-bin/hr/get_fields", EmptyRequest.Instance, ct);
        return resp.Group ?? [];
    }

    public async Task<StaffInfo[]> GetStaffInfoAsync(GetStaffInfoRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetStaffInfoResponse>("/cgi-bin/hr/get_staff_info", request, ct);
        return resp.Employee ?? [];
    }

    public async Task UpdateStaffInfoAsync(UpdateStaffInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/hr/update_staff_info", request, ct);
}
