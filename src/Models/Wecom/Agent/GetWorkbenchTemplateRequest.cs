using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public sealed class GetWorkbenchTemplateRequest
{
    [JsonPropertyName("agentid")] public int? AgentId { get; set; }
}
