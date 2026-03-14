using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_upload_media_init 上传初始化请求体
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101463"/></para>
/// </summary>
public class WsUploadMediaInitBody
{
    /// <summary>文件类型（file / image / voice / video）</summary>
    [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;

    /// <summary>文件名，不超过 256 字节</summary>
    [JsonPropertyName("filename")] public string Filename { get; set; } = string.Empty;

    /// <summary>文件总大小（字节）</summary>
    [JsonPropertyName("total_size")] public long TotalSize { get; set; }

    /// <summary>分片数量，不超过 100 个</summary>
    [JsonPropertyName("total_chunks")] public int TotalChunks { get; set; }

    /// <summary>文件 MD5（可选，用于完整性校验）</summary>
    [JsonPropertyName("md5")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Md5 { get; set; }
}
