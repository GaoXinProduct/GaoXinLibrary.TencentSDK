using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>加班打卡规则</summary>
public class OtCheckInfo
{
    /// <summary>工作日加班开始时间（秒）</summary>
    [JsonPropertyName("ot_workingday_time_start")] public int? OtWorkingdayTimeStart { get; set; }

    /// <summary>工作日最短加班时长（秒）</summary>
    [JsonPropertyName("ot_workingday_time_min")] public int? OtWorkingdayTimeMin { get; set; }

    /// <summary>工作日最长加班时长（秒）</summary>
    [JsonPropertyName("ot_workingday_time_max")] public int? OtWorkingdayTimeMax { get; set; }

    /// <summary>非工作日最短加班时长（秒）</summary>
    [JsonPropertyName("ot_nonworkingday_time_min")] public int? OtNonworkingdayTimeMin { get; set; }

    /// <summary>非工作日最长加班时长（秒）</summary>
    [JsonPropertyName("ot_nonworkingday_time_max")] public int? OtNonworkingdayTimeMax { get; set; }

    /// <summary>非工作日加班跨天时间</summary>
    [JsonPropertyName("ot_nonworkingday_spanday_time")] public int? OtNonworkingdaySpandayTime { get; set; }
}

