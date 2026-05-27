using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>删除邮件群组请求</summary>
/// <remarks>文档路径: /document/path/97996</remarks>
public record DeleteMailGroupRequest
{
    /// <summary>邮件群组ID</summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;
}