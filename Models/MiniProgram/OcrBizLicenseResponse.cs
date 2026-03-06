using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>营业执照 OCR 响应（POST /cv/ocr/bizlicense）</summary>
public class OcrBizLicenseResponse : WechatBaseResponse
{
    /// <summary>注册号</summary>
    [JsonPropertyName("reg_num")] public string? RegNum { get; set; }
    /// <summary>编号</summary>
    [JsonPropertyName("serial")] public string? Serial { get; set; }
    /// <summary>法定代表人</summary>
    [JsonPropertyName("legal_representative")] public string? LegalRepresentative { get; set; }
    /// <summary>企业名称</summary>
    [JsonPropertyName("enterprise_name")] public string? EnterpriseName { get; set; }
    /// <summary>组成形式</summary>
    [JsonPropertyName("type_of_organization")] public string? TypeOfOrganization { get; set; }
    /// <summary>经营场所/住所</summary>
    [JsonPropertyName("address")] public string? Address { get; set; }
    /// <summary>注册资本</summary>
    [JsonPropertyName("registered_capital")] public string? RegisteredCapital { get; set; }
    /// <summary>营业期限</summary>
    [JsonPropertyName("valid_period")] public string? ValidPeriod { get; set; }
    /// <summary>经营范围</summary>
    [JsonPropertyName("type_of_enterprise")] public string? TypeOfEnterprise { get; set; }
}

