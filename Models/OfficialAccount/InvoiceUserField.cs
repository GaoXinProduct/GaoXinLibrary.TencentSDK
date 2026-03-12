using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 授权页个人发票字段
/// </summary>
public class InvoiceUserField
{
    [JsonPropertyName("show_title")] public int? ShowTitle { get; set; }
    [JsonPropertyName("show_phone")] public int? ShowPhone { get; set; }
    [JsonPropertyName("show_email")] public int? ShowEmail { get; set; }
    [JsonPropertyName("require_phone")] public int? RequirePhone { get; set; }
    [JsonPropertyName("require_email")] public int? RequireEmail { get; set; }
    [JsonPropertyName("custom_field")] public List<InvoiceCustomField>? CustomField { get; set; }
}
