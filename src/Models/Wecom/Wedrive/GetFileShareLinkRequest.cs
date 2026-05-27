using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件分享链接请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97890</remarks>
public record GetFileShareLinkRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }
}