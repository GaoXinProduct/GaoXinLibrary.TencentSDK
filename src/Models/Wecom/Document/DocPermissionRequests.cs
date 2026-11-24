namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>修改文档加入规则。规则值为空时保留原值。</summary>
public sealed class ModifyDocJoinRuleRequest : DocAccessRule
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>是否更新有访问权限的部门列表</summary>
    [JsonPropertyName("update_co_auth_list")] public bool? UpdateCoAuthList { get; set; }

    /// <summary>替换后的部门列表。传入空数组可清除列表。</summary>
    [JsonPropertyName("co_auth_list")] public DocDepartmentPermission[]? CoAuthList { get; set; }
}

/// <summary>新增、更新或移除文档成员</summary>
public sealed class ModifyDocMembersRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>要新增或更新的成员及权限</summary>
    [JsonPropertyName("update_file_member_list")] public DocMemberPermission[]? UpdateFileMemberList { get; set; }

    /// <summary>要移除的成员</summary>
    [JsonPropertyName("del_file_member_list")] public DocMemberReference[]? DeleteFileMemberList { get; set; }
}

/// <summary>修改文档安全设置。设置值为空时保留原值。</summary>
public sealed class ModifyDocSecuritySettingsRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>是否允许只读成员复制或导出文档</summary>
    [JsonPropertyName("enable_readonly_copy")] public bool? EnableReadonlyCopy { get; set; }

    /// <summary>文档水印</summary>
    [JsonPropertyName("watermark")] public DocWatermark? Watermark { get; set; }
}
