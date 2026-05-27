using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public sealed class WebhookTextContent
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
    [JsonPropertyName("mentioned_list")] public string[]? MentionedList { get; set; }
    [JsonPropertyName("mentioned_mobile_list")] public string[]? MentionedMobileList { get; set; }
}

