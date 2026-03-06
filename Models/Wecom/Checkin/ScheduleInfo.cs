using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>排班信息</summary>
public class ScheduleInfo
{
    /// <summary>班次 id</summary>
    [JsonPropertyName("schedule_id")] public int ScheduleId { get; set; }

    /// <summary>班次名称</summary>
    [JsonPropertyName("schedule_name")] public string? ScheduleName { get; set; }

    /// <summary>班次上下班时段信息</summary>
    [JsonPropertyName("time_section")] public TimeSection[]? TimeSection { get; set; }

    /// <summary>允许提前打卡时间</summary>
    [JsonPropertyName("limit_aheadtime")] public long? LimitAheadTime { get; set; }

    /// <summary>下班不需要打卡</summary>
    [JsonPropertyName("noneed_offwork")] public bool? NoneedOffwork { get; set; }

    /// <summary>下班 xx 秒后不允许打下班卡</summary>
    [JsonPropertyName("limit_offtime")] public int? LimitOfftime { get; set; }

    /// <summary>允许迟到时间（秒）</summary>
    [JsonPropertyName("flex_on_duty_time")] public int? FlexOnDutyTime { get; set; }

    /// <summary>允许早退时间（秒）</summary>
    [JsonPropertyName("flex_off_duty_time")] public int? FlexOffDutyTime { get; set; }

    /// <summary>是否允许弹性时间</summary>
    [JsonPropertyName("allow_flex")] public bool? AllowFlex { get; set; }

    /// <summary>最早可打卡时间限制</summary>
    [JsonPropertyName("max_allow_arrive_early")] public int? MaxAllowArriveEarly { get; set; }

    /// <summary>最晚可打卡时间限制</summary>
    [JsonPropertyName("max_allow_arrive_late")] public int? MaxAllowArriveLate { get; set; }
}

