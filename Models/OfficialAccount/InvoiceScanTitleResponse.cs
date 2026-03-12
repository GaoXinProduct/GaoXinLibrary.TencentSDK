using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 解析抬头二维码响应
/// </summary>
public class InvoiceScanTitleResponse : WechatBaseResponse
{
    [JsonPropertyName("title_type")] public int? TitleType { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("phone")] public string? Phone { get; set; }
    [JsonPropertyName("tax_no")] public string? TaxNo { get; set; }
    [JsonPropertyName("addr")] public string? Addr { get; set; }
    [JsonPropertyName("bank_type")] public string? BankType { get; set; }
    [JsonPropertyName("bank_no")] public string? BankNo { get; set; }
}
