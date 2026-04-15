using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号 OpenAPI 管理服务实现</summary>
public class OfficialOpenApiService
{
    private readonly WechatHttpClient _http;
    private readonly WechatOptions _options;

    public OfficialOpenApiService(WechatHttpClient http, WechatOptions options)
    {
        _http = http;
        _options = options;
    }

    /// <summary>清空 api 的调用 quota</summary>
    public Task<OfficialClearQuotaResponse> ClearQuotaAsync(CancellationToken ct = default)
        => _http.PostAsync<OfficialClearQuotaResponse>("/cgi-bin/clear_quota", new OfficialClearQuotaRequest { AppId = _options.AppId }, ct);

    /// <summary>查询 openAPI 调用额度</summary>
    public Task<OfficialGetApiQuotaResponse> GetQuotaAsync(OfficialGetApiQuotaRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialGetApiQuotaResponse>("/cgi-bin/openapi/quota/get", request, ct);

    /// <summary>查询 rid 信息</summary>
    public Task<OfficialGetRidInfoResponse> GetRidInfoAsync(string rid, CancellationToken ct = default)
        => _http.PostAsync<OfficialGetRidInfoResponse>("/cgi-bin/openapi/rid/get", new OfficialGetRidInfoRequest { Rid = rid }, ct);
}
