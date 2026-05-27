using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Debug;

public class SetDebugModeRequest
{
    [JsonPropertyName("debug_mode")]
    public int DebugMode { get; set; }
}