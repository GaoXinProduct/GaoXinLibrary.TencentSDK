using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetReceiveFromEmployeeRecordRequest
{
    [JsonPropertyName("receipt_id")]
    public string? ReceiptId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }
}