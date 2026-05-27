using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Expansion;

public class SetLogLevelRequest
{
    [JsonPropertyName("log_level")]
    public int LogLevel { get; set; }
}