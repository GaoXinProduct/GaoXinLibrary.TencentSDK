using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public class AgentTagIds
{
    [JsonPropertyName("tagid")] public int[]? TagId { get; set; }
}

