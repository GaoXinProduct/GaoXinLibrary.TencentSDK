using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.NormalPay;

public class QueryOrderResponse : WecomBaseResponse
{
    [JsonPropertyName("order")]
    public OrderInfo? Order { get; set; }
}

public class OrderInfo
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}