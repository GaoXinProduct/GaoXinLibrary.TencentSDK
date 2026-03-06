using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序 OpenAPI 管理服务接口
/// </summary>
public interface IMiniProgramOpenApiService
{
    /// <summary>清除接口调用次数（POST /cgi-bin/clear_quota）</summary>
    Task<ClearQuotaResponse> ClearQuotaAsync(CancellationToken ct = default);
    /// <summary>重置指定API调用次数（POST /cgi-bin/openapi/quota/clear）</summary>
    Task<ClearApiQuotaResponse> ClearApiQuotaAsync(ClearApiQuotaRequest request, CancellationToken ct = default);
    /// <summary>使用AppSecret重置API调用次数（POST /cgi-bin/clear_quota/v2）</summary>
    Task<ClearQuotaByAppSecretResponse> ClearQuotaByAppSecretAsync(CancellationToken ct = default);
    /// <summary>查询接口调用额度（POST /cgi-bin/openapi/quota/get）</summary>
    Task<GetApiQuotaResponse> GetQuotaAsync(GetApiQuotaRequest request, CancellationToken ct = default);
    /// <summary>查询 rid 信息（POST /cgi-bin/openapi/rid/get）</summary>
    Task<GetRidInfoResponse> GetRidInfoAsync(GetRidInfoRequest request, CancellationToken ct = default);
    /// <summary>网络通信检测（POST /cgi-bin/callback/check）</summary>
    Task<CallbackCheckResponse> CallbackCheckAsync(CallbackCheckRequest request, CancellationToken ct = default);
    /// <summary>获取微信API服务器IP列表（GET /cgi-bin/get_api_domain_ip）</summary>
    Task<GetApiDomainIpResponse> GetApiDomainIpAsync(CancellationToken ct = default);
    /// <summary>获取微信推送服务器IP列表（GET /cgi-bin/getcallbackip）</summary>
    Task<GetCallbackIpResponse> GetCallbackIpAsync(CancellationToken ct = default);
}

