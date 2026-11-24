
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>创建文档请求</summary>
public sealed class CreateDocRequest
{
    /// <summary>文档名称</summary>
    [JsonPropertyName("doc_name")]
    public string DocName { get; set; } = string.Empty;

    /// <summary>文档类型，3-文档，4-表格，10-智能表格，11-智能文档</summary>
    [JsonPropertyName("doc_type")]
    public int DocType { get; set; } = 3;

    /// <summary>微盘空间 ID。指定空间时需同时填写文件夹 ID。</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; set; }

    /// <summary>父文件夹 ID。在空间根目录创建时填写空间 ID。</summary>
    [JsonPropertyName("fatherid")]
    public string? FolderId { get; set; }

    /// <summary>文档管理员的成员 ID 列表</summary>
    [JsonPropertyName("admin_users")]
    public string[]? AdminUsers { get; set; }
}
