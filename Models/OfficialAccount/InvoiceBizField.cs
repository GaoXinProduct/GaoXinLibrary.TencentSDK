using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 授权页单位发票字段
/// </summary>
public class InvoiceBizField
{
    [JsonPropertyName("show_title")] public int? ShowTitle { get; set; }
    [JsonPropertyName("show_tax_no")] public int? ShowTaxNo { get; set; }
    [JsonPropertyName("show_addr")] public int? ShowAddr { get; set; }
    [JsonPropertyName("show_phone")] public int? ShowPhone { get; set; }
    [JsonPropertyName("show_bank_type")] public int? ShowBankType { get; set; }
    [JsonPropertyName("show_bank_no")] public int? ShowBankNo { get; set; }
    [JsonPropertyName("require_tax_no")] public int? RequireTaxNo { get; set; }
    [JsonPropertyName("require_addr")] public int? RequireAddr { get; set; }
    [JsonPropertyName("require_phone")] public int? RequirePhone { get; set; }
    [JsonPropertyName("require_bank_type")] public int? RequireBankType { get; set; }
    [JsonPropertyName("require_bank_no")] public int? RequireBankNo { get; set; }
    [JsonPropertyName("custom_field")] public List<InvoiceCustomField>? CustomField { get; set; }
}
