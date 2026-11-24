using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传初始化响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public class ChunkedUploadInitResponse : WecomBaseResponse
{
    /// <summary>服务器是否已识别完整文件，命中时无需上传分块</summary>
    [JsonPropertyName("hit_exist")]
    public bool AlreadyExists { get; set; }

    /// <summary>未命中秒传时返回的上传凭证</summary>
    [JsonPropertyName("upload_key")]
    public string? UploadKey { get; set; }

    /// <summary>命中秒传时返回的文件 ID</summary>
    [JsonPropertyName("fileid")]
    public string? FileId { get; set; }

    /// <summary>上传凭证的兼容名称</summary>
    [JsonIgnore]
    public string? JobId { get => UploadKey; set => UploadKey = value; }

    /// <summary>分块大小（字节）</summary>
    [JsonPropertyName("chunk_size")]
    public int ChunkSize { get; set; }

    /// <summary>分块总数</summary>
    [JsonPropertyName("chunk_num")]
    public int ChunkNum { get; set; }
}
