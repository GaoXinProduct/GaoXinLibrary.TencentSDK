using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>班次时段</summary>
public class TimeSection
{
    /// <summary>时段 id</summary>
    [JsonPropertyName("time_id")] public int TimeId { get; set; }

    /// <summary>上班时间，距离 0 点的秒数</summary>
    [JsonPropertyName("work_sec")] public int WorkSec { get; set; }

    /// <summary>下班时间，距离 0 点的秒数</summary>
    [JsonPropertyName("off_work_sec")] public int OffWorkSec { get; set; }

    /// <summary>上班提醒时间</summary>
    [JsonPropertyName("remind_work_sec")] public int RemindWorkSec { get; set; }

    /// <summary>下班提醒时间</summary>
    [JsonPropertyName("remind_off_work_sec")] public int RemindOffWorkSec { get; set; }

    /// <summary>最早一组休息开始时间</summary>
    [JsonPropertyName("rest_begin_time")] public int? RestBeginTime { get; set; }

    /// <summary>最早一组休息结束时间</summary>
    [JsonPropertyName("rest_end_time")] public int? RestEndTime { get; set; }

    /// <summary>是否允许休息</summary>
    [JsonPropertyName("allow_rest")] public bool? AllowRest { get; set; }
}

