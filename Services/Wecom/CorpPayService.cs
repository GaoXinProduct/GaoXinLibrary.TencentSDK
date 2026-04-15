using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业支付服务实现</summary>
/// <remarks>
/// <see cref="GetBillListAsync"/> 和 <see cref="GetProjectBillListAsync"/> 均调用同一企业微信 API 端点
/// <c>/cgi-bin/externalpay/get_bill_list</c>，通过不同的请求体字段区分查询方式。
/// </remarks>
public class CorpPayService
{
    private readonly WecomHttpClient _http;

    public CorpPayService(WecomHttpClient http) => _http = http;

    /// <summary>
    /// 获取对外收款记录（按时间范围查询）
    /// <para>调用接口: <c>POST /cgi-bin/externalpay/get_bill_list</c></para>
    /// </summary>
    public async Task<GetBillListResponse> GetBillListAsync(GetBillListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list", request, ct);

    /// <summary>
    /// 获取收款项目的商户单号（按项目ID查询）
    /// <para>调用接口: <c>POST /cgi-bin/externalpay/get_bill_list</c>，与 <see cref="GetBillListAsync"/> 共用同一端点，仅查询参数不同。</para>
    /// </summary>
    public async Task<GetBillListResponse> GetProjectBillListAsync(GetProjectBillListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list", request, ct);
}
