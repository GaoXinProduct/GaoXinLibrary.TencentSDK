using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetReceiveFromEmployeeRecordResponse : WecomBaseResponse
{
    [JsonPropertyName("record")]
    public ReceiveRecord? Record { get; set; }
}

public class ReceiveRecord
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}