using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取应用共享信息请求</summary>
public class GetAppShareInfoRequest
{
    /// <summary>上级/上游企业应用的 AgentId，必填</summary>
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
}

