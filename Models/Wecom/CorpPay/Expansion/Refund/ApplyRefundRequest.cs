using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.Refund;

public class ApplyRefundRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }

    [JsonPropertyName("refund_amount")]
    public int RefundAmount { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}