using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.IpRange;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>IP段查询服务实现</summary>
public class IpRangeService
{
    private readonly WecomHttpClient _http;

    public IpRangeService(WecomHttpClient http) => _http = http;

    /// <summary>获取企业微信接口IP段</summary>
    public async Task<string[]> GetApiIpListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetIpListResponse>("/cgi-bin/get_api_domain_ip", ct: ct);
        return resp.IpList ?? [];
    }

    /// <summary>获取企业微信回调IP段</summary>
    public async Task<string[]> GetCallbackIpListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetIpListResponse>("/cgi-bin/getcallbackip", ct: ct);
        return resp.IpList ?? [];
    }
}
