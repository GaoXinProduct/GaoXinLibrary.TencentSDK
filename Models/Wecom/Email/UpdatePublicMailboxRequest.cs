using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>更新公共邮箱请求</summary>
/// <remarks>文档路径: /document/path/98000</remarks>
public record UpdatePublicMailboxRequest
{
    /// <summary>公共邮箱ID</summary>
    [JsonPropertyName("mailbox_id")]
    public string MailboxId { get; set; } = string.Empty;

    /// <summary>公共邮箱名称</summary>
    [JsonPropertyName("mailbox")]
    public string? Mailbox { get; set; }

    /// <summary>公共邮箱备注</summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; set; }

    /// <summary>公共邮箱是否可使用，1=可使用，0=不可使用</summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>关联的成员userid列表</summary>
    [JsonPropertyName("user_list")]
    public string[]? UserList { get; set; }
}