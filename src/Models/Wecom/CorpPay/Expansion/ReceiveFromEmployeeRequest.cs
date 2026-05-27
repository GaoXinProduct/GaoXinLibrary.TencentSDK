using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class ReceiveFromEmployeeRequest
{
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }
}