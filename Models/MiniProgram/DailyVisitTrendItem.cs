using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>访问趋势项</summary>
public class DailyVisitTrendItem
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    /// <summary>打开次数</summary>
    [JsonPropertyName("session_cnt")] public long SessionCnt { get; set; }
    /// <summary>访问次数</summary>
    [JsonPropertyName("visit_pv")] public long VisitPv { get; set; }
    /// <summary>访问人数</summary>
    [JsonPropertyName("visit_uv")] public long VisitUv { get; set; }
    /// <summary>新用户数</summary>
    [JsonPropertyName("visit_uv_new")] public long VisitUvNew { get; set; }
    /// <summary>人均停留时长（秒）</summary>
    [JsonPropertyName("stay_time_uv")] public double StayTimeUv { get; set; }
    /// <summary>次均停留时长（秒）</summary>
    [JsonPropertyName("stay_time_session")] public double StayTimeSession { get; set; }
    /// <summary>平均访问深度</summary>
    [JsonPropertyName("visit_depth")] public double VisitDepth { get; set; }
}

