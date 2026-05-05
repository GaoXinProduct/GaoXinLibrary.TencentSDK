using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>编辑文档内容请求</summary>
public class EditDocContentRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>要写入的内容（Base64编码）</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>起始偏移位置</summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>是否追加到末尾</summary>
    [JsonPropertyName("is_append")]
    public bool IsAppend { get; set; }
}
