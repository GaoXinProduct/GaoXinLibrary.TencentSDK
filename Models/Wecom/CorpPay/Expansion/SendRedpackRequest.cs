using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class SendRedpackRequest
{
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("total_amount")]
    public int TotalAmount { get; set; }

    [JsonPropertyName("cnt")]
    public int Cnt { get; set; }

    [JsonPropertyName("receiver")]
    public string? Receiver { get; set; }

    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }

    [JsonPropertyName("redpack_type")]
    public int RedpackType { get; set; }
}