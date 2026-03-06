using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取应用的可见范围响应</summary>
public class GetPermListResponse : WecomBaseResponse
{
    /// <summary>可见的 userids，是由 CorpId 和 able UserId 用 '/' 拼接而成</summary>
    [JsonPropertyName("userids")] public string[]? UserIds { get; set; }

    /// <summary>可见的 department_ids，是由 CorpId 和 able DepartmentId 用 '/' 拼接而成</summary>
    [JsonPropertyName("department_ids")] public string[]? DepartmentIds { get; set; }
}

