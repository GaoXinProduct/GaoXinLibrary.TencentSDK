using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取空间信息请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97878</remarks>
public record GetSpaceInfoRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }
}