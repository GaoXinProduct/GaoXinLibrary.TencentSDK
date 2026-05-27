using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetConsentInfoRequest
{
    [JsonPropertyName("consent_type")]
    public int ConsentType { get; set; }

    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }
}