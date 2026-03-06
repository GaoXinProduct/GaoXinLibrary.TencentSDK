using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Export;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取导出结果请求</summary>
public class GetExportResultRequest
{
    /// <summary>导出任务 ID</summary>
    [JsonPropertyName("jobid")] public string JobId { get; set; } = string.Empty;
}

