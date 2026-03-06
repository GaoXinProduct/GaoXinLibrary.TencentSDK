using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>月报汇总信息</summary>
public class CheckinMonthSummaryInfo
{
    /// <summary>应打卡天数</summary>
    [JsonPropertyName("work_days")] public int? WorkDays { get; set; }

    /// <summary>正常天数</summary>
    [JsonPropertyName("regular_days")] public int? RegularDays { get; set; }

    /// <summary>异常天数</summary>
    [JsonPropertyName("except_days")] public int? ExceptDays { get; set; }

    /// <summary>迟到次数</summary>
    [JsonPropertyName("late_count")] public int? LateCount { get; set; }

    /// <summary>早退次数</summary>
    [JsonPropertyName("early_count")] public int? EarlyCount { get; set; }

    /// <summary>缺卡次数</summary>
    [JsonPropertyName("bnormal_count")] public int? BnormalCount { get; set; }

    /// <summary>旷工天数</summary>
    [JsonPropertyName("absent_count")] public int? AbsentCount { get; set; }
}

