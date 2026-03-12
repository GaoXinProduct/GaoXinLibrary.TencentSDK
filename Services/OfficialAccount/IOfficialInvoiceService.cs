using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 公众号微信发票（商户开票）服务接口
/// </summary>
public interface IOfficialInvoiceService
{
    /// <summary>
    /// 设置授权页字段（action=set_auth_field）
    /// </summary>
    Task<InvoiceSetBizAttrResponse> SetAuthFieldAsync(InvoiceSetAuthFieldRequest request, CancellationToken ct = default);

    /// <summary>
    /// 查询授权页字段（action=get_auth_field）
    /// </summary>
    Task<InvoiceSetBizAttrResponse> GetAuthFieldAsync(CancellationToken ct = default);

    /// <summary>
    /// 关联商户号与开票平台（action=set_pay_mch）
    /// </summary>
    Task<InvoiceSetBizAttrResponse> SetPayMchAsync(InvoiceSetPayMchRequest request, CancellationToken ct = default);

    /// <summary>
    /// 查询商户号与开票平台关联（action=get_pay_mch）
    /// </summary>
    Task<InvoiceSetBizAttrResponse> GetPayMchAsync(CancellationToken ct = default);

    /// <summary>
    /// 设置商户联系方式（action=set_contact）
    /// </summary>
    Task<InvoiceSetBizAttrResponse> SetContactAsync(InvoiceSetContactRequest request, CancellationToken ct = default);

    /// <summary>
    /// 查询商户联系方式（action=get_contact）
    /// </summary>
    Task<InvoiceSetBizAttrResponse> GetContactAsync(CancellationToken ct = default);

    /// <summary>
    /// 查询授权信息
    /// </summary>
    Task<InvoiceAuthDataResponse> GetAuthDataAsync(InvoiceAuthDataRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取发票 SDK 临时票据
    /// </summary>
    Task<InvoiceTicketResponse> GetTicketAsync(CancellationToken ct = default);

    /// <summary>
    /// 获取授权页链接
    /// </summary>
    Task<InvoiceGetAuthUrlResponse> GetAuthUrlAsync(InvoiceGetAuthUrlRequest request, CancellationToken ct = default);

    /// <summary>
    /// 拒绝开票
    /// </summary>
    Task<WechatBaseResponse> RejectInsertAsync(InvoiceRejectInsertRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取开票平台识别码
    /// </summary>
    Task<InvoicePlatformSetUrlResponse> GetPlatformInvoiceUrlAsync(CancellationToken ct = default);

    /// <summary>
    /// 查询已上传 PDF 文件
    /// </summary>
    Task<InvoicePlatformGetPdfResponse> GetPlatformPdfAsync(InvoicePlatformGetPdfRequest request, CancellationToken ct = default);

    /// <summary>
    /// 更新发票卡券状态
    /// </summary>
    Task<WechatBaseResponse> UpdatePlatformInvoiceStatusAsync(InvoicePlatformUpdateStatusRequest request, CancellationToken ct = default);

    /// <summary>
    /// 上传发票 PDF
    /// </summary>
    Task<InvoicePlatformSetPdfResponse> UploadPlatformPdfAsync(Stream fileStream, string fileName, CancellationToken ct = default);

    /// <summary>
    /// 上传发票 PDF
    /// </summary>
    Task<InvoicePlatformSetPdfResponse> UploadPlatformPdfAsync(ReadOnlyMemory<byte> fileBytes, string fileName, CancellationToken ct = default);

    /// <summary>
    /// 创建发票卡券模板
    /// </summary>
    Task<InvoicePlatformCreateCardResponse> CreatePlatformCardAsync(InvoicePlatformCreateCardRequest request, CancellationToken ct = default);

    /// <summary>
    /// 将电子发票卡券插入用户卡包
    /// </summary>
    Task<InvoiceInsertResponse> InsertInvoiceAsync(InvoiceInsertRequest request, CancellationToken ct = default);

    /// <summary>
    /// 查询报销发票信息
    /// </summary>
    Task<InvoiceReimburseGetInvoiceResponse> GetReimburseInvoiceAsync(InvoiceReimburseGetInvoiceRequest request, CancellationToken ct = default);

    /// <summary>
    /// 更新报销发票状态
    /// </summary>
    Task<WechatBaseResponse> UpdateReimburseInvoiceStatusAsync(InvoiceReimburseUpdateStatusRequest request, CancellationToken ct = default);

    /// <summary>
    /// 批量更新报销发票状态
    /// </summary>
    Task<WechatBaseResponse> BatchUpdateReimburseInvoiceStatusAsync(InvoiceReimburseBatchUpdateStatusRequest request, CancellationToken ct = default);

    /// <summary>
    /// 批量获取报销发票信息
    /// </summary>
    Task<InvoiceReimburseBatchGetResponse> BatchGetReimburseInvoiceAsync(InvoiceReimburseBatchGetRequest request, CancellationToken ct = default);

    /// <summary>
    /// 录入抬头到用户微信
    /// </summary>
    Task<InvoiceGetUserTitleUrlResponse> GetUserTitleUrlAsync(InvoiceGetUserTitleUrlRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取商户专属抬头链接
    /// </summary>
    Task<InvoiceGetSelectTitleUrlResponse> GetSelectTitleUrlAsync(InvoiceGetSelectTitleUrlRequest request, CancellationToken ct = default);

    /// <summary>
    /// 解析扫描的抬头二维码
    /// </summary>
    Task<InvoiceScanTitleResponse> ScanTitleAsync(InvoiceScanTitleRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取非税票据授权页链接
    /// </summary>
    Task<NonTaxGetAuthUrlResponse> GetNonTaxAuthUrlAsync(NonTaxGetAuthUrlRequest request, CancellationToken ct = default);

    /// <summary>
    /// 创建财政电子票据模板
    /// </summary>
    Task<NonTaxCreateCardResponse> CreateNonTaxCardAsync(NonTaxCreateCardRequest request, CancellationToken ct = default);

    /// <summary>
    /// 插入财政电子票据到用户卡包
    /// </summary>
    Task<NonTaxInsertResponse> InsertNonTaxInvoiceAsync(NonTaxInsertRequest request, CancellationToken ct = default);
}
