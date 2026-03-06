using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据分析通用请求（POST /datacube/*）
/// </summary>
public class DataAnalysisRequest
{
    /// <summary>开始日期（yyyyMMdd）</summary>
    [JsonPropertyName("begin_date")] public required string BeginDate { get; set; }

    /// <summary>结束日期（yyyyMMdd），限定查询 1 天数据时 end_date = begin_date</summary>
    [JsonPropertyName("end_date")] public required string EndDate { get; set; }
}

