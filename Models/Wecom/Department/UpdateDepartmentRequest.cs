using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

/// <summary>更新部门请求</summary>
public class UpdateDepartmentRequest
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("name_en")] public string? NameEn { get; set; }
    [JsonPropertyName("parentid")] public int? ParentId { get; set; }
    [JsonPropertyName("order")] public int? Order { get; set; }
}

