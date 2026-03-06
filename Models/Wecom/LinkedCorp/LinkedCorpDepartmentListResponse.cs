using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>获取互联企业部门列表响应</summary>
public class LinkedCorpDepartmentListResponse : WecomBaseResponse
{
    /// <summary>部门列表</summary>
    [JsonPropertyName("department_list")] public LinkedCorpDepartment[]? DepartmentList { get; set; }
}

