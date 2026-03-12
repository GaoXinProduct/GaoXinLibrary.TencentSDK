using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票详情信息
/// </summary>
public class InvoiceDetailInfo
{
    /// <summary>发票详情内容</summary>
    [JsonPropertyName("detail")] public string? Detail { get; set; }

    /// <summary>发票 PDF 链接</summary>
    [JsonPropertyName("pdf_url")] public string? PdfUrl { get; set; }

    /// <summary>其它消费凭证附件链接</summary>
    [JsonPropertyName("trip_pdf_url")] public string? TripPdfUrl { get; set; }

    /// <summary>发票报销状态</summary>
    [JsonPropertyName("reimburse_status")] public string? ReimburseStatus { get; set; }
}
