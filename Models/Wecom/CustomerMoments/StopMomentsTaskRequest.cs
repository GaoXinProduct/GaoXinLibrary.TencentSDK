using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

public class StopMomentsTaskRequest
{
    [JsonPropertyName("moment_id")]
    public string MomentId { get; set; } = string.Empty;
}