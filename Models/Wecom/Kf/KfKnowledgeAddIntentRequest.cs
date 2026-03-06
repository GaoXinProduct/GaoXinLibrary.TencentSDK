using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>添加知识库问答请求</summary>
public class KfKnowledgeAddIntentRequest
{
    /// <summary>分组 id</summary>
    [JsonPropertyName("group_id")] public string GroupId { get; set; } = string.Empty;

    /// <summary>主问题</summary>
    [JsonPropertyName("question")] public KfKnowledgeQuestion Question { get; set; } = new();

    /// <summary>相似问题列表</summary>
    [JsonPropertyName("similar_questions")] public KfKnowledgeSimilarQuestions? SimilarQuestions { get; set; }

    /// <summary>回答列表</summary>
    [JsonPropertyName("answers")] public KfKnowledgeAnswer[]? Answers { get; set; }
}

