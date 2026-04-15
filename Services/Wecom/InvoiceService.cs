using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>电子发票服务实现</summary>
public class InvoiceService
{
    private readonly WecomHttpClient _http;

    public InvoiceService(WecomHttpClient http) => _http = http;

    /// <summary>查询电子发票</summary>
    public async Task<InvoiceInfo?> GetInvoiceInfoAsync(GetInvoiceInfoRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetInvoiceInfoResponse>("/cgi-bin/card/invoice/reimburse/getinvoiceinfo", request, ct);
        return resp.InvoiceInfo;
    }

    /// <summary>批量查询电子发票</summary>
    public async Task<InvoiceInfo[]> BatchGetInvoiceInfoAsync(BatchGetInvoiceInfoRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<BatchGetInvoiceInfoResponse>("/cgi-bin/card/invoice/reimburse/getinvoiceinfobatch", request, ct);
        return resp.ItemList ?? [];
    }

    /// <summary>更新发票状态</summary>
    public async Task UpdateInvoiceStatusAsync(UpdateInvoiceStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/card/invoice/reimburse/updateinvoicestatus", request, ct);

    /// <summary>批量更新发票状态</summary>
    public async Task BatchUpdateInvoiceStatusAsync(BatchUpdateInvoiceStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/card/invoice/reimburse/updatestatusbatch", request, ct);
}
