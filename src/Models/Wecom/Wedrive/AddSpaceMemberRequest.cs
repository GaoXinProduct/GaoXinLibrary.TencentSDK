using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>添加空间成员/部门请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/93656</remarks>
public record AddSpaceMemberRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }

    /// <summary>成员权限列表</summary>
    [JsonPropertyName("auth_info")]
    public required SpaceMemberAuth[] AuthList { get; init; }
}

/// <summary>空间成员权限信息</summary>
public class SpaceMemberAuth
{
    private string? _userId;
    private uint? _departmentId;

    /// <summary>成员类型，1-成员，2-部门</summary>
    [JsonPropertyName("type")]
    public int Type { get; init; }

    /// <summary>兼容字段，按成员类型写入成员 ID 或部门 ID</summary>
    [JsonIgnore]
    public string? Id { get; init; }

    /// <summary>成员 ID</summary>
    [JsonPropertyName("userid")]
    public string? UserId
    {
        get => _userId ?? (Type == 1 ? Id : null);
        init => _userId = value;
    }

    /// <summary>部门 ID</summary>
    [JsonPropertyName("departmentid")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public uint? DepartmentId
    {
        get => _departmentId ?? (Type == 2 && uint.TryParse(Id, out var id) ? id : null);
        init => _departmentId = value;
    }

    /// <summary>空间权限值</summary>
    [JsonPropertyName("auth")]
    public int Auth { get; init; }
}
