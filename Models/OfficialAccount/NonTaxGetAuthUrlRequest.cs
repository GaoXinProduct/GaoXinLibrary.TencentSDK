using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取非税票据授权页链接请求
/// </summary>
public class NonTaxGetAuthUrlRequest
{
    [JsonPropertyName("s_pappid")] public required string SPAppId { get; set; }
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    [JsonPropertyName("money")] public int Money { get; set; }
    [JsonPropertyName("timestamp")] public long Timestamp { get; set; }
    [JsonPropertyName("source")] public required string Source { get; set; }
    [JsonPropertyName("redirect_url")] public string? RedirectUrl { get; set; }
    [JsonPropertyName("ticket")] public required string Ticket { get; set; }
}
