using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>二次验证服务实现</summary>
public class SecondVerifyService : ISecondVerifyService
{
    private readonly WecomHttpClient _http;

    public SecondVerifyService(WecomHttpClient http) => _http = http;

    public async Task<GetTfaInfoResponse> GetTfaInfoAsync(GetTfaInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetTfaInfoResponse>("/cgi-bin/auth/get_tfa_info", request, ct);

    public async Task TfaSuccessAsync(string userId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/user/authsucc",
            new() { ["userid"] = userId }, ct);
}
