using GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>高级功能账号管理服务接口</summary>
public interface IAdvancedAccountService
{
    /// <summary>分配高级功能账号</summary>
    Task AssignAsync(AdvancedAccountOperationRequest request, CancellationToken ct = default);

    /// <summary>取消高级功能账号</summary>
    Task CancelAsync(AdvancedAccountOperationRequest request, CancellationToken ct = default);

    /// <summary>获取高级功能账号列表</summary>
    Task<GetAdvancedAccountListResponse> GetListAsync(GetAdvancedAccountListRequest request, CancellationToken ct = default);
}
