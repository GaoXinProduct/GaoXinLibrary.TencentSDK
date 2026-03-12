using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 录入抬头到用户微信请求
/// </summary>
public class InvoiceGetUserTitleUrlRequest
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("phone")] public string? Phone { get; set; }
    [JsonPropertyName("tax_no")] public string? TaxNo { get; set; }
    [JsonPropertyName("addr")] public string? Addr { get; set; }
    [JsonPropertyName("bank_type")] public string? BankType { get; set; }
    [JsonPropertyName("bank_no")] public string? BankNo { get; set; }
    [JsonPropertyName("user_fill")] public int? UserFill { get; set; }
    [JsonPropertyName("out_title_id")] public string? OutTitleId { get; set; }
}
