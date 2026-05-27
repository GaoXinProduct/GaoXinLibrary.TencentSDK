using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.Refund;

public class QueryRefundRequest
{
    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }
}