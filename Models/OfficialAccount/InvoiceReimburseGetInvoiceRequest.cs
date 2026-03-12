using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 查询报销发票信息请求
/// </summary>
public class InvoiceReimburseGetInvoiceRequest
{
    [JsonPropertyName("card_id")] public required string CardId { get; set; }
    [JsonPropertyName("encrypt_code")] public required string EncryptCode { get; set; }
}
