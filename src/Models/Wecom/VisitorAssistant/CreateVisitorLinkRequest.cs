using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

public record CreateVisitorLinkRequest
{
    [JsonPropertyName("link_name")]
    public string LinkName { get; set; } = string.Empty;

    [JsonPropertyName("range")]
    public VisitorLinkRange? Range { get; set; }

    [JsonPropertyName("skip_verify")]
    public bool? SkipVerify { get; set; }

    [JsonPropertyName("priority_option")]
    public PriorityOption? PriorityOption { get; set; }

    [JsonPropertyName("mark_source")]
    public bool? MarkSource { get; set; }
}

public record VisitorLinkRange
{
    [JsonPropertyName("user_list")]
    public string[]? UserList { get; set; }

    [JsonPropertyName("department_list")]
    public int[]? DepartmentList { get; set; }
}

public record PriorityOption
{
    [JsonPropertyName("priority_type")]
    public int PriorityType { get; set; }

    [JsonPropertyName("priority_userid_list")]
    public string[]? PriorityUserIdList { get; set; }
}