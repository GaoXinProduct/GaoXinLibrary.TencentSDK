using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>下载文件请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97881</remarks>
public record DownloadFileRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }

    /// <summary>返回下载链接的格式，1 - url，2 - json（仅管理员可获取他人文件下载链接）</summary>
    [JsonPropertyName("download_type")]
    public int DownloadType { get; init; } = 1;
}