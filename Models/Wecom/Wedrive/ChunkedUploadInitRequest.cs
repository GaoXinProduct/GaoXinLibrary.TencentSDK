using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传初始化请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public record ChunkedUploadInitRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }

    /// <summary>父目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public required string FatherId { get; init; }

    /// <summary>文件名称</summary>
    [JsonPropertyName("file_name")]
    public required string FileName { get; init; }

    /// <summary>文件总大小（字节）</summary>
    [JsonPropertyName("file_size")]
    public required long FileSize { get; init; }

    /// <summary>文件 MD5</summary>
    [JsonPropertyName("file_hash")]
    public required string FileHash { get; init; }

    /// <summary>上传者 userid（仅管理员可上传他人文件）</summary>
    [JsonPropertyName("upload_userid")]
    public string? UploadUserId { get; init; }
}