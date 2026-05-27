using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传初始化响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public class ChunkedUploadInitResponse : WecomBaseResponse
{
    /// <summary>分块上传任务 ID</summary>
    [JsonPropertyName("jobid")]
    public string? JobId { get; set; }

    /// <summary>分块大小（字节）</summary>
    [JsonPropertyName("chunk_size")]
    public int ChunkSize { get; set; }

    /// <summary>分块总数</summary>
    [JsonPropertyName("chunk_num")]
    public int ChunkNum { get; set; }
}