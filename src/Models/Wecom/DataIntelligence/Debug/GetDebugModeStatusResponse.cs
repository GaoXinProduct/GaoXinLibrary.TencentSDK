using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Debug;

public class GetDebugModeStatusResponse : WecomBaseResponse
{
    [JsonPropertyName("debug_mode")]
    public int DebugMode { get; set; }
}