using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_upload_media_chunk 上传分片请求体
/// <para>分片可乱序上传，重复上传同一分片会被自动忽略（幂等）。</para>
/// </summary>
public class WsUploadMediaChunkBody
{
    /// <summary>上传 ID（初始化时返回）</summary>
    [JsonPropertyName("upload_id")] public string UploadId { get; set; } = string.Empty;

    /// <summary>分片序号，从 0 开始</summary>
    [JsonPropertyName("chunk_index")] public int ChunkIndex { get; set; }

    /// <summary>分片内容经过 Base64 编码后的数据（编码前单片不超过 512KB）</summary>
    [JsonPropertyName("base64_data")] public string Base64Data { get; set; } = string.Empty;
}
