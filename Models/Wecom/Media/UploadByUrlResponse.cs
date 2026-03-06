using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

/// <summary>异步上传临时素材响应</summary>
public class UploadByUrlResponse : WecomBaseResponse
{
    /// <summary>异步任务 ID，可通过获取异步上传结果接口查询</summary>
    [JsonPropertyName("jobid")] public string? JobId { get; set; }
}

