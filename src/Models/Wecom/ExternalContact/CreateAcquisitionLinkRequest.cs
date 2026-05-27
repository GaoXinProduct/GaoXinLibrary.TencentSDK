
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class CreateAcquisitionLinkRequest
{
    [JsonPropertyName("link_name")]
    public string LinkName { get; set; } = string.Empty;

    [JsonPropertyName("range")]
    public CustomerAcquisitionRange? Range { get; set; }

    [JsonPropertyName("skip_verify")]
    public bool? SkipVerify { get; set; }

    [JsonPropertyName("priority_option")]
    public CustomerAcquisitionPriorityOption? PriorityOption { get; set; }

    [JsonPropertyName("mark_source")]
    public bool? MarkSource { get; set; }
}

public sealed class CustomerAcquisitionRange
{
    [JsonPropertyName("user_list")]
    public string[]? UserList { get; set; }

    [JsonPropertyName("department_list")]
    public int[]? DepartmentList { get; set; }
}

public sealed class CustomerAcquisitionPriorityOption
{
    [JsonPropertyName("priority_type")]
    public int PriorityType { get; set; }

    [JsonPropertyName("priority_userid_list")]
    public string[]? PriorityUserIdList { get; set; }
}
