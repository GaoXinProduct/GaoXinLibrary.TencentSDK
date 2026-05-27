using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>模糊搜索公共邮箱响应</summary>
/// <remarks>文档路径: /document/path/98003</remarks>
public class SearchPublicMailboxResponse : WecomBaseResponse
{
    /// <summary>公共邮箱列表</summary>
    [JsonPropertyName("mailbox_list")]
    public PublicMailboxInfo[]? MailboxList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}