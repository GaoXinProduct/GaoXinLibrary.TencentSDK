using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>管理智能表格内容权限请求</summary>
public class ModifyPermissionRuleRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>权限规则列表</summary>
    [JsonPropertyName("rules")]
    public PermissionRule[] Rules { get; set; } = [];
}

/// <summary>权限规则</summary>
public class PermissionRule
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>权限类型：1-可编辑，2-可查看</summary>
    [JsonPropertyName("permission")] public int Permission { get; set; }

    /// <summary>权限过期时间（Unix时间戳）</summary>
    [JsonPropertyName("expired_time")] public long ExpiredTime { get; set; }
}
