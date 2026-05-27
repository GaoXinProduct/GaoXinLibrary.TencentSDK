using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class GetConsentInfoResponse : WecomBaseResponse
{
    [JsonPropertyName("consent_info")]
    public ConsentInfo? ConsentInfo { get; set; }
}

public class ConsentInfo
{
    [JsonPropertyName("consent_type")]
    public int ConsentType { get; set; }

    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("consent_time")]
    public long ConsentTime { get; set; }
}