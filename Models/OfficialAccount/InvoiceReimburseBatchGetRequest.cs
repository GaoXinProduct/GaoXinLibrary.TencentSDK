using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 批量获取报销发票信息请求
/// </summary>
public class InvoiceReimburseBatchGetRequest
{
    [JsonPropertyName("item_list")] public required List<InvoiceCardIdentifier> ItemList { get; set; }
}
