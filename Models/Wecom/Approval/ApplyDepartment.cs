using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>联系人-部门</summary>
public class ApplyDepartment
{
    /// <summary>部门 id</summary>
    [JsonPropertyName("openapi_id")] public string? OpenApiId { get; set; }

    /// <summary>部门名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
}

