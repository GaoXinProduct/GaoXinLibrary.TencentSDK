using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>设置空间安全设置请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97876</remarks>
public record SetSpaceSecurityRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }

    /// <summary>安全模式，0-关闭，1-企业员工可查看，2-企业内外成员均可查看</summary>
    [JsonPropertyName("security_mode")]
    public required int SecurityMode { get; init; }
}