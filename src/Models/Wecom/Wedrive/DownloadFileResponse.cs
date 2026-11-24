using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>下载文件响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97881</remarks>
public class DownloadFileResponse : WecomBaseResponse
{
    /// <summary>文件下载链接，有效期为两小时</summary>
    [JsonPropertyName("download_url")]
    public string? Url { get; set; }

    /// <summary>向下载地址发送 GET 请求时使用的 Cookie 名</summary>
    [JsonPropertyName("cookie_name")]
    public string? CookieName { get; set; }

    /// <summary>下载请求使用的 Cookie 值</summary>
    [JsonPropertyName("cookie_value")]
    public string? CookieValue { get; set; }

    /// <summary>文件大小（字节）</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }

    /// <summary>文件名</summary>
    [JsonPropertyName("file_name")]
    public string? FileName { get; set; }
}
