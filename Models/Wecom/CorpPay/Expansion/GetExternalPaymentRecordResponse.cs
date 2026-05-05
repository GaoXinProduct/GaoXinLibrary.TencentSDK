using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetExternalPaymentRecordResponse : WecomBaseResponse
{
    [JsonPropertyName("record_list")]
    public ExternalPaymentRecord[]? RecordList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public class ExternalPaymentRecord
{
    [JsonPropertyName("record_id")]
    public string? RecordId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}