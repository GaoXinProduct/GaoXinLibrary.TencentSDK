using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>批量获取发票信息请求</summary>
public class BatchGetInvoiceInfoRequest
{
    /// <summary>发票卡券项列表</summary>
    [JsonPropertyName("item_list")]
    public InvoiceCardItem[] ItemList { get; set; } = [];
}
