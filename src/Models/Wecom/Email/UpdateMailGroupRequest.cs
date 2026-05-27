using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>更新邮件群组请求</summary>
/// <remarks>文档路径: /document/path/97995</remarks>
public record UpdateMailGroupRequest
{
    /// <summary>邮件群组ID</summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;

    /// <summary>邮件群组名称</summary>
    [JsonPropertyName("group_name")]
    public string? GroupName { get; set; }

    /// <summary>邮件群组描述</summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; set; }

    /// <summary>邮件群组是否启用，1=启用，0=停用</summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }
}