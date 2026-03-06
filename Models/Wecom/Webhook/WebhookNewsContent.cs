using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public class WebhookNewsContent
{
    [JsonPropertyName("articles")] public WebhookNewsArticle[] Articles { get; set; } = [];
}

