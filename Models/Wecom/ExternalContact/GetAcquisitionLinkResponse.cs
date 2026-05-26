using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetAcquisitionLinkResponse : WecomBaseResponse
{
    [JsonPropertyName("link")]
    public CustomerAcquisitionLinkDetail? Link { get; set; }

    [JsonPropertyName("range")]
    public CustomerAcquisitionRange? Range { get; set; }

    [JsonPropertyName("priority_option")]
    public CustomerAcquisitionPriorityOption? PriorityOption { get; set; }
}

public sealed class CustomerAcquisitionLinkDetail
{
    [JsonPropertyName("link_id")]
    public string? LinkId { get; set; }

    [JsonPropertyName("link_name")]
    public string? LinkName { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    [JsonPropertyName("skip_verify")]
    public bool SkipVerify { get; set; }

    [JsonPropertyName("mark_source")]
    public bool MarkSource { get; set; }
}
