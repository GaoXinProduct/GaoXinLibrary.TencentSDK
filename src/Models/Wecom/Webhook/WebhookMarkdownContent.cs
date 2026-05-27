using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public sealed class WebhookMarkdownContent
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

