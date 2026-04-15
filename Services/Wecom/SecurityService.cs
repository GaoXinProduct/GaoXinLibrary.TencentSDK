using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Security;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>安全管理服务实现</summary>
public class SecurityService
{
    private readonly WecomHttpClient _http;

    public SecurityService(WecomHttpClient http) => _http = http;

    /// <summary>获取文件防泄漏规则列表</summary>
    public async Task<GetFileLeakPreventionResponse> GetFileLeakPreventionAsync(CancellationToken ct = default)
        => await _http.PostAsync<GetFileLeakPreventionResponse>("/cgi-bin/security/get_file_oper_record", EmptyRequest.Instance, ct);

    /// <summary>获取设备信息</summary>
    public async Task<GetDeviceInfoResponse> GetDeviceInfoAsync(GetDeviceInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDeviceInfoResponse>("/cgi-bin/security/trustdevice/get_by_user", request, ct);
}
