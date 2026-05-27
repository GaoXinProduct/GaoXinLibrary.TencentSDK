using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class SearchStaffOrCustomerResponse : WecomBaseResponse
{
    [JsonPropertyName("staff_list")]
    public StaffInfo[]? StaffList { get; set; }

    [JsonPropertyName("customer_list")]
    public CustomerInfo[]? CustomerList { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

public class StaffInfo
{
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class CustomerInfo
{
    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}