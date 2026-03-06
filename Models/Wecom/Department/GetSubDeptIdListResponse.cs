using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Department;

public class GetSubDeptIdListResponse : WecomBaseResponse
{
    [JsonPropertyName("department_id")] public SubDeptInfo[]? DepartmentIds { get; set; }
}

/// <summary>子部门简要信息</summary>
public class SubDeptInfo
{
    /// <summary>部门 ID</summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>父部门 ID</summary>
    [JsonPropertyName("parentid")] public int ParentId { get; set; }

    /// <summary>在父部门中的排序值</summary>
    [JsonPropertyName("order")] public long Order { get; set; }
}

