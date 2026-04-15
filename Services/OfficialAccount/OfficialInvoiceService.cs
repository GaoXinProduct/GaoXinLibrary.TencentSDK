using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;
using System.Text;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 公众号微信发票（商户开票）服务实现
/// </summary>
public class OfficialInvoiceService
{
    private readonly WechatHttpClient _http;

    public OfficialInvoiceService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 设置授权页字段（action=set_auth_field）
    /// </summary>
    public Task<InvoiceSetBizAttrResponse> SetAuthFieldAsync(InvoiceSetAuthFieldRequest request, CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.SetAuthField, request, ct);

    /// <summary>
    /// 查询授权页字段（action=get_auth_field）
    /// </summary>
    public Task<InvoiceSetBizAttrResponse> GetAuthFieldAsync(CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.GetAuthField, EmptyRequest.Instance, ct);

    /// <summary>
    /// 关联商户号与开票平台（action=set_pay_mch）
    /// </summary>
    public Task<InvoiceSetBizAttrResponse> SetPayMchAsync(InvoiceSetPayMchRequest request, CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.SetPayMch, request, ct);

    /// <summary>
    /// 查询商户号与开票平台关联（action=get_pay_mch）
    /// </summary>
    public Task<InvoiceSetBizAttrResponse> GetPayMchAsync(CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.GetPayMch, EmptyRequest.Instance, ct);

    /// <summary>
    /// 设置商户联系方式（action=set_contact）
    /// </summary>
    public Task<InvoiceSetBizAttrResponse> SetContactAsync(InvoiceSetContactRequest request, CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.SetContact, request, ct);

    /// <summary>
    /// 查询商户联系方式（action=get_contact）
    /// </summary>
    public Task<InvoiceSetBizAttrResponse> GetContactAsync(CancellationToken ct = default)
        => PostSetBizAttrAsync(InvoiceSetBizAttrAction.GetContact, EmptyRequest.Instance, ct);

