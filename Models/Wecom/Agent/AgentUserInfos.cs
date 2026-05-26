using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public sealed class AgentUserInfos
{
    [JsonPropertyName("user")] public AgentUser[]? User { get; set; }
}

