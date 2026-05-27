using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>创建公共邮箱请求</summary>
/// <remarks>文档路径: /document/path/95511</remarks>
public record CreatePublicMailboxRequest
{
    /// <summary>公共邮箱名称</summary>
    [JsonPropertyName("mailbox")]
    public string Mailbox { get; set; } = string.Empty;

    /// <summary>公共邮箱地址</summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

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