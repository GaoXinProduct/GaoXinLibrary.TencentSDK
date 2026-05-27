using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>编辑文档内容响应</summary>
public class EditDocContentResponse : WecomBaseResponse
{
    /// <summary>文档当前长度</summary>
    [JsonPropertyName("doc_size")] public int DocSize { get; set; }
}
