using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>知识库回答</summary>
public class KfKnowledgeAnswer
{
    /// <summary>回答内容</summary>
    [JsonPropertyName("text")] public KfKnowledgeTextContent? Text { get; set; }

    /// <summary>附件列表</summary>
    [JsonPropertyName("attachments")] public KfKnowledgeAttachment[]? Attachments { get; set; }
}

