using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public class AgentUserInfos
{
    [JsonPropertyName("user")] public AgentUser[]? User { get; set; }
}

