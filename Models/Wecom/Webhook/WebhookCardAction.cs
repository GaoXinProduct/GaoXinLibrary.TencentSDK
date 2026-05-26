using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public sealed class WebhookCardAction
{
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("appid")] public string? AppId { get; set; }
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}

