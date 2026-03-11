using GaoXinLibrary.TencentSDK.Wecom.Models.Security;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>安全管理服务接口</summary>
public interface ISecurityService
{
    /// <summary>获取文件防泄漏规则列表</summary>
    Task<GetFileLeakPreventionResponse> GetFileLeakPreventionAsync(CancellationToken ct = default);

    /// <summary>获取设备信息</summary>
    Task<GetDeviceInfoResponse> GetDeviceInfoAsync(string userId, CancellationToken ct = default);
}
