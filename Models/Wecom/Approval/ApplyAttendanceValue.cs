using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>考勤值</summary>
public class ApplyAttendanceValue
{
    /// <summary>日期范围</summary>
    [JsonPropertyName("date_range")] public ApplyDateRangeValue? DateRange { get; set; }

    /// <summary>时长类型（天/小时）</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }
}

