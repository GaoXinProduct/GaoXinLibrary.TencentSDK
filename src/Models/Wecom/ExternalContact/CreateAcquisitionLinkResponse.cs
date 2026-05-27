using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class CreateAcquisitionLinkResponse : WecomBaseResponse
{
    [JsonPropertyName("link")]
    public CustomerAcquisitionLinkBrief? Link { get; set; }
}

public sealed class CustomerAcquisitionLinkBrief
{
    [JsonPropertyName("link_id")]
    public string? LinkId { get; set; }

    [JsonPropertyName("link_name")]
    public string? LinkName { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }
}
