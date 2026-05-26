using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetMomentListResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("moment_list")]
    public MomentItem[]? MomentList { get; set; }
}
