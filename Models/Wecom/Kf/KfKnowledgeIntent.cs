using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>知识库问答信息</summary>
public class KfKnowledgeIntent
{
    /// <summary>问答 id</summary>
    [JsonPropertyName("intent_id")] public string? IntentId { get; set; }

    /// <summary>分组 id</summary>
    [JsonPropertyName("group_id")] public string? GroupId { get; set; }

    /// <summary>主问题</summary>
    [JsonPropertyName("question")] public KfKnowledgeQuestion? Question { get; set; }

    /// <summary>相似问题列表</summary>
    [JsonPropertyName("similar_questions")] public KfKnowledgeSimilarQuestions? SimilarQuestions { get; set; }

    /// <summary>回答列表</summary>
    [JsonPropertyName("answers")] public KfKnowledgeAnswer[]? Answers { get; set; }
}

