using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetRedpackRecordResponse : WecomBaseResponse
{
    [JsonPropertyName("redpack_record")]
    public RedpackRecord? RedpackRecord { get; set; }
}

public class RedpackRecord
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("total_amount")]
    public int TotalAmount { get; set; }
}