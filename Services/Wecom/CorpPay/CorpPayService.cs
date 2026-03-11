using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业支付服务实现</summary>
public class CorpPayService : ICorpPayService
{
    private readonly WecomHttpClient _http;

    public CorpPayService(WecomHttpClient http) => _http = http;

    public async Task<GetBillListResponse> GetBillListAsync(long beginTime, long endTime, string? payeeUserId = null, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list",
            new { begin_time = beginTime, end_time = endTime, payee_userid = payeeUserId, cursor = cursor ?? "", limit }, ct);

    public async Task<GetBillListResponse> GetProjectBillListAsync(string projectId, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list",
            new { projectid = projectId, cursor = cursor ?? "", limit }, ct);
}
