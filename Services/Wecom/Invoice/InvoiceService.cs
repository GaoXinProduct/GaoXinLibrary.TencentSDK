using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>电子发票服务实现</summary>
public class InvoiceService : IInvoiceService
{
    private readonly WecomHttpClient _http;

    public InvoiceService(WecomHttpClient http) => _http = http;

    public async Task<InvoiceInfo?> GetInvoiceInfoAsync(GetInvoiceInfoRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetInvoiceInfoResponse>("/cgi-bin/card/invoice/reimburse/getinvoiceinfo", request, ct);
        return resp.InvoiceInfo;
    }

    public async Task<InvoiceInfo[]> BatchGetInvoiceInfoAsync(BatchGetInvoiceInfoRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<BatchGetInvoiceInfoResponse>("/cgi-bin/card/invoice/reimburse/getinvoiceinfobatch", request, ct);
        return resp.ItemList ?? [];
    }

    public async Task UpdateInvoiceStatusAsync(UpdateInvoiceStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/card/invoice/reimburse/updateinvoicestatus", request, ct);

    public async Task BatchUpdateInvoiceStatusAsync(BatchUpdateInvoiceStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/card/invoice/reimburse/updatestatusbatch", request, ct);
}
