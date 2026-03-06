using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序登录服务实现</summary>
public class MiniProgramAuthService : IMiniProgramAuthService
{
    private readonly WechatHttpClient _http;
    private readonly string _appId;
    private readonly string _appSecret;
    private readonly string _baseUrl;

    public MiniProgramAuthService(WechatHttpClient http, WechatOptions options)
    {
        _http = http;
        _appId = options.AppId;
        _appSecret = options.AppSecret;
        _baseUrl = options.BaseUrl.TrimEnd('/');
    }

    /// <inheritdoc/>
    public async Task<Code2SessionResponse> Code2SessionAsync(string jsCode, CancellationToken ct = default)
    {
        var url = $"{_baseUrl}/sns/jscode2session?appid={Uri.EscapeDataString(_appId)}&secret={Uri.EscapeDataString(_appSecret)}&js_code={Uri.EscapeDataString(jsCode)}&grant_type=authorization_code";
        return await _http.GetWithoutTokenAsync<Code2SessionResponse>(url, ct);
    }

    /// <inheritdoc/>
    public async Task<GetPhoneNumberResponse> GetPhoneNumberAsync(string code, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetPhoneNumberResponse>(
            "/wxa/business/getuserphonenumber",
            new GetPhoneNumberRequest { Code = code }, ct);
    }

    /// <inheritdoc/>
    public Task<CheckSessionKeyResponse> CheckSessionKeyAsync(string openId, string sessionKey, CancellationToken ct = default)
        => _http.GetAsync<CheckSessionKeyResponse>("/wxa/checksession",
            new Dictionary<string, string?>
            {
                ["openid"] = openId,
                ["signature"] = sessionKey
            }, ct);

    /// <inheritdoc/>
    public Task<ResetUserSessionKeyResponse> ResetUserSessionKeyAsync(string openId, string sessionKey, CancellationToken ct = default)
        => _http.GetAsync<ResetUserSessionKeyResponse>("/wxa/resetusersessionkey",
            new Dictionary<string, string?>
            {
                ["openid"] = openId,
                ["signature"] = sessionKey
            }, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  小程序码服务

