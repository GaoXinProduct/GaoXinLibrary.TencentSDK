using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>数据统计通用请求（日期范围）</summary>
public class OfficialDataAnalysisRequest
{
    /// <summary>开始日期（yyyy-MM-dd）</summary>
    [JsonPropertyName("begin_date")] public required string BeginDate { get; set; }
    /// <summary>结束日期（yyyy-MM-dd）</summary>
    [JsonPropertyName("end_date")] public required string EndDate { get; set; }
}

