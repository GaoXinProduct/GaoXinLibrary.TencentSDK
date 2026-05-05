using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Expansion;

public class SetReceiveCallbackRequest
{
    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("aes_key")]
    public string? AesKey { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}