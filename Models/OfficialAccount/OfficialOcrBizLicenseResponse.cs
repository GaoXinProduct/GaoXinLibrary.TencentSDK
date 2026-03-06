using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>OCR — 营业执照识别响应</summary>
public class OfficialOcrBizLicenseResponse : WechatBaseResponse
{
    [JsonPropertyName("reg_num")] public string? RegNum { get; set; }
    [JsonPropertyName("serial")] public string? Serial { get; set; }
    [JsonPropertyName("legal_representative")] public string? LegalRepresentative { get; set; }
    [JsonPropertyName("enterprise_name")] public string? EnterpriseName { get; set; }
    [JsonPropertyName("type_of_organization")] public string? TypeOfOrganization { get; set; }
    [JsonPropertyName("address")] public string? Address { get; set; }
    [JsonPropertyName("type_of_enterprise")] public string? TypeOfEnterprise { get; set; }
    [JsonPropertyName("business_scope")] public string? BusinessScope { get; set; }
    [JsonPropertyName("registered_capital")] public string? RegisteredCapital { get; set; }
    [JsonPropertyName("paid_in_capital")] public string? PaidInCapital { get; set; }
    [JsonPropertyName("valid_period")] public string? ValidPeriod { get; set; }
    [JsonPropertyName("registered_date")] public string? RegisteredDate { get; set; }
}

