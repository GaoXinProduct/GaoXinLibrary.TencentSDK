using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public sealed class WebhookFileContent
{
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;
}

