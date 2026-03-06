using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

// ─── 请求模型 ──────────────────────────────────────────────────────────────

/// <summary>创建部门请求</summary>
public class CreateDepartmentRequest
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("name_en")] public string? NameEn { get; set; }
    [JsonPropertyName("parentid")] public int ParentId { get; set; }
    [JsonPropertyName("order")] public int? Order { get; set; }
    [JsonPropertyName("id")] public int? Id { get; set; }
}

