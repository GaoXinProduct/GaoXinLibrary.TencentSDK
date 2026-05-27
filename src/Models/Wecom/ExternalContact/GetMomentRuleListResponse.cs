using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>朋友圈规则组响应</summary>
public sealed class GetMomentRuleListResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("rule_list")] public MomentRule[]? RuleList { get; set; }
}

public sealed class MomentRule
{
    [JsonPropertyName("rule_id")] public int RuleId { get; set; }
    [JsonPropertyName("rule_name")] public string RuleName { get; set; } = string.Empty;
    [JsonPropertyName("rule_type")] public int RuleType { get; set; }
    [JsonPropertyName("user_list")] public string[]? UserList { get; set; }
    [JsonPropertyName("department_list")] public int[]? DepartmentList { get; set; }
    [JsonPropertyName("tag_list")] public int[]? TagList { get; set; }
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }
}
