using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Expansion;

public class SetPublicKeyRequest
{
    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; } = string.Empty;
}