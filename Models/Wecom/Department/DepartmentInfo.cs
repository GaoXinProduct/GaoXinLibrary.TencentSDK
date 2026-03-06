using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

// ─── 部门信息 ──────────────────────────────────────────────────────────────

/// <summary>部门信息</summary>
public class DepartmentInfo
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("name_en")] public string? NameEn { get; set; }
    [JsonPropertyName("parentid")] public int ParentId { get; set; }
    [JsonPropertyName("order")] public int Order { get; set; }
    [JsonPropertyName("department_leader")] public string[]? DepartmentLeader { get; set; }
}

