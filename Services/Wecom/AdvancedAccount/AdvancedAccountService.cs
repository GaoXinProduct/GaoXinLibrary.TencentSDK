using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>高级功能账号管理服务实现</summary>
public class AdvancedAccountService : IAdvancedAccountService
{
    private readonly WecomHttpClient _http;

    public AdvancedAccountService(WecomHttpClient http) => _http = http;

    public async Task AssignAsync(AdvancedAccountOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/advanced_account/assign", request, ct);

    public async Task CancelAsync(AdvancedAccountOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/advanced_account/cancel", request, ct);

    public async Task<GetAdvancedAccountListResponse> GetListAsync(GetAdvancedAccountListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetAdvancedAccountListResponse>("/cgi-bin/advanced_account/get_list", request, ct);
}
