using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.Refund;

public class QueryRefundResponse : WecomBaseResponse
{
    [JsonPropertyName("refund_info")]
    public RefundInfo? RefundInfo { get; set; }
}

public class RefundInfo
{
    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("refund_amount")]
    public int RefundAmount { get; set; }
}