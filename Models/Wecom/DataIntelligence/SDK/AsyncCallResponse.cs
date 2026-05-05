using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

public class AsyncCallResponse : WecomBaseResponse
{
    [JsonPropertyName("task_id")]
    public string? TaskId { get; set; }
}