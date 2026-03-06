using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

// ─── 群机器人消息 ──────────────────────────────────────────────────────────

/// <summary>群机器人消息请求</summary>
public class WebhookMessageRequest
{
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;
    [JsonPropertyName("text")] public WebhookTextContent? Text { get; set; }
    [JsonPropertyName("markdown")] public WebhookMarkdownContent? Markdown { get; set; }
    [JsonPropertyName("image")] public WebhookImageContent? Image { get; set; }
    [JsonPropertyName("news")] public WebhookNewsContent? News { get; set; }
    [JsonPropertyName("file")] public WebhookFileContent? File { get; set; }
    [JsonPropertyName("template_card")] public WebhookTemplateCardContent? TemplateCard { get; set; }
}

