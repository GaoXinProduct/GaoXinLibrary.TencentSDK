using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class AntiSpamRequest
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }
}