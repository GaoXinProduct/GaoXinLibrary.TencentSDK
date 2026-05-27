using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public record GetVisitorLinkRequest
{
    [JsonPropertyName("link_id")]
    public string LinkId { get; set; } = string.Empty;
}