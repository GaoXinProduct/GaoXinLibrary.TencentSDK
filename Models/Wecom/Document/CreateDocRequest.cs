using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>创建文档请求</summary>
public class CreateDocRequest
{
    /// <summary>文档名称</summary>
    [JsonPropertyName("doc_name")]
    public string DocName { get; set; } = string.Empty;

    /// <summary>文档类型，1-文档，3-表格</summary>
    [JsonPropertyName("doc_type")]
    public int DocType { get; set; } = 1;

    /// <summary>文件夹 ID</summary>
    [JsonPropertyName("folderId")]
    public string? FolderId { get; set; }
}
