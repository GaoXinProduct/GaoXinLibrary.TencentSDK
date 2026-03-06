using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

/// <summary>获取异步上传临时素材结果请求</summary>
public class GetUploadByUrlResultRequest
{
    /// <summary>异步任务 ID</summary>
    [JsonPropertyName("jobid")] public string JobId { get; set; } = string.Empty;
}

