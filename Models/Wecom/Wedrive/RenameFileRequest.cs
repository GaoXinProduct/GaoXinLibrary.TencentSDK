using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>重命名文件请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97883</remarks>
public record RenameFileRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }

    /// <summary>新文件名</summary>
    [JsonPropertyName("new_name")]
    public required string NewName { get; init; }
}