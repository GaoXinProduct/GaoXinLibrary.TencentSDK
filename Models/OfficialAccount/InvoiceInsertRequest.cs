using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 将电子发票插入用户卡包请求
/// </summary>
public class InvoiceInsertRequest
{
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    [JsonPropertyName("card_id")] public required string CardId { get; set; }
    [JsonPropertyName("appid")] public required string AppId { get; set; }
    [JsonPropertyName("card_ext")] public required InvoiceCardExt CardExt { get; set; }
}
