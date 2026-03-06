using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>每日排班信息</summary>
public class ScheduleDayInfo
{
    /// <summary>时间段信息</summary>
    [JsonPropertyName("time_section")] public TimeSection[]? TimeSection { get; set; }

    /// <summary>日期（Unix 时间戳）</summary>
    [JsonPropertyName("day")] public int? Day { get; set; }

    /// <summary>班次 id</summary>
    [JsonPropertyName("schedule_id")] public int? ScheduleId { get; set; }

    /// <summary>班次名称</summary>
    [JsonPropertyName("schedule_name")] public string? ScheduleName { get; set; }
}

