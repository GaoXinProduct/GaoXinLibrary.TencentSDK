using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SpeechSkillResponse : WecomBaseResponse
{
    [JsonPropertyName("recommendations")]
    public SpeechRecommendation[]? Recommendations { get; set; }
}

public class SpeechRecommendation
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("score")]
    public double Score { get; set; }
}