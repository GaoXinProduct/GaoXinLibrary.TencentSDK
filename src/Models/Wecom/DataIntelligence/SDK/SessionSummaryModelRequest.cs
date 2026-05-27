using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SessionSummaryModelRequest
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }
}