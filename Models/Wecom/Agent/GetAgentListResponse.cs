using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

/// <summary>获取应用列表响应</summary>
public class GetAgentListResponse : WecomBaseResponse
{
    /// <summary>应用列表</summary>
    [JsonPropertyName("agentlist")] public AgentInfo[]? AgentList { get; set; }
}

