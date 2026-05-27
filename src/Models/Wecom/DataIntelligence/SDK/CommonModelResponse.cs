using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class CommonModelResponse : WecomBaseResponse
{
    [JsonPropertyName("output")]
    public Dictionary<string, object>? Output { get; set; }
}