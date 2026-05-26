using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class ListAcquisitionLinkResponse : WecomBaseResponse
{
    [JsonPropertyName("link_id_list")]
    public string[]? LinkIdList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}
