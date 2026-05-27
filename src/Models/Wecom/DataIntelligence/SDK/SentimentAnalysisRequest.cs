using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SentimentAnalysisRequest
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}