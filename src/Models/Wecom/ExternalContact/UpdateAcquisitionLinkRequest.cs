
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class UpdateAcquisitionLinkRequest
{
    [JsonPropertyName("link_id")]
    public string LinkId { get; set; } = string.Empty;

    [JsonPropertyName("link_name")]
    public string? LinkName { get; set; }

    [JsonPropertyName("range")]
    public CustomerAcquisitionRange? Range { get; set; }

    [JsonPropertyName("skip_verify")]
    public bool? SkipVerify { get; set; }

    [JsonPropertyName("priority_option")]
    public CustomerAcquisitionPriorityOption? PriorityOption { get; set; }

    [JsonPropertyName("mark_source")]
    public bool? MarkSource { get; set; }
}
