using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>添加知识库问答响应</summary>
public class KfKnowledgeAddIntentResponse : WecomBaseResponse
{
    /// <summary>问答 id</summary>
    [JsonPropertyName("intent_id")] public string? IntentId { get; set; }
}

