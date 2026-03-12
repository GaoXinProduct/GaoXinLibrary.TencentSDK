using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 更新报销发票状态请求
/// </summary>
public class InvoiceReimburseUpdateStatusRequest
{
    [JsonPropertyName("card_id")] public required string CardId { get; set; }
    [JsonPropertyName("encrypt_code")] public required string EncryptCode { get; set; }
    [JsonPropertyName("reimburse_status")] public required string ReimburseStatus { get; set; }
}
