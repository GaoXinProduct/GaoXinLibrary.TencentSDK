using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>移动文件请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97884</remarks>
public record MoveFileRequest
{
    /// <summary>文件 ID 列表</summary>
    [JsonPropertyName("fileid")]
    public required string[] FileIds { get; init; }

    /// <summary>目标目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public required string FatherId { get; init; }
}