using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class ManageKnowledgeBaseResponse : WecomBaseResponse
{
    [JsonPropertyName("knowledge_base_id")]
    public string? KnowledgeBaseId { get; set; }
}