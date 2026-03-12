using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 将电子发票插入用户卡包响应
/// </summary>
public class InvoiceInsertResponse : WechatBaseResponse
{
    [JsonPropertyName("code")] public string? Code { get; set; }
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}
