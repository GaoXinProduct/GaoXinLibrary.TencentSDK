using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>批量查询电子发票响应</summary>
public class BatchGetInvoiceInfoResponse : WecomBaseResponse
{
    /// <summary>发票列表</summary>
    [JsonPropertyName("item_list")] public InvoiceInfo[]? ItemList { get; set; }
}
