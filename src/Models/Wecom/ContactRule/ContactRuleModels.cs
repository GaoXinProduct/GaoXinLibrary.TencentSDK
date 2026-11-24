using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ContactRule;

/// <summary>通讯录查看权限的限制类型。</summary>
public enum ContactRuleType
{
    HideDepartmentsOrMembers = 1,
    RestrictOtherDepartments = 2,
    RestrictEveryone = 3
}

/// <summary>通讯录规则涉及的成员、部门和标签。</summary>
public sealed record ContactRuleRange
{
    [JsonPropertyName("userid")] public string[]? UserIds { get; init; }
    [JsonPropertyName("partyid")] public int[]? DepartmentIds { get; init; }
    [JsonPropertyName("tagid")] public int[]? TagIds { get; init; }
}

/// <summary>通讯录查看权限规则。</summary>
public sealed record ContactVisibilityRule
{
    /// <summary>规则 ID，更新规则时必填。</summary>
    [JsonPropertyName("rule_id")] public int? RuleId { get; init; }

    /// <summary>规则类型。修改现有规则时需沿用原类型。</summary>
    [JsonPropertyName("rule_type")] public required ContactRuleType RuleType { get; init; }

    /// <summary>规则作用范围。</summary>
    [JsonPropertyName("range")] public required ContactRuleRange Range { get; init; }

    /// <summary>规则白名单。</summary>
    [JsonPropertyName("whitelist")] public ContactRuleRange? Whitelist { get; init; }

    /// <summary>从规则作用范围排除的成员、部门和标签。</summary>
    [JsonPropertyName("exclude")] public ContactRuleRange? Exclude { get; init; }

    [JsonPropertyName("is_allowed_search")] public bool? IsAllowedSearch { get; init; }
    [JsonPropertyName("is_allowed_conversation")] public bool? IsAllowedConversation { get; init; }
}

/// <summary>创建通讯录规则的结果。</summary>
public sealed class CreateContactRulesResponse : WecomBaseResponse
{
    [JsonPropertyName("rule_ids")] public int[]? RuleIds { get; init; }
}

/// <summary>读取或修改后返回的通讯录规则列表。</summary>
public sealed class ContactRulesResponse : WecomBaseResponse
{
    [JsonPropertyName("rules")] public ContactVisibilityRule[]? Rules { get; init; }
}
