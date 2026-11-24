
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>空间权限信息</summary>
public sealed class SpaceAuthInfo
{
    /// <summary>类型，1-userid，2-departmentid</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>成员 ID</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>部门 ID，支持完整的 32 位无符号范围</summary>
    [JsonPropertyName("departmentid")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public uint? DepartmentIdValue { get; set; }

    /// <summary>兼容字段，读取可表示为有符号整数的部门 ID</summary>
    [JsonIgnore]
    public int? DepartmentId
    {
        get => DepartmentIdValue is <= int.MaxValue ? (int?)DepartmentIdValue : null;
        set => DepartmentIdValue = checked((uint?)value);
    }

    /// <summary>空间权限值</summary>
    [JsonPropertyName("auth")] public int Auth { get; set; }
}
