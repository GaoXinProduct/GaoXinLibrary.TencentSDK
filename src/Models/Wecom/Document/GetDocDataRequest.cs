using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>获取文档数据请求</summary>
public class GetDocDataRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>起始偏移</summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>读取长度</summary>
    [JsonPropertyName("length")]
    public int Length { get; set; }
}
