using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>获取文档数据响应</summary>
public class GetDocDataResponse : WecomBaseResponse
{
    /// <summary>文档内容（Base64编码）</summary>
    [JsonPropertyName("content")] public string? Content { get; set; }

    /// <summary>文档总长度</summary>
    [JsonPropertyName("doc_size")] public int DocSize { get; set; }
}
