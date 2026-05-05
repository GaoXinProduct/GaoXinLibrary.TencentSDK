using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>移除空间成员/部门请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97875</remarks>
public record RemoveSpaceMemberRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }

    /// <summary>成员类型，1-成员，2-部门</summary>
    [JsonPropertyName("type")]
    public required int Type { get; init; }

    /// <summary>成员 ID 列表或部门 ID 列表</summary>
    [JsonPropertyName("auth_id_list")]
    public required string[] AuthIdList { get; init; }
}