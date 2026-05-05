using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SpeechSkillRequest
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("staff_userid")]
    public string? StaffUserId { get; set; }

    [JsonPropertyName("customer_userid")]
    public string? CustomerUserId { get; set; }
}