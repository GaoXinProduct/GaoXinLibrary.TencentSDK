using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 财政电子票据插卡请求
/// </summary>
public class NonTaxInsertRequest
{
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    [JsonPropertyName("card_id")] public required string CardId { get; set; }
    [JsonPropertyName("appid")] public required string AppId { get; set; }
    [JsonPropertyName("card_ext")] public required InvoiceCardExt CardExt { get; set; }
}
