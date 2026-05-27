using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class ReceiveFromEmployeeResponse : WecomBaseResponse
{
    [JsonPropertyName("receipt_id")]
    public string? ReceiptId { get; set; }
}