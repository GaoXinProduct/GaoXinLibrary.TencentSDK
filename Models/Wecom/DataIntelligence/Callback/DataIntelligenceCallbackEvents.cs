using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Callback;

public class CustomerConsentEvent
{
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("consent_type")]
    public int ConsentType { get; set; }

    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    [JsonPropertyName("consent_time")]
    public long ConsentTime { get; set; }
}

public class SessionCallbackEvent
{
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("chat_id")]
    public string? ChatId { get; set; }

    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }
}

public class HitKeywordRuleEvent
{
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }

    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }

    [JsonPropertyName("hit_keyword")]
    public string? HitKeyword { get; set; }
}

public class KnowledgeBaseCallbackEvent
{
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("knowledge_base_id")]
    public string? KnowledgeBaseId { get; set; }

    [JsonPropertyName("operation_type")]
    public int OperationType { get; set; }
}

public class ExportCompleteEvent
{
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("task_id")]
    public string? TaskId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("file_url")]
    public string? FileUrl { get; set; }
}