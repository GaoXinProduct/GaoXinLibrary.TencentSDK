using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>新建文件夹/文档请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97882</remarks>
public record CreateFolderRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public required string SpaceId { get; init; }

    /// <summary>父目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public required string FatherId { get; init; }

    /// <summary>文件类型，1 - 文件夹，2 - 微文档</summary>
    [JsonPropertyName("file_type")]
    public required int FileType { get; init; }

    /// <summary>文件名称</summary>
    [JsonPropertyName("file_name")]
    public required string FileName { get; init; }
}