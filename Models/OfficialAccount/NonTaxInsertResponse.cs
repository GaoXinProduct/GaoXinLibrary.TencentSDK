using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 财政电子票据插卡响应
/// </summary>
public class NonTaxInsertResponse : WechatBaseResponse
{
    [JsonPropertyName("code")] public string? Code { get; set; }
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
}
