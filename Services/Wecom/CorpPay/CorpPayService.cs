using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业支付服务实现</summary>
/// <remarks>
/// <see cref="GetBillListAsync"/> 和 <see cref="GetProjectBillListAsync"/> 均调用同一企业微信 API 端点
/// <c>/cgi-bin/externalpay/get_bill_list</c>，通过不同的请求体字段区分查询方式。
/// </remarks>
public class CorpPayService : ICorpPayService
{
    private readonly WecomHttpClient _http;

    public CorpPayService(WecomHttpClient http) => _http = http;

    public async Task<GetBillListResponse> GetBillListAsync(GetBillListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list", request, ct);

    public async Task<GetBillListResponse> GetProjectBillListAsync(GetProjectBillListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list", request, ct);
}
