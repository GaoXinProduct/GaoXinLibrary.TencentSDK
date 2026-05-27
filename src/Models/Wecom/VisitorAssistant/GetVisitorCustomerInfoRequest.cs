using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public record GetVisitorCustomerInfoRequest
{
    [JsonPropertyName("link_id")]
    public string LinkId { get; set; } = string.Empty;

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}