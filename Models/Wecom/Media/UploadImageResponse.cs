using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

/// <summary>上传图片响应</summary>
public class UploadImageResponse : WecomBaseResponse
{
    /// <summary>永久图片链接</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }
}

