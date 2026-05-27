
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class CancelMomentTaskRequest
{
    [JsonPropertyName("moment_id")]
    public string MomentId { get; set; } = string.Empty;
}
