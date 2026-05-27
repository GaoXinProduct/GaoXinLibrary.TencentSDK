using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetPayToEmployeeRecordResponse : WecomBaseResponse
{
    [JsonPropertyName("record")]
    public PayRecord? Record { get; set; }
}

public class PayRecord
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}