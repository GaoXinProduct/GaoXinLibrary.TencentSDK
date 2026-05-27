using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class ManageKnowledgeBaseRequest
{
    [JsonPropertyName("operation_type")]
    public int OperationType { get; set; }

    [JsonPropertyName("knowledge_base_id")]
    public string? KnowledgeBaseId { get; set; }

    [JsonPropertyName("knowledge_base_name")]
    public string? KnowledgeBaseName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}