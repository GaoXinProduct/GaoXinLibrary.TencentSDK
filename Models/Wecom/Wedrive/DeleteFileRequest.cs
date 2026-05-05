using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>删除文件请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97885</remarks>
public record DeleteFileRequest
{
    /// <summary>文件 ID 列表</summary>
    [JsonPropertyName("fileid")]
    public required string[] FileIds { get; init; }
}