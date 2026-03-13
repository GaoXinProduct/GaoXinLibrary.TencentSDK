using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;
using System.Text;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 公众号微信发票（商户开票）服务实现
/// </summary>
public class OfficialInvoiceService : IOfficialInvoiceService
{
    private readonly WechatHttpClient _http;

    public OfficialInvoiceService(WechatHttpClient http)
    {
        _http = http;
    }

    public Task<InvoiceSetBizAttrResponse> SetAuthFieldAsync(InvoiceSetAuthFieldRequest request, CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.SetAuthField, request, ct);

    public Task<InvoiceSetBizAttrResponse> GetAuthFieldAsync(CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.GetAuthField, EmptyRequest.Instance, ct);

    public Task<InvoiceSetBizAttrResponse> SetPayMchAsync(InvoiceSetPayMchRequest request, CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.SetPayMch, request, ct);

    public Task<InvoiceSetBizAttrResponse> GetPayMchAsync(CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.GetPayMch, EmptyRequest.Instance, ct);

    public Task<InvoiceSetBizAttrResponse> SetContactAsync(InvoiceSetContactRequest request, CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.SetContact, request, ct);

    public Task<InvoiceSetBizAttrResponse> GetContactAsync(CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.GetContact, EmptyRequest.Instance, ct);

    public Task<InvoiceAuthDataResponse> GetAuthDataAsync(InvoiceAuthDataRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceAuthDataResponse>("/card/invoice/getauthdata", request, ct);

    public Task<InvoiceTicketResponse> GetTicketAsync(CancellationToken ct = default)
        => _http.GetAsync<InvoiceTicketResponse>("/cgi-bin/ticket/getticket",
            new Dictionary<string, string?> { ["type"] = "wx_card" }, ct);

    public Task<InvoiceGetAuthUrlResponse> GetAuthUrlAsync(InvoiceGetAuthUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceGetAuthUrlResponse>("/card/invoice/getauthurl", request, ct);

    public Task<WechatBaseResponse> RejectInsertAsync(InvoiceRejectInsertRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/rejectinsert", request, ct);

    public Task<InvoicePlatformSetUrlResponse> GetPlatformInvoiceUrlAsync(CancellationToken ct = default)
        => _http.PostAsync<InvoicePlatformSetUrlResponse>("/card/invoice/seturl", EmptyRequest.Instance, ct);

    public Task<InvoicePlatformGetPdfResponse> GetPlatformPdfAsync(InvoicePlatformGetPdfRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoicePlatformGetPdfResponse>("/card/invoice/platform/getpdf", request, ct);

    public Task<WechatBaseResponse> UpdatePlatformInvoiceStatusAsync(InvoicePlatformUpdateStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/platform/updatestatus", request, ct);

    public async Task<InvoicePlatformSetPdfResponse> UploadPlatformPdfAsync(Stream fileStream, string fileName, CancellationToken ct = default)
    {
        using var ms = new MemoryStream();
        await fileStream.CopyToAsync(ms, ct);
        using var form = BuildPdfForm(fileName, ms.ToArray());
        return await _http.PostRawFormAsync<InvoicePlatformSetPdfResponse>("/card/invoice/platform/setpdf", form, null, ct);
    }

    public async Task<InvoicePlatformSetPdfResponse> UploadPlatformPdfAsync(ReadOnlyMemory<byte> fileBytes, string fileName, CancellationToken ct = default)
    {
        using var form = BuildPdfForm(fileName, fileBytes);
        return await _http.PostRawFormAsync<InvoicePlatformSetPdfResponse>("/card/invoice/platform/setpdf", form, null, ct);
    }

    public Task<InvoicePlatformCreateCardResponse> CreatePlatformCardAsync(InvoicePlatformCreateCardRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoicePlatformCreateCardResponse>("/card/invoice/platform/createcard", request, ct);

    public Task<InvoiceInsertResponse> InsertInvoiceAsync(InvoiceInsertRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceInsertResponse>("/card/invoice/insert", request, ct);

    public Task<InvoiceReimburseGetInvoiceResponse> GetReimburseInvoiceAsync(InvoiceReimburseGetInvoiceRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceReimburseGetInvoiceResponse>("/card/invoice/reimburse/getinvoiceinfo", request, ct);

    public Task<WechatBaseResponse> UpdateReimburseInvoiceStatusAsync(InvoiceReimburseUpdateStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/reimburse/updateinvoicestatus", request, ct);

    public Task<WechatBaseResponse> BatchUpdateReimburseInvoiceStatusAsync(InvoiceReimburseBatchUpdateStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/reimburse/updatestatusbatch", request, ct);

    public Task<InvoiceReimburseBatchGetResponse> BatchGetReimburseInvoiceAsync(InvoiceReimburseBatchGetRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceReimburseBatchGetResponse>("/card/invoice/reimburse/getinvoicebatch", request, ct);

    public Task<InvoiceGetUserTitleUrlResponse> GetUserTitleUrlAsync(InvoiceGetUserTitleUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceGetUserTitleUrlResponse>("/card/invoice/biz/getusertitleurl", request, ct);

    public Task<InvoiceGetSelectTitleUrlResponse> GetSelectTitleUrlAsync(InvoiceGetSelectTitleUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceGetSelectTitleUrlResponse>("/card/invoice/biz/getselecttitleurl", request, ct);

    public Task<InvoiceScanTitleResponse> ScanTitleAsync(InvoiceScanTitleRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceScanTitleResponse>("/card/invoice/scantitle", request, ct);

    public Task<NonTaxGetAuthUrlResponse> GetNonTaxAuthUrlAsync(NonTaxGetAuthUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<NonTaxGetAuthUrlResponse>("/nontax/getbillauthurl", request, ct);

    public Task<NonTaxCreateCardResponse> CreateNonTaxCardAsync(NonTaxCreateCardRequest request, CancellationToken ct = default)
        => _http.PostAsync<NonTaxCreateCardResponse>("/nontax/createbillcard", request, ct);

    public Task<NonTaxInsertResponse> InsertNonTaxInvoiceAsync(NonTaxInsertRequest request, CancellationToken ct = default)
        => _http.PostAsync<NonTaxInsertResponse>("/nontax/insertbill", request, ct);

    private Task<InvoiceSetBizAttrResponse> PostSetBizAttrAsync(string action, object body, CancellationToken ct)
        => _http.PostAsync<InvoiceSetBizAttrResponse>(
            "/card/invoice/setbizattr",
            body,
            new Dictionary<string, string?> { ["action"] = action },
            ct);

    private static ByteArrayContent BuildPdfForm(string fileName, ReadOnlyMemory<byte> fileData)
    {
        var boundary = Guid.NewGuid().ToString("N");
        var partHeader = Encoding.UTF8.GetBytes(
            $"--{boundary}\r\n" +
            $"Content-Disposition: form-data; name=\"pdf\"; filename=\"{fileName}\"\r\n" +
            "Content-Type: application/pdf\r\n\r\n");
        var partFooter = Encoding.UTF8.GetBytes($"\r\n--{boundary}--\r\n");

        var body = new byte[partHeader.Length + fileData.Length + partFooter.Length];
        partHeader.AsSpan().CopyTo(body.AsSpan());
        fileData.Span.CopyTo(body.AsSpan(partHeader.Length));
        partFooter.AsSpan().CopyTo(body.AsSpan(partHeader.Length + fileData.Length));

        var content = new ByteArrayContent(body);
        content.Headers.TryAddWithoutValidation("Content-Type", $"multipart/form-data; boundary={boundary}");
        return content;
    }
}
