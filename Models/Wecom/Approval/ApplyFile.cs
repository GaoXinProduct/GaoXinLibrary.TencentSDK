using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>文件</summary>
public class ApplyFile
{
    /// <summary>文件 id（通过上传临时素材获取）</summary>
    [JsonPropertyName("file_id")] public string? FileId { get; set; }
}

