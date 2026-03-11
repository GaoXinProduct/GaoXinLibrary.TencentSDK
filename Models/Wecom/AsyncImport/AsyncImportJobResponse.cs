using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

/// <summary>异步导入任务响应</summary>
public class AsyncImportJobResponse : WecomBaseResponse
{
    /// <summary>异步任务id，最大长度为64字符</summary>
    [JsonPropertyName("jobid")] public string JobId { get; set; } = string.Empty;
}
