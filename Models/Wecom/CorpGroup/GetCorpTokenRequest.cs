using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取下级/下游企业 access_token 请求</summary>
public class GetCorpTokenRequest
{
    /// <summary>下级/下游企业的 CorpId</summary>
    [JsonPropertyName("corpid")] public string CorpId { get; set; } = string.Empty;

    /// <summary>下级/下游企业的应用 AgentId</summary>
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
}

