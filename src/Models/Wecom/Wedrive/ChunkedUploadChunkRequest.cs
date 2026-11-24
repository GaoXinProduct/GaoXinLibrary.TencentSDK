using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public record ChunkedUploadChunkRequest
{
    /// <summary>固定分块大小（字节），末块可以更短</summary>
    public const int BlockSizeBytes = 2 * 1024 * 1024;

    /// <summary>初始化返回的上传凭证</summary>
    [JsonPropertyName("upload_key")]
    public string? UploadKey { get; init; }

    /// <summary>从 1 开始的分块序号</summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>分块原始内容，序列化为 Base64</summary>
    [JsonPropertyName("file_base64_content")]
    public byte[]? FileContent { get; init; }

    /// <summary>上传凭证的兼容名称</summary>
    [JsonIgnore]
    public string? JobId { get => UploadKey; init => UploadKey = value; }

    /// <summary>从 0 开始的分块序号兼容字段</summary>
    [JsonIgnore]
    public int ChunkSeq { get => Index - 1; init => Index = checked(value + 1); }
}
