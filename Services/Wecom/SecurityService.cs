using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Security;
using GaoXinLibrary.TencentSDK.Wecom.Models.Security.Expansion;

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

    /// <summary>
    /// 获取截屏/录屏管理配置
    /// <para>调用接口: <c>POST /cgi-bin/security/get_screen_capture_control</c></para>
    /// </summary>
    public async Task<GetScreenCaptureControlResponse> GetScreenCaptureControlAsync(GetScreenCaptureControlRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetScreenCaptureControlResponse>("/cgi-bin/security/get_screen_capture_control", request, ct);

    /// <summary>
    /// 设置截屏/录屏管理配置
    /// <para>调用接口: <c>POST /cgi-bin/security/set_screen_capture_control</c></para>
    /// </summary>
    public async Task<SetScreenCaptureControlResponse> SetScreenCaptureControlAsync(SetScreenCaptureControlRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetScreenCaptureControlResponse>("/cgi-bin/security/set_screen_capture_control", request, ct);
}
