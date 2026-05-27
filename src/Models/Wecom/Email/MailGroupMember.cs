using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>邮件群组成员</summary>
public record MailGroupMember
{
    /// <summary>成员类型，1=成员，2=部门</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>成员userid或部门id</summary>
    [JsonPropertyName("member_id")]
    public string MemberId { get; set; } = string.Empty;

    /// <summary>是否群主，1=是，0=否</summary>
    [JsonPropertyName("is_leader")]
    public int? IsLeader { get; set; }
}