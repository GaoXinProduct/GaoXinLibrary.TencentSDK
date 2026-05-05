using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.AppInvoke;

public class SyncInvokeRequest
{
    [JsonPropertyName("invoke_type")]
    public int InvokeType { get; set; }

    [JsonPropertyName("invoke_params")]
    public Dictionary<string, object>? InvokeParams { get; set; }
}