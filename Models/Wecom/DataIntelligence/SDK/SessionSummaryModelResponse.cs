using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SessionSummaryModelResponse : WecomBaseResponse
{
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
}