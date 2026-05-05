using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>模糊搜索邮件群组请求</summary>
/// <remarks>文档路径: /document/path/97998</remarks>
public record SearchMailGroupRequest
{
    /// <summary>搜索关键字（邮件群组名称或邮箱地址）</summary>
    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;

    /// <summary>分页大小</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}