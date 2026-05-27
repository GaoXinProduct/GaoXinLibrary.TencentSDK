using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>邮件群组信息</summary>
public record MailGroupInfo
{
    /// <summary>邮件群组ID</summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;

    /// <summary>邮件群组名称</summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    /// <summary>邮件群组邮箱地址</summary>
    [JsonPropertyName("group_mail")]
    public string GroupMail { get; set; } = string.Empty;

    /// <summary>邮件群组描述</summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; set; }

    /// <summary>邮件群组是否启用，1=启用，0=停用</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>群组成员列表</summary>
    [JsonPropertyName("member_list")]
    public MailGroupMember[]? MemberList { get; set; }
}