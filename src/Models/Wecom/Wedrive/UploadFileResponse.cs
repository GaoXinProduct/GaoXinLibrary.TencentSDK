using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>上传文件响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97880</remarks>
public class UploadFileResponse : WecomBaseResponse
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public string? FileId { get; set; }

    /// <summary>文件大小（字节）</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }
}