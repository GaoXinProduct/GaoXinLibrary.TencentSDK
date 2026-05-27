using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetExternalPaymentRecordRequest
{
    [JsonPropertyName("begin_time")]
    public long BeginTime { get; set; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}