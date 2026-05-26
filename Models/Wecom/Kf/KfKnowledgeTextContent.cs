using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>知识库文本内容</summary>
public sealed class KfKnowledgeTextContent
{
    /// <summary>文本内容</summary>
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
}

