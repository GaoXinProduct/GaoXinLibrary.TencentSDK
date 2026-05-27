using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class PayToEmployeeRequest
{
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("payment_proof")]
    public string? PaymentProof { get; set; }
}