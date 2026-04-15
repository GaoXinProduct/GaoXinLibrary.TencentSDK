using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>公费电话服务实现</summary>
public class DialService
{
    private readonly WecomHttpClient _http;

    public DialService(WecomHttpClient http) => _http = http;

    /// <summary>获取公费电话拨打记录</summary>
    public async Task<DialRecord[]> GetDialRecordAsync(GetDialRecordRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetDialRecordResponse>("/cgi-bin/dial/get_dial_record", request, ct);
        return resp.Record ?? [];
    }
}
