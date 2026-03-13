using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>批量更新发票状态请求</summary>
public class BatchUpdateInvoiceStatusRequest
{
    /// <summary>用户 openid</summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; } = string.Empty;

    /// <summary>报销状态</summary>
    [JsonPropertyName("reimburse_status")]
    public int ReimburseStatus { get; set; }

    /// <summary>发票列表</summary>
    [JsonPropertyName("invoice_list")]
    public InvoiceCardItem[] InvoiceList { get; set; } = [];
}
