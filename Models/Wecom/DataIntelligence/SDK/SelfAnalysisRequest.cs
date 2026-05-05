using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SelfAnalysisRequest
{
    [JsonPropertyName("model_type")]
    public string? ModelType { get; set; }

    [JsonPropertyName("input")]
    public Dictionary<string, object>? Input { get; set; }
}