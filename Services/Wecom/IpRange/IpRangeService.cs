using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.IpRange;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>IP段查询服务实现</summary>
public class IpRangeService : IIpRangeService
{
    private readonly WecomHttpClient _http;

    public IpRangeService(WecomHttpClient http) => _http = http;

    public async Task<string[]> GetApiIpListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetIpListResponse>("/cgi-bin/get_api_domain_ip", ct: ct);
        return resp.IpList ?? [];
    }

    public async Task<string[]> GetCallbackIpListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetIpListResponse>("/cgi-bin/getcallbackip", ct: ct);
        return resp.IpList ?? [];
    }
}
