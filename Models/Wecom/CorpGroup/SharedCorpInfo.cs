using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

/// <summary>共享的下级/下游企业信息</summary>
public class SharedCorpInfo
{
    /// <summary>下级/下游企业的 CorpId</summary>
    [JsonPropertyName("corpid")] public string CorpId { get; set; } = string.Empty;

    /// <summary>该下级/下游企业的应用 AgentId</summary>
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
}

