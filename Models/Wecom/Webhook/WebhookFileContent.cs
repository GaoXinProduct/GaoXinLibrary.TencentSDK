using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public class WebhookFileContent
{
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;
}

