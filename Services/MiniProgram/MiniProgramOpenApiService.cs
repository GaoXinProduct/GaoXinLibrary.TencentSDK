using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序 OpenAPI 管理服务实现</summary>
public class MiniProgramOpenApiService
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

    /// <summary>清除接口调用次数（POST /cgi-bin/clear_quota）</summary>
    public Task<ClearQuotaResponse> ClearQuotaAsync(CancellationToken ct = default)
        => _http.PostAsync<ClearQuotaResponse>("/cgi-bin/clear_quota", new ClearQuotaRequest { AppId = _appId }, ct);
    /// <summary>重置指定API调用次数（POST /cgi-bin/openapi/quota/clear）</summary>
    public Task<ClearApiQuotaResponse> ClearApiQuotaAsync(ClearApiQuotaRequest request, CancellationToken ct = default)
        => _http.PostAsync<ClearApiQuotaResponse>("/cgi-bin/openapi/quota/clear", request, ct);
    /// <summary>使用AppSecret重置API调用次数（POST /cgi-bin/clear_quota/v2）</summary>
    public Task<ClearQuotaByAppSecretResponse> ClearQuotaByAppSecretAsync(CancellationToken ct = default)
        => _http.PostAsync<ClearQuotaByAppSecretResponse>("/cgi-bin/clear_quota/v2",
            new ClearQuotaByAppSecretRequest { AppId = _appId, AppSecret = _appSecret }, ct);
    /// <summary>查询接口调用额度（POST /cgi-bin/openapi/quota/get）</summary>
    public Task<GetApiQuotaResponse> GetQuotaAsync(GetApiQuotaRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetApiQuotaResponse>("/cgi-bin/openapi/quota/get", request, ct);
    /// <summary>查询 rid 信息（POST /cgi-bin/openapi/rid/get）</summary>
    public Task<GetRidInfoResponse> GetRidInfoAsync(GetRidInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetRidInfoResponse>("/cgi-bin/openapi/rid/get", request, ct);
    /// <summary>网络通信检测（POST /cgi-bin/callback/check）</summary>
    public Task<CallbackCheckResponse> CallbackCheckAsync(CallbackCheckRequest request, CancellationToken ct = default)
        => _http.PostAsync<CallbackCheckResponse>("/cgi-bin/callback/check", request, ct);
    /// <summary>获取微信API服务器IP列表（GET /cgi-bin/get_api_domain_ip）</summary>
    public Task<GetApiDomainIpResponse> GetApiDomainIpAsync(CancellationToken ct = default)
        => _http.GetAsync<GetApiDomainIpResponse>("/cgi-bin/get_api_domain_ip", null, ct);
    /// <summary>获取微信推送服务器IP列表（GET /cgi-bin/getcallbackip）</summary>
    public Task<GetCallbackIpResponse> GetCallbackIpAsync(CancellationToken ct = default)
        => _http.GetAsync<GetCallbackIpResponse>("/cgi-bin/getcallbackip", null, ct);
}

