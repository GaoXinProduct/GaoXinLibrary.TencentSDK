using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>重命名文档请求</summary>
public class RenameDocRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>新文档名称</summary>
    [JsonPropertyName("doc_name")]
    public string DocName { get; set; } = string.Empty;
}
