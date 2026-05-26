using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetAcquisitionCustomerResponse : WecomBaseResponse
{
    [JsonPropertyName("customer_list")]
    public AcquisitionCustomerItem[]? CustomerList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public sealed class AcquisitionCustomerItem
{
    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; set; }
}
