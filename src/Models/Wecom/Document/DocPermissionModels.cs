namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>文档加入规则</summary>
public class DocAccessRule
{
    /// <summary>是否允许企业内成员访问</summary>
    [JsonPropertyName("enable_corp_internal")] public bool? EnableCorpInternal { get; set; }

    /// <summary>企业内成员通过加入规则获得的权限</summary>
    [JsonPropertyName("corp_internal_auth")] public int? CorpInternalAuth { get; set; }

    /// <summary>是否允许企业外成员访问</summary>
    [JsonPropertyName("enable_corp_external")] public bool? EnableCorpExternal { get; set; }

    /// <summary>企业外成员通过加入规则获得的权限</summary>
    [JsonPropertyName("corp_external_auth")] public int? CorpExternalAuth { get; set; }

    /// <summary>企业内成员加入是否需要管理员审批</summary>
    [JsonPropertyName("corp_internal_approve_only_by_admin")] public bool? CorpInternalApproveOnlyByAdmin { get; set; }

    /// <summary>企业外成员加入是否需要管理员审批</summary>
    [JsonPropertyName("corp_external_approve_only_by_admin")] public bool? CorpExternalApproveOnlyByAdmin { get; set; }

    /// <summary>是否禁止对外分享</summary>
    [JsonPropertyName("ban_share_external")] public bool? BanShareExternal { get; set; }
}

/// <summary>部门的文档访问权限</summary>
public sealed class DocDepartmentPermission
{
    /// <summary>部门 ID</summary>
    [JsonPropertyName("departmentid")] public ulong DepartmentId { get; set; }

    /// <summary>权限，1-只读，2-读写</summary>
    [JsonPropertyName("auth")] public int Auth { get; set; } = 1;

    /// <summary>成员类型，2 表示部门</summary>
    [JsonPropertyName("type")] public int Type { get; set; } = 2;
}

/// <summary>文档成员标识</summary>
public class DocMemberReference
{
    /// <summary>成员类型，1 表示用户</summary>
    [JsonPropertyName("type")] public int Type { get; set; } = 1;

    /// <summary>企业内成员 ID</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>通过该文档查询到的外部成员临时 ID</summary>
    [JsonPropertyName("tmp_external_userid")] public string? TmpExternalUserId { get; set; }
}

/// <summary>文档成员及其权限</summary>
public sealed class DocMemberPermission : DocMemberReference
{
    /// <summary>该成员的文档权限，1-只读，2-读写，7-管理员</summary>
    [JsonPropertyName("auth")] public int Auth { get; set; }
}

/// <summary>文档安全设置</summary>
public sealed class DocSecuritySettings
{
    /// <summary>是否允许只读成员复制或导出文档</summary>
    [JsonPropertyName("enable_readonly_copy")] public bool? EnableReadonlyCopy { get; set; }

    /// <summary>是否允许只读成员评论</summary>
    [JsonPropertyName("enable_readonly_comment")] public bool? EnableReadonlyComment { get; set; }

    /// <summary>文档水印</summary>
    [JsonPropertyName("watermark")] public DocWatermark? Watermark { get; set; }
}

/// <summary>文档水印设置</summary>
public sealed class DocWatermark
{
    /// <summary>水印密度，1-稀疏，2-紧密</summary>
    [JsonPropertyName("margin_type")] public int? MarginType { get; set; }

    /// <summary>是否显示访问者名称</summary>
    [JsonPropertyName("show_visitor_name")] public bool? ShowVisitorName { get; set; }

    /// <summary>是否显示自定义文本</summary>
    [JsonPropertyName("show_text")] public bool? ShowText { get; set; }

    /// <summary>自定义水印文本</summary>
    [JsonPropertyName("text")] public string? Text { get; set; }
}
