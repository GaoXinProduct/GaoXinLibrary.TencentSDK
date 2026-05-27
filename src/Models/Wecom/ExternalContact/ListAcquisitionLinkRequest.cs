
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class ListAcquisitionLinkRequest
{
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}
