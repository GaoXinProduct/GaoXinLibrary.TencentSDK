using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>日报汇总信息</summary>
public class CheckinDaySummaryInfo
{
    /// <summary>打卡次数</summary>
    [JsonPropertyName("checkin_count")] public int? CheckinCount { get; set; }

    /// <summary>正常次数</summary>
    [JsonPropertyName("regular_work_sec")] public int? RegularWorkSec { get; set; }

    /// <summary>标准工作时长（秒）</summary>
    [JsonPropertyName("standard_work_sec")] public int? StandardWorkSec { get; set; }

    /// <summary>最早打卡时间</summary>
    [JsonPropertyName("earliest_time")] public long? EarliestTime { get; set; }

    /// <summary>最晚打卡时间</summary>
    [JsonPropertyName("lastest_time")] public long? LastestTime { get; set; }
}

