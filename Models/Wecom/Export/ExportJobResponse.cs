using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Export;

/// <summary>导出任务创建响应</summary>
public class ExportJobResponse : WecomBaseResponse
{
    /// <summary>任务 ID，可通过获取导出结果接口查询任务状态</summary>
    [JsonPropertyName("jobid")] public string JobId { get; set; } = string.Empty;
}

