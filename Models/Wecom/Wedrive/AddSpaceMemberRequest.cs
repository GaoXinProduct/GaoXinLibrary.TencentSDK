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
    [JsonPropertyName("auth_list")]
    public required SpaceMemberAuth[] AuthList { get; init; }
}

/// <summary>空间成员权限信息</summary>
public class SpaceMemberAuth
{
    /// <summary>成员类型，1-成员，2-部门</summary>
    [JsonPropertyName("type")]
    public int Type { get; init; }

    /// <summary>成员 ID 或部门 ID</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>权限，1-可查看，2-可编辑，3-可管理</summary>
    [JsonPropertyName("auth")]
    public int Auth { get; init; }
}