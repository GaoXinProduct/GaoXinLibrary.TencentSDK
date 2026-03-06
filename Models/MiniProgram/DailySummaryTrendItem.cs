using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>概况趋势项</summary>
public class DailySummaryTrendItem
{
    /// <summary>日期（yyyyMMdd）</summary>
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    /// <summary>累计用户数</summary>
    [JsonPropertyName("visit_total")] public long VisitTotal { get; set; }
    /// <summary>转发次数</summary>
    [JsonPropertyName("share_pv")] public long SharePv { get; set; }
    /// <summary>转发人数</summary>
    [JsonPropertyName("share_uv")] public long ShareUv { get; set; }
}

