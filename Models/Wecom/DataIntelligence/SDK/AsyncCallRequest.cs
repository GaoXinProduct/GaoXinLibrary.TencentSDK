using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class AsyncCallRequest
{
    [JsonPropertyName("call_type")]
    public int CallType { get; set; }

    [JsonPropertyName("call_params")]
    public Dictionary<string, object>? CallParams { get; set; }

    [JsonPropertyName("callback_url")]
    public string? CallbackUrl { get; set; }
}