using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取空间邀请链接请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97877</remarks>
public record GetSpaceInviteLinkRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }
}