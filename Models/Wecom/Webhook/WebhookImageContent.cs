using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

public class WebhookImageContent
{
    [JsonPropertyName("base64")] public string Base64 { get; set; } = string.Empty;
    [JsonPropertyName("md5")] public string Md5 { get; set; } = string.Empty;
}

