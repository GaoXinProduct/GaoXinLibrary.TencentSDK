using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>模糊搜索邮件群组响应</summary>
/// <remarks>文档路径: /document/path/97998</remarks>
public class SearchMailGroupResponse : WecomBaseResponse
{
    /// <summary>邮件群组列表</summary>
    [JsonPropertyName("group_list")]
    public MailGroupInfo[]? GroupList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}