using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 财政电子票据基础信息
/// </summary>
public class NonTaxCardBaseInfo
{
    [JsonPropertyName("payee")] public required string Payee { get; set; }
    [JsonPropertyName("logo_url")] public required string LogoUrl { get; set; }
}
