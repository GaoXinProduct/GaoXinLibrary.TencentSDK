using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public class WebhookMarkdownContent
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

