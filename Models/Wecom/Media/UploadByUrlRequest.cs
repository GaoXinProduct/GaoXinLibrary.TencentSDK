using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

#region 异步上传临时素材（通过 URL）

/// <summary>异步上传临时素材（通过 URL）请求</summary>
public class UploadByUrlRequest
{
    /// <summary>场景值。1-其他</summary>
    [JsonPropertyName("scene")] public int Scene { get; set; }

    /// <summary>媒体文件类型：image, voice, video, file</summary>
    [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;

    /// <summary>文件名，标识文件展示的名称。须包含后缀</summary>
    [JsonPropertyName("filename")] public string Filename { get; set; } = string.Empty;

    /// <summary>文件 CDN URL</summary>
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;

    /// <summary>文件 MD5</summary>
    [JsonPropertyName("md5")] public string Md5 { get; set; } = string.Empty;
}

#endregion
