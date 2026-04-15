using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>账号ID管理服务实现</summary>
public class AccountIdService
{
    private readonly WecomHttpClient _http;

    public AccountIdService(WecomHttpClient http) => _http = http;

    /// <summary>tmp_external_userid的转换</summary>
    public async Task<ConvertTmpExternalUserIdResponse> ConvertTmpExternalUserIdAsync(ConvertTmpExternalUserIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ConvertTmpExternalUserIdResponse>("/cgi-bin/idconvert/convert_tmp_external_userid", request, ct);
}
