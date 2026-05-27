using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.Refund;

public class ApplyRefundResponse : WecomBaseResponse
{
    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }
}