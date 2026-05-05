using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传完成请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public record ChunkedUploadFinishRequest
{
    /// <summary>分块上传任务 ID</summary>
    [JsonPropertyName("jobid")]
    public required string JobId { get; init; }
}