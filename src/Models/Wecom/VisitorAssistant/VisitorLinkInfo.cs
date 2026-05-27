using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public record VisitorLinkInfo
{
    [JsonPropertyName("link_name")]
    public string? LinkName { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    [JsonPropertyName("skip_verify")]
    public bool SkipVerify { get; set; }

    [JsonPropertyName("mark_source")]
    public bool MarkSource { get; set; }
}