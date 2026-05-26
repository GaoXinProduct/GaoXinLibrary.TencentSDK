
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetMomentTaskRequest
{
    [JsonPropertyName("moment_id")]
    public string MomentId { get; set; } = string.Empty;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
