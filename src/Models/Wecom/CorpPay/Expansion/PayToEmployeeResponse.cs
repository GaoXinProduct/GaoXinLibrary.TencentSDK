using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class PayToEmployeeResponse : WecomBaseResponse
{
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }
}