using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public class AgentPartyIds
{
    [JsonPropertyName("partyid")] public int[]? PartyId { get; set; }
}

