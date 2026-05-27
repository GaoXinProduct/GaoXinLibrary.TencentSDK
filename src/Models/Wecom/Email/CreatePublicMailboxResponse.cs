using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>创建公共邮箱响应</summary>
/// <remarks>文档路径: /document/path/95511</remarks>
public class CreatePublicMailboxResponse : WecomBaseResponse
{
    /// <summary>公共邮箱ID</summary>
    [JsonPropertyName("mailbox_id")]
    public string? MailboxId { get; set; }
}