using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetRedpackRecordRequest
{
    [JsonPropertyName("redpack_id")]
    public string? RedpackId { get; set; }

    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }
}