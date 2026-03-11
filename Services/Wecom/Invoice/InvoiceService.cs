using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>电子发票服务实现</summary>
public class InvoiceService : IInvoiceService
{
    private readonly WecomHttpClient _http;

    public InvoiceService(WecomHttpClient http) => _http = http;

    public async Task<InvoiceInfo?> GetInvoiceInfoAsync(string cardId, string encryptCode, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetInvoiceInfoResponse>("/cgi-bin/card/invoice/reimburse/getinvoiceinfo",
            new { card_id = cardId, encrypt_code = encryptCode }, ct);
        return resp.InvoiceInfo;
    }

    public async Task<InvoiceInfo[]> BatchGetInvoiceInfoAsync(string[] cardIdAndEncryptCodes, CancellationToken ct = default)
    {
        var items = new List<object>();
        for (int i = 0; i + 1 < cardIdAndEncryptCodes.Length; i += 2)
            items.Add(new { card_id = cardIdAndEncryptCodes[i], encrypt_code = cardIdAndEncryptCodes[i + 1] });

        var resp = await _http.PostAsync<BatchGetInvoiceInfoResponse>("/cgi-bin/card/invoice/reimburse/getinvoiceinfobatch",
            new { item_list = items }, ct);
        return resp.ItemList ?? [];
    }

    public async Task UpdateInvoiceStatusAsync(string cardId, string encryptCode, int reimburseStatus, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/card/invoice/reimburse/updateinvoicestatus",
            new { card_id = cardId, encrypt_code = encryptCode, reimburse_status = reimburseStatus }, ct);

    public async Task BatchUpdateInvoiceStatusAsync(string openid, int reimburseStatus, string[] cardIdAndEncryptCodes, CancellationToken ct = default)
    {
        var items = new List<object>();
        for (int i = 0; i + 1 < cardIdAndEncryptCodes.Length; i += 2)
            items.Add(new { card_id = cardIdAndEncryptCodes[i], encrypt_code = cardIdAndEncryptCodes[i + 1] });

        await _http.PostAsync<WecomBaseResponse>("/cgi-bin/card/invoice/reimburse/updatestatusbatch",
            new { openid, reimburse_status = reimburseStatus, invoice_list = items }, ct);
    }
}
