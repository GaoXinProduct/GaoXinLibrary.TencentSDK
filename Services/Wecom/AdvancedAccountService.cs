using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>高级功能账号管理服务实现</summary>
public class AdvancedAccountService
{
    private readonly WecomHttpClient _http;

    public AdvancedAccountService(WecomHttpClient http) => _http = http;

    /// <summary>分配高级功能账号</summary>
    public async Task AssignAsync(AdvancedAccountOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/advanced_account/assign", request, ct);

    /// <summary>取消高级功能账号</summary>
    public async Task CancelAsync(AdvancedAccountOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/advanced_account/cancel", request, ct);

    /// <summary>获取高级功能账号列表</summary>
    public async Task<GetAdvancedAccountListResponse> GetListAsync(GetAdvancedAccountListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetAdvancedAccountListResponse>("/cgi-bin/advanced_account/get_list", request, ct);
}
