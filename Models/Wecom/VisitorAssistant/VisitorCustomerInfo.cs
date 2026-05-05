using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public record VisitorCustomerInfo
{
    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("chat_status")]
    public int ChatStatus { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}