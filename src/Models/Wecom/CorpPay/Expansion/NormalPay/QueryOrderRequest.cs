using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.NormalPay;

public class QueryOrderRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }
}