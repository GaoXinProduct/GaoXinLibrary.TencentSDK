using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>移除空间成员/部门请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97875</remarks>
public record RemoveSpaceMemberRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }

    /// <summary>要移除的成员和部门</summary>
    [JsonPropertyName("auth_info")]
    public SpaceMemberIdentity[]? AuthInfo { get; init; }

    /// <summary>兼容字段，指定 AuthIdList 中的 ID 类型</summary>
    [JsonIgnore]
    public int Type { get; init; }

    /// <summary>兼容字段，用于移除同一类型的多个成员或部门</summary>
    [JsonIgnore]
    public string[]? AuthIdList { get; init; }
}

/// <summary>空间成员或部门的标识</summary>
public sealed class SpaceMemberIdentity
{
    /// <summary>1 为成员，2 为部门</summary>
    [JsonPropertyName("type")]
    public required int Type { get; init; }

    /// <summary>成员 ID</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; init; }

    /// <summary>部门 ID</summary>
    [JsonPropertyName("departmentid")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public uint? DepartmentId { get; init; }
}
