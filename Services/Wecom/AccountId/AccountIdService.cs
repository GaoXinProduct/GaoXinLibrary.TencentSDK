using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>账号ID管理服务实现</summary>
public class AccountIdService : IAccountIdService
{
    private readonly WecomHttpClient _http;

    public AccountIdService(WecomHttpClient http) => _http = http;

    public async Task<ConvertTmpExternalUserIdResponse> ConvertTmpExternalUserIdAsync(string[] tmpExternalUserIds, int businessType = 1, CancellationToken ct = default)
        => await _http.PostAsync<ConvertTmpExternalUserIdResponse>("/cgi-bin/idconvert/convert_tmp_external_userid",
            new { tmp_external_userid_list = tmpExternalUserIds, business_type = businessType }, ct);
}
