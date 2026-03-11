using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>查询电子发票响应</summary>
public class GetInvoiceInfoResponse : WecomBaseResponse
{
    /// <summary>发票信息</summary>
    [JsonPropertyName("invoice_info")] public InvoiceInfo? InvoiceInfo { get; set; }
}
