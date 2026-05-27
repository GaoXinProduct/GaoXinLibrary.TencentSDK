using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>删除知识库问答请求</summary>
public sealed class KfKnowledgeDelIntentRequest
{
    /// <summary>问答 id</summary>
    [JsonPropertyName("intent_id")] public string IntentId { get; set; } = string.Empty;
}

