using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>公费电话服务实现</summary>
public class DialService : IDialService
{
    private readonly WecomHttpClient _http;

    public DialService(WecomHttpClient http) => _http = http;

    public async Task<DialRecord[]> GetDialRecordAsync(long startTime, long endTime, int offset = 0, int limit = 100, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetDialRecordResponse>("/cgi-bin/dial/get_dial_record",
            new { start_time = startTime, end_time = endTime, offset, limit }, ct);
        return resp.Record ?? [];
    }
}
