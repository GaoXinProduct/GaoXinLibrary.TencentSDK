using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>删除公共邮箱请求</summary>
/// <remarks>文档路径: /document/path/98001</remarks>
public record DeletePublicMailboxRequest
{
    /// <summary>公共邮箱ID</summary>
    [JsonPropertyName("mailbox_id")]
    public string MailboxId { get; set; } = string.Empty;
}