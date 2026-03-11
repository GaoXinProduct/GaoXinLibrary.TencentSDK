using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>空间权限信息</summary>
public class SpaceAuthInfo
{
    /// <summary>类型，1-userid，2-departmentid</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>userid或departmentid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>部门id</summary>
    [JsonPropertyName("departmentid")] public int? DepartmentId { get; set; }

    /// <summary>权限类型，1-可下载，2-可编辑，3-仅预览</summary>
    [JsonPropertyName("auth")] public int Auth { get; set; }
}
