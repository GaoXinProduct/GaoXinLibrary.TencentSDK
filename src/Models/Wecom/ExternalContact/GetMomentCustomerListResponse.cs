using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetMomentCustomerListResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("customer_list")]
    public MomentCustomerItem[]? CustomerList { get; set; }
}

public sealed class MomentCustomerItem
{
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; set; }
}
