
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetMomentCustomerListRequest
{
    [JsonPropertyName("moment_id")]
    public string MomentId { get; set; } = string.Empty;

    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
