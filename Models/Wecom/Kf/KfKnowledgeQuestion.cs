using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>知识库主问题</summary>
public class KfKnowledgeQuestion
{
    /// <summary>问题内容</summary>
    [JsonPropertyName("text")] public KfKnowledgeTextContent Text { get; set; } = new();
}

