using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取公共邮箱详情请求</summary>
/// <remarks>文档路径: /document/path/98002</remarks>
public record GetPublicMailboxDetailRequest
{
    /// <summary>公共邮箱ID</summary>
    [JsonPropertyName("mailbox_id")]
    public string MailboxId { get; set; } = string.Empty;
}