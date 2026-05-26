using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 批量更新报销发票状态请求
/// </summary>
public sealed class InvoiceReimburseBatchUpdateStatusRequest
{
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
    [JsonPropertyName("reimburse_status")] public required string ReimburseStatus { get; set; }
    [JsonPropertyName("invoice_list")] public required List<InvoiceCardIdentifier> InvoiceList { get; set; }
}
