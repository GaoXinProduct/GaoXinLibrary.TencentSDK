using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public class WebhookTemplateCardContent
{
    [JsonPropertyName("card_type")] public string CardType { get; set; } = string.Empty;
    [JsonPropertyName("source")] public WebhookCardSource? Source { get; set; }
    [JsonPropertyName("main_title")] public WebhookCardTitle? MainTitle { get; set; }
    [JsonPropertyName("card_action")] public WebhookCardAction? CardAction { get; set; }
}

