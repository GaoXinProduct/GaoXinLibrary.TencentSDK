using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.NormalPay;

public class GetPaySignatureRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("pay_type")]
    public int PayType { get; set; }
}