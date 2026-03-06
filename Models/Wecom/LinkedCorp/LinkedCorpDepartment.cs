using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>互联企业部门信息</summary>
public class LinkedCorpDepartment
{
    /// <summary>部门 id，由 CorpId/DepartmentId 拼接</summary>
    [JsonPropertyName("department_id")] public string DepartmentId { get; set; } = string.Empty;

    /// <summary>部门名称</summary>
    [JsonPropertyName("department_name")] public string? DepartmentName { get; set; }

    /// <summary>上级部门 id</summary>
    [JsonPropertyName("parentid")] public string? ParentId { get; set; }

    /// <summary>排序值</summary>
    [JsonPropertyName("order")] public long Order { get; set; }
}