    /// <summary>
    /// 查询授权信息
    /// </summary>
    public Task<InvoiceAuthDataResponse> GetAuthDataAsync(InvoiceAuthDataRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceAuthDataResponse>("/card/invoice/getauthdata", request, ct);

    /// <summary>
    /// 获取发票 SDK 临时票据
    /// </summary>
    public Task<InvoiceTicketResponse> GetTicketAsync(CancellationToken ct = default)
        => _http.GetAsync<InvoiceTicketResponse>("/cgi-bin/ticket/getticket",
            new Dictionary<string, string?> { ["type"] = "wx_card" }, ct);

    /// <summary>
    /// 获取授权页链接
    /// </summary>
    public Task<InvoiceGetAuthUrlResponse> GetAuthUrlAsync(InvoiceGetAuthUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceGetAuthUrlResponse>("/card/invoice/getauthurl", request, ct);

    /// <summary>
    /// 拒绝开票
    /// </summary>
    public Task<WechatBaseResponse> RejectInsertAsync(InvoiceRejectInsertRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/rejectinsert", request, ct);

    /// <summary>
    /// 获取开票平台识别码
    /// </summary>
    public Task<InvoicePlatformSetUrlResponse> GetPlatformInvoiceUrlAsync(CancellationToken ct = default)
        => _http.PostAsync<InvoicePlatformSetUrlResponse>("/card/invoice/seturl", EmptyRequest.Instance, ct);

    /// <summary>
    /// 查询已上传 PDF 文件
    /// </summary>
    public Task<InvoicePlatformGetPdfResponse> GetPlatformPdfAsync(InvoicePlatformGetPdfRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoicePlatformGetPdfResponse>("/card/invoice/platform/getpdf", request, ct);

    /// <summary>
    /// 更新发票卡券状态
    /// </summary>
    public Task<WechatBaseResponse> UpdatePlatformInvoiceStatusAsync(InvoicePlatformUpdateStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/platform/updatestatus", request, ct);

    /// <summary>
    /// 上传发票 PDF
    /// </summary>
    public async Task<InvoicePlatformSetPdfResponse> UploadPlatformPdfAsync(Stream fileStream, string fileName, CancellationToken ct = default)
    {
        using var ms = new MemoryStream();
        await fileStream.CopyToAsync(ms, ct);
        using var form = BuildPdfForm(fileName, ms.ToArray());
        return await _http.PostRawFormAsync<InvoicePlatformSetPdfResponse>("/card/invoice/platform/setpdf", form, null, ct);
    }

    /// <summary>
    /// 上传发票 PDF
    /// </summary>
    public async Task<InvoicePlatformSetPdfResponse> UploadPlatformPdfAsync(ReadOnlyMemory<byte> fileBytes, string fileName, CancellationToken ct = default)
    {
        using var form = BuildPdfForm(fileName, fileBytes);
        return await _http.PostRawFormAsync<InvoicePlatformSetPdfResponse>("/card/invoice/platform/setpdf", form, null, ct);
    }

    /// <summary>
    /// 创建发票卡券模板
    /// </summary>
    public Task<InvoicePlatformCreateCardResponse> CreatePlatformCardAsync(InvoicePlatformCreateCardRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoicePlatformCreateCardResponse>("/card/invoice/platform/createcard", request, ct);

    /// <summary>
    /// 将电子发票卡券插入用户卡包
    /// </summary>
    public Task<InvoiceInsertResponse> InsertInvoiceAsync(InvoiceInsertRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceInsertResponse>("/card/invoice/insert", request, ct);

    /// <summary>
    /// 查询报销发票信息
    /// </summary>
    public Task<InvoiceReimburseGetInvoiceResponse> GetReimburseInvoiceAsync(InvoiceReimburseGetInvoiceRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceReimburseGetInvoiceResponse>("/card/invoice/reimburse/getinvoiceinfo", request, ct);

    /// <summary>
    /// 更新报销发票状态
    /// </summary>
    public Task<WechatBaseResponse> UpdateReimburseInvoiceStatusAsync(InvoiceReimburseUpdateStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/reimburse/updateinvoicestatus", request, ct);

    /// <summary>
    /// 批量更新报销发票状态
    /// </summary>
    public Task<WechatBaseResponse> BatchUpdateReimburseInvoiceStatusAsync(InvoiceReimburseBatchUpdateStatusRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/card/invoice/reimburse/updatestatusbatch", request, ct);

    /// <summary>
    /// 批量获取报销发票信息
    /// </summary>
    public Task<InvoiceReimburseBatchGetResponse> BatchGetReimburseInvoiceAsync(InvoiceReimburseBatchGetRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceReimburseBatchGetResponse>("/card/invoice/reimburse/getinvoicebatch", request, ct);

    /// <summary>
    /// 录入抬头到用户微信
    /// </summary>
    public Task<InvoiceGetUserTitleUrlResponse> GetUserTitleUrlAsync(InvoiceGetUserTitleUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceGetUserTitleUrlResponse>("/card/invoice/biz/getusertitleurl", request, ct);

    /// <summary>
    /// 获取商户专属抬头链接
    /// </summary>
    public Task<InvoiceGetSelectTitleUrlResponse> GetSelectTitleUrlAsync(InvoiceGetSelectTitleUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceGetSelectTitleUrlResponse>("/card/invoice/biz/getselecttitleurl", request, ct);

    /// <summary>
    /// 解析扫描的抬头二维码
    /// </summary>
    public Task<InvoiceScanTitleResponse> ScanTitleAsync(InvoiceScanTitleRequest request, CancellationToken ct = default)
        => _http.PostAsync<InvoiceScanTitleResponse>("/card/invoice/scantitle", request, ct);

    /// <summary>
    /// 获取非税票据授权页链接
    /// </summary>
    public Task<NonTaxGetAuthUrlResponse> GetNonTaxAuthUrlAsync(NonTaxGetAuthUrlRequest request, CancellationToken ct = default)
        => _http.PostAsync<NonTaxGetAuthUrlResponse>("/nontax/getbillauthurl", request, ct);

    /// <summary>
    /// 创建财政电子票据模板
    /// </summary>
    public Task<NonTaxCreateCardResponse> CreateNonTaxCardAsync(NonTaxCreateCardRequest request, CancellationToken ct = default)
        => _http.PostAsync<NonTaxCreateCardResponse>("/nontax/createbillcard", request, ct);

    /// <summary>
    /// 插入财政电子票据到用户卡包
    /// </summary>
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
