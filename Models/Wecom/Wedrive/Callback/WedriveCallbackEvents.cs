using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive.Callback;

/// <summary>微盘回调事件</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97482</remarks>
public class WedriveCallbackEvents
{
    /// <summary>事件类型</summary>
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    /// <summary>空间变更事件</summary>
    [JsonPropertyName("space_change_event")]
    public SpaceChangeEvent? SpaceChangeEvent { get; set; }

    /// <summary>文件变更事件</summary>
    [JsonPropertyName("file_change_event")]
    public FileChangeEvent? FileChangeEvent { get; set; }

    /// <summary>解散空间事件</summary>
    [JsonPropertyName("dissolve_space_event")]
    public DissolveSpaceEvent? DissolveSpaceEvent { get; set; }

    /// <summary>修改空间成员事件</summary>
    [JsonPropertyName("modify_space_member_event")]
    public ModifySpaceMemberEvent? ModifySpaceMemberEvent { get; set; }

    /// <summary>修改空间安全设置事件</summary>
    [JsonPropertyName("modify_space_security_event")]
    public ModifySpaceSecurityEvent? ModifySpaceSecurityEvent { get; set; }
}

/// <summary>空间变更事件</summary>
public class SpaceChangeEvent
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; set; }

    /// <summary>变更类型，1-创建，2-重命名，3-删除</summary>
    [JsonPropertyName("change_type")]
    public int ChangeType { get; set; }

    /// <summary>操作者 userid</summary>
    [JsonPropertyName("operator_userid")]
    public string? OperatorUserId { get; set; }

    /// <summary>新空间名称（仅重命名时返回）</summary>
    [JsonPropertyName("new_name")]
    public string? NewName { get; set; }
}

/// <summary>文件变更事件</summary>
public class FileChangeEvent
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; set; }

    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public string? FileId { get; set; }

    /// <summary>变更类型，1-创建，2-重命名，3-移动，4-删除</summary>
    [JsonPropertyName("change_type")]
    public int ChangeType { get; set; }

    /// <summary>操作者 userid</summary>
    [JsonPropertyName("operator_userid")]
    public string? OperatorUserId { get; set; }

    /// <summary>新文件名称（仅重命名时返回）</summary>
    [JsonPropertyName("new_name")]
    public string? NewName { get; set; }

    /// <summary>新父目录 ID（仅移动时返回）</summary>
    [JsonPropertyName("new_fatherid")]
    public string? NewFatherId { get; set; }
}

/// <summary>解散空间事件</summary>
public class DissolveSpaceEvent
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; set; }

    /// <summary>操作者 userid</summary>
    [JsonPropertyName("operator_userid")]
    public string? OperatorUserId { get; set; }
}

/// <summary>修改空间成员事件</summary>
public class ModifySpaceMemberEvent
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; set; }

    /// <summary>变更类型，1-新增成员，2-删除成员</summary>
    [JsonPropertyName("change_type")]
    public int ChangeType { get; set; }

    /// <summary>操作者 userid</summary>
    [JsonPropertyName("operator_userid")]
    public string? OperatorUserId { get; set; }

    /// <summary>成员 userid 列表</summary>
    [JsonPropertyName("auth_id_list")]
    public string[]? AuthIdList { get; set; }
}

/// <summary>修改空间安全设置事件</summary>
public class ModifySpaceSecurityEvent
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; set; }

    /// <summary>安全模式，0-关闭，1-企业员工可查看，2-企业内外成员均可查看</summary>
    [JsonPropertyName("security_mode")]
    public int SecurityMode { get; set; }

    /// <summary>操作者 userid</summary>
    [JsonPropertyName("operator_userid")]
    public string? OperatorUserId { get; set; }
}