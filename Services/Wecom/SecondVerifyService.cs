using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>二次验证服务实现</summary>
public class SecondVerifyService
{
    private readonly WecomHttpClient _http;

    public SecondVerifyService(WecomHttpClient http) => _http = http;

    /// <summary>获取用户二次验证信息</summary>
    public async Task<GetTfaInfoResponse> GetTfaInfoAsync(GetTfaInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetTfaInfoResponse>("/cgi-bin/auth/get_tfa_info", request, ct);

    /// <summary>登录二次验证</summary>
    public async Task TfaSuccessAsync(string userId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/user/authsucc",
            new() { ["userid"] = userId }, ct);
}
