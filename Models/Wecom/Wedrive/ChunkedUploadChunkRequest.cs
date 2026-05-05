using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public record ChunkedUploadChunkRequest
{
    /// <summary>分块上传任务 ID</summary>
    [JsonPropertyName("jobid")]
    public required string JobId { get; init; }

    /// <summary>分块序号（从 0 开始）</summary>
    [JsonPropertyName("chunk_seq")]
    public required int ChunkSeq { get; init; }
}