using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票卡券模板基础信息
/// </summary>
public class InvoicePlatformCardBaseInfo
{
    [JsonPropertyName("payee")] public required string Payee { get; set; }
    [JsonPropertyName("logo_url")] public required string LogoUrl { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("custom_url_name")] public string? CustomUrlName { get; set; }
    [JsonPropertyName("custom_url")] public string? CustomUrl { get; set; }
    [JsonPropertyName("custom_url_sub_title")] public string? CustomUrlSubTitle { get; set; }
    [JsonPropertyName("promotion_url_name")] public string? PromotionUrlName { get; set; }
    [JsonPropertyName("promotion_url")] public string? PromotionUrl { get; set; }
    [JsonPropertyName("promotion_url_sub_title")] public string? PromotionUrlSubTitle { get; set; }
}
