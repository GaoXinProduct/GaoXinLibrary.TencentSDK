
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetAcquisitionCustomerRequest
{
    [JsonPropertyName("link_id")]
    public string LinkId { get; set; } = string.Empty;

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}
