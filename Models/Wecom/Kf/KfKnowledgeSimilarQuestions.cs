using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>相似问题列表</summary>
public class KfKnowledgeSimilarQuestions
{
    /// <summary>相似问题列表</summary>
    [JsonPropertyName("items")] public KfKnowledgeQuestion[]? Items { get; set; }
}

