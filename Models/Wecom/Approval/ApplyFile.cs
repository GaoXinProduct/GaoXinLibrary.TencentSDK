using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>文件</summary>
public class ApplyFile
{
    /// <summary>文件 id（通过上传临时素材获取）</summary>
    [JsonPropertyName("file_id")] public string? FileId { get; set; }

    /// <summary>文件名称</summary>
    [JsonPropertyName("file_name")] public string? FileName { get; set; }

    /// <summary>文件大小</summary>
    [JsonPropertyName("file_size")] public string? FileSize { get; set; }

    /// <summary>文件类型</summary>
    [JsonPropertyName("file_type")] public string? FileType { get; set; }

    /// <summary>文件地址</summary>
    [JsonPropertyName("file_url")] public string? FileUrl { get; set; }
}

