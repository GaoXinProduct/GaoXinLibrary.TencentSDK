using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public sealed class WebhookNewsContent
{
    [JsonPropertyName("articles")] public WebhookNewsArticle[] Articles { get; set; } = [];
}

