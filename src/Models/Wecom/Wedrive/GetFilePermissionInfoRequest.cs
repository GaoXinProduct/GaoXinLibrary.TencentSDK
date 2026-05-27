using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件权限信息请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97891</remarks>
public record GetFilePermissionInfoRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }
}