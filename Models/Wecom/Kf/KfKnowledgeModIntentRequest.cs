using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>修改知识库问答请求</summary>
public class KfKnowledgeModIntentRequest
{
    /// <summary>问答 id</summary>
    [JsonPropertyName("intent_id")] public string IntentId { get; set; } = string.Empty;

    /// <summary>主问题</summary>
    [JsonPropertyName("question")] public KfKnowledgeQuestion? Question { get; set; }

    /// <summary>相似问题列表</summary>
    [JsonPropertyName("similar_questions")] public KfKnowledgeSimilarQuestions? SimilarQuestions { get; set; }

    /// <summary>回答列表</summary>
    [JsonPropertyName("answers")] public KfKnowledgeAnswer[]? Answers { get; set; }
}

