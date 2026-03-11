using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Security;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>安全管理服务实现</summary>
public class SecurityService : ISecurityService
{
    private readonly WecomHttpClient _http;

    public SecurityService(WecomHttpClient http) => _http = http;

    public async Task<GetFileLeakPreventionResponse> GetFileLeakPreventionAsync(CancellationToken ct = default)
        => await _http.PostAsync<GetFileLeakPreventionResponse>("/cgi-bin/security/get_file_oper_record", new { }, ct);

    public async Task<GetDeviceInfoResponse> GetDeviceInfoAsync(string userId, CancellationToken ct = default)
        => await _http.PostAsync<GetDeviceInfoResponse>("/cgi-bin/security/trustdevice/get_by_user",
            new { userid = userId }, ct);
}
