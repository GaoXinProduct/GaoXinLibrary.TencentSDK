using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序 OpenAPI 管理服务实现</summary>
public class MiniProgramOpenApiService : IMiniProgramOpenApiService
{
    private readonly WechatHttpClient _http;
    private readonly string _appId;
    private readonly string _appSecret;

    public MiniProgramOpenApiService(WechatHttpClient http, WechatOptions options)
    {
        _http = http;
        _appId = options.AppId;
        _appSecret = options.AppSecret;
    }

    /// <inheritdoc/>
    public Task<ClearQuotaResponse> ClearQuotaAsync(CancellationToken ct = default)
        => _http.PostAsync<ClearQuotaResponse>("/cgi-bin/clear_quota", new ClearQuotaRequest { AppId = _appId }, ct);
    /// <inheritdoc/>
    public Task<ClearApiQuotaResponse> ClearApiQuotaAsync(ClearApiQuotaRequest request, CancellationToken ct = default)
        => _http.PostAsync<ClearApiQuotaResponse>("/cgi-bin/openapi/quota/clear", request, ct);
    /// <inheritdoc/>
    public Task<ClearQuotaByAppSecretResponse> ClearQuotaByAppSecretAsync(CancellationToken ct = default)
        => _http.PostAsync<ClearQuotaByAppSecretResponse>("/cgi-bin/clear_quota/v2",
            new ClearQuotaByAppSecretRequest { AppId = _appId, AppSecret = _appSecret }, ct);
    /// <inheritdoc/>
    public Task<GetApiQuotaResponse> GetQuotaAsync(GetApiQuotaRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetApiQuotaResponse>("/cgi-bin/openapi/quota/get", request, ct);
    /// <inheritdoc/>
    public Task<GetRidInfoResponse> GetRidInfoAsync(GetRidInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetRidInfoResponse>("/cgi-bin/openapi/rid/get", request, ct);
    /// <inheritdoc/>
    public Task<CallbackCheckResponse> CallbackCheckAsync(CallbackCheckRequest request, CancellationToken ct = default)
        => _http.PostAsync<CallbackCheckResponse>("/cgi-bin/callback/check", request, ct);
    /// <inheritdoc/>
    public Task<GetApiDomainIpResponse> GetApiDomainIpAsync(CancellationToken ct = default)
        => _http.GetAsync<GetApiDomainIpResponse>("/cgi-bin/get_api_domain_ip", null, ct);
    /// <inheritdoc/>
    public Task<GetCallbackIpResponse> GetCallbackIpAsync(CancellationToken ct = default)
        => _http.GetAsync<GetCallbackIpResponse>("/cgi-bin/getcallbackip", null, ct);
}

