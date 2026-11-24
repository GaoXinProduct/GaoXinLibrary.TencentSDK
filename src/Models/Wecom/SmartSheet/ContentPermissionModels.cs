using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>查询子表权限规则。规则类型 1 为全员权限，2 为成员额外权限。</summary>
public sealed class GetContentPermissionsRequest
{
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;
    [JsonPropertyName("type")] public uint Type { get; set; }
    [JsonPropertyName("rule_id_list")] public uint[]? RuleIds { get; set; }
}

/// <summary>智能表格子表权限查询结果。</summary>
public sealed class GetContentPermissionsResponse : WecomBaseResponse
{
    [JsonPropertyName("rule_list")] public ContentPermissionRule[]? Rules { get; set; }
}

/// <summary>更新指定规则的子表权限。更新成员额外权限时需要规则 ID。</summary>
public sealed class UpdateContentPermissionsRequest
{
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;
    [JsonPropertyName("type")] public uint Type { get; set; }
    [JsonPropertyName("rule_id")] public uint? RuleId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("priv_list")] public SheetContentPermission[]? Permissions { get; set; }
}

/// <summary>新增一条成员额外权限规则。</summary>
public sealed class CreateContentPermissionRuleRequest
{
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
}

/// <summary>新增成员额外权限规则的结果。</summary>
public sealed class CreateContentPermissionRuleResponse : WecomBaseResponse
{
    [JsonPropertyName("rule_id")] public uint RuleId { get; set; }
}

/// <summary>修改成员额外权限规则的适用成员。</summary>
public sealed class UpdateContentPermissionMembersRequest
{
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;
    [JsonPropertyName("rule_id")] public uint RuleId { get; set; }
    [JsonPropertyName("add_member_range")] public ContentPermissionMemberRange? AddMembers { get; set; }
    [JsonPropertyName("del_member_range")] public ContentPermissionMemberRange? RemoveMembers { get; set; }
}

/// <summary>删除指定的成员额外权限规则。</summary>
public sealed class DeleteContentPermissionRulesRequest
{
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;
    [JsonPropertyName("rule_id_list")] public uint[] RuleIds { get; set; } = [];
}

/// <summary>全员权限或指定成员的额外权限规则。</summary>
public sealed class ContentPermissionRule
{
    [JsonPropertyName("rule_id")] public uint? RuleId { get; set; }
    [JsonPropertyName("type")] public uint Type { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("priv_list")] public SheetContentPermission[]? Permissions { get; set; }
}

/// <summary>规则对单个子表的权限配置。</summary>
public sealed class SheetContentPermission
{
    [JsonPropertyName("sheet_id")] public string SheetId { get; set; } = string.Empty;

    /// <summary>1 为全部权限，2 为可编辑，3 为仅浏览，4 为无权限。</summary>
    [JsonPropertyName("priv")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public uint Permission { get; set; }

    [JsonPropertyName("can_insert_record")] public bool? CanInsertRecord { get; set; }
    [JsonPropertyName("can_delete_record")] public bool? CanDeleteRecord { get; set; }
    [JsonPropertyName("can_create_modify_delete_view")] public bool? CanManageViews { get; set; }
    [JsonPropertyName("field_priv")] public ContentFieldPermissions? FieldPermissions { get; set; }
    [JsonPropertyName("record_priv")] public ContentRecordPermissions? RecordPermissions { get; set; }
    [JsonPropertyName("clear")] public bool? Clear { get; set; }
}

/// <summary>按字段配置子表权限。</summary>
public sealed class ContentFieldPermissions
{
    /// <summary>1 为所有字段，2 为部分字段。</summary>
    [JsonPropertyName("field_range_type")] public uint RangeType { get; set; }

    [JsonPropertyName("field_rule_list")] public ContentFieldPermission[]? Rules { get; set; }
    [JsonPropertyName("field_default_rule")] public ContentFieldPermission? DefaultRule { get; set; }
}

/// <summary>字段的查看、首次提交和编辑权限。默认规则中省略字段 ID 和类型。</summary>
public sealed class ContentFieldPermission
{
    [JsonPropertyName("field_id")] public string? FieldId { get; set; }
    [JsonPropertyName("field_type")] public string? FieldType { get; set; }
    [JsonPropertyName("can_edit")] public bool CanEdit { get; set; }
    [JsonPropertyName("can_insert")] public bool CanInsert { get; set; }
    [JsonPropertyName("can_view")] public bool CanView { get; set; }
}

/// <summary>按记录和逻辑条件配置子表权限。</summary>
public sealed class ContentRecordPermissions
{
    /// <summary>1 为全部记录，2 为满足任意条件，3 为满足全部条件。</summary>
    [JsonPropertyName("record_range_type")] public uint RangeType { get; set; }

    [JsonPropertyName("record_rule_list")] public ContentRecordCondition[]? Conditions { get; set; }

    /// <summary>不符合条件的记录权限。1 为不可编辑，2 为不可查看。</summary>
    [JsonPropertyName("other_priv")] public uint? OtherPermission { get; set; }
}

/// <summary>记录权限中用于匹配字段值的条件。</summary>
public sealed class ContentRecordCondition
{
    [JsonPropertyName("field_id")] public string FieldId { get; set; } = string.Empty;
    [JsonPropertyName("field_type")] public string? FieldType { get; set; }

    /// <summary>操作类型。1 包含自己，2 包含，3 不包含，4 等于，5 不等于，6 为空，7 非空。</summary>
    [JsonPropertyName("oper_type")] public uint OperationType { get; set; }

    [JsonPropertyName("value")] public string[]? Values { get; set; }
}

/// <summary>成员额外权限规则的成员范围。</summary>
public sealed class ContentPermissionMemberRange
{
    [JsonPropertyName("userid_list")] public string[]? UserIds { get; set; }
}
