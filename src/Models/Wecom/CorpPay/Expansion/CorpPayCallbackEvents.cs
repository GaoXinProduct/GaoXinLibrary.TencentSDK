using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.Callback;

public class PaymentNotifyEvent
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("paid_time")]
    public long PaidTime { get; set; }
}

public class RefundNotifyEvent
{
    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("refund_time")]
    public long RefundTime { get; set; }
}

public class BillingNotifyEvent
{
    [JsonPropertyName("bill_id")]
    public string? BillId { get; set; }

    [JsonPropertyName("bill_type")]
    public string? BillType { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}