using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>下载文件响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97881</remarks>
public class DownloadFileResponse : WecomBaseResponse
{
    /// <summary>下载链接</summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>文件大小（字节）</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }

    /// <summary>文件名</summary>
    [JsonPropertyName("file_name")]
    public string? FileName { get; set; }
}