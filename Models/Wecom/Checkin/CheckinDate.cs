using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>打卡日期配置</summary>
public class CheckinDate
{
    /// <summary>工作日列表，1-6 表示星期一到六，0 表示星期日</summary>
    [JsonPropertyName("workdays")] public int[]? Workdays { get; set; }

    /// <summary>上下班打卡时间信息</summary>
    [JsonPropertyName("checkintime")] public CheckinTime[]? CheckinTime { get; set; }

    /// <summary>下班不需要打卡</summary>
    [JsonPropertyName("noneed_offwork")] public bool? NoneedOffwork { get; set; }

    /// <summary>打卡时间限制（毫秒）</summary>
    [JsonPropertyName("limit_aheadtime")] public long? LimitAheadTime { get; set; }

    /// <summary>允许迟到时间（秒）</summary>
    [JsonPropertyName("flex_on_duty_time")] public int? FlexOnDutyTime { get; set; }

    /// <summary>允许早退时间（秒）</summary>
    [JsonPropertyName("flex_off_duty_time")] public int? FlexOffDutyTime { get; set; }
}

