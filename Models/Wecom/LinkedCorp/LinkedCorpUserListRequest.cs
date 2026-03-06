using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取互联企业部门成员请求</summary>
public class LinkedCorpUserListRequest
{
    /// <summary>该字段填写 CorpId/DepartmentId，如 CORPID/DEPARTMENTID</summary>
    [JsonPropertyName("department_id")] public string DepartmentId { get; set; } = string.Empty;
}

