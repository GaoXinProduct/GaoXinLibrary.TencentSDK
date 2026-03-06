using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>接待人员信息</summary>
public class KfServicer
{
    /// <summary>接待人员 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>接待人员部门 id</summary>
    [JsonPropertyName("department_id")] public int? DepartmentId { get; set; }

    /// <summary>接待人员的接待状态：0-接待中 1-停止接待</summary>
    [JsonPropertyName("status")] public int Status { get; set; }
}

