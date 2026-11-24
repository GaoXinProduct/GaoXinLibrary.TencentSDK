using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>二次验证服务实现</summary>
public sealed class SecondVerifyService
{
    private readonly WecomHttpClient _http;

    public SecondVerifyService(WecomHttpClient http) => _http = http;

    /// <summary>使用一次性 code 获取成员及二次验证授权码。</summary>
    /// <remarks>文档：https://developer.work.weixin.qq.com/document/path/99499</remarks>
    public Task<GetTfaInfoResponse> GetTfaInfoAsync(GetTfaInfoRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Code);
        return _http.PostAsync<GetTfaInfoResponse>("/cgi-bin/auth/get_tfa_info", request, ct);
    }

    /// <summary>企业验证成员身份后，确认首次加入企业的登录验证。</summary>
    /// <remarks>文档：https://developer.work.weixin.qq.com/document/path/99521</remarks>
    public async Task CompleteFirstLoginAsync(string userId, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userId);
        await _http.GetWithoutTransientRetryAsync<WecomBaseResponse>("/cgi-bin/user/authsucc",
            new() { ["userid"] = userId }, ct).ConfigureAwait(false);
    }

    /// <summary>企业验证成员身份后，使用一次性授权码完成使用二次验证。</summary>
    /// <remarks>文档：https://developer.work.weixin.qq.com/document/path/99500</remarks>
    public async Task CompleteTfaAsync(CompleteTfaRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.UserId);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.TfaCode);
        await _http.PostAsync<WecomBaseResponse>("/cgi-bin/user/tfa_succ", request, ct).ConfigureAwait(false);
    }

    /// <summary>首次加入企业时，确认登录验证。</summary>
    [Obsolete("首次加入请使用 CompleteFirstLoginAsync；使用二次验证请使用 CompleteTfaAsync。")]
    public Task TfaSuccessAsync(string userId, CancellationToken ct = default)
        => CompleteFirstLoginAsync(userId, ct);
}
