using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

/// <summary>异步上传结果详情</summary>
public class UploadByUrlResultDetail
{
    /// <summary>媒体文件上传后获取的唯一标识</summary>
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }

    /// <summary>媒体文件上传时间戳</summary>
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
}

