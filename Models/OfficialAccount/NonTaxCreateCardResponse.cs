using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 创建财政电子票据模板响应
/// </summary>
public class NonTaxCreateCardResponse : WechatBaseResponse
{
    [JsonPropertyName("card_id")] public string? CardId { get; set; }
}
