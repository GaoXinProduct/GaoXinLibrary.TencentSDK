using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>创建邮件群组请求</summary>
/// <remarks>文档路径: /document/path/95510</remarks>
public record CreateMailGroupRequest
{
    /// <summary>邮件群组名称</summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>邮件群组邮箱地址（格式: xxx@xxx）</summary>
    [JsonPropertyName("group_mail")]
    public string GroupMail { get; set; } = string.Empty;

    /// <summary>邮件群组描述</summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; set; }

    /// <summary>邮件群组是否启用，1=启用，0=停用</summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>群组成员列表</summary>
    [JsonPropertyName("member_list")]
    public MailGroupMember[]? MemberList { get; set; }
}