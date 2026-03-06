using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public class WebhookCardSource
{
    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }
    [JsonPropertyName("desc")] public string? Desc { get; set; }
    [JsonPropertyName("desc_color")] public int? DescColor { get; set; }
}

