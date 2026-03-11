using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>高级功能账号管理服务实现</summary>
public class AdvancedAccountService : IAdvancedAccountService
{
    private readonly WecomHttpClient _http;

    public AdvancedAccountService(WecomHttpClient http) => _http = http;

    public async Task AssignAsync(string userId, int type, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/advanced_account/assign",
            new { userid = userId, type }, ct);

    public async Task CancelAsync(string userId, int type, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/advanced_account/cancel",
            new { userid = userId, type }, ct);

    public async Task<GetAdvancedAccountListResponse> GetListAsync(int type, string? cursor = null, int limit = 1000, CancellationToken ct = default)
        => await _http.PostAsync<GetAdvancedAccountListResponse>("/cgi-bin/advanced_account/get_list",
            new { type, cursor = cursor ?? "", limit }, ct);
}
