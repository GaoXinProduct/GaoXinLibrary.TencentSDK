using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public record UpdateVisitorLinkRequest
{
    [JsonPropertyName("link_id")]
    public string LinkId { get; set; } = string.Empty;

    [JsonPropertyName("link_name")]
    public string? LinkName { get; set; }

    [JsonPropertyName("range")]
    public VisitorLinkRange? Range { get; set; }

    [JsonPropertyName("skip_verify")]
    public bool? SkipVerify { get; set; }

    [JsonPropertyName("priority_option")]
    public PriorityOption? PriorityOption { get; set; }

    [JsonPropertyName("mark_source")]
    public bool? MarkSource { get; set; }
}