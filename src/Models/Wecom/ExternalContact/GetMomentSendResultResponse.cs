using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetMomentSendResultResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("customer_list")]
    public MomentSendResultItem[]? CustomerList { get; set; }
}

public sealed class MomentSendResultItem
{
    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; set; }
}
