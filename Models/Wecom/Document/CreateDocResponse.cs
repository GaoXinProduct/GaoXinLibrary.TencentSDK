using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>新建文档响应</summary>
public class CreateDocResponse : WecomBaseResponse
{
    /// <summary>文档的url</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>文档docid</summary>
    [JsonPropertyName("docid")] public string? DocId { get; set; }
}
