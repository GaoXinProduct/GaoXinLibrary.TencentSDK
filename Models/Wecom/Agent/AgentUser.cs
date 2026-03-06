using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public class AgentUser
{
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
}

