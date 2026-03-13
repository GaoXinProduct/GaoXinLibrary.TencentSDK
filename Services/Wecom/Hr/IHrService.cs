using GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>人事助手服务接口</summary>
public interface IHrService
{
    /// <summary>获取员工字段配置</summary>
    Task<HrFieldGroup[]> GetFieldConfigAsync(CancellationToken ct = default);

    /// <summary>获取员工花名册信息</summary>
    Task<StaffInfo[]> GetStaffInfoAsync(GetStaffInfoRequest request, CancellationToken ct = default);

    /// <summary>更新员工花名册信息</summary>
    Task UpdateStaffInfoAsync(UpdateStaffInfoRequest request, CancellationToken ct = default);
}
