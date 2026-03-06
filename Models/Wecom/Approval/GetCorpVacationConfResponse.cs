using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取企业假期管理配置响应</summary>
public class GetCorpVacationConfResponse : WecomBaseResponse
{
    /// <summary>假期列表</summary>
    [JsonPropertyName("lists")] public VacationConfig[]? Lists { get; set; }
}

