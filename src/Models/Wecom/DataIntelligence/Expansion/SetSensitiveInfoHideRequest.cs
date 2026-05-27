using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Expansion;

public class SetSensitiveInfoHideRequest
{
    [JsonPropertyName("hide")]
    public bool Hide { get; set; }
}