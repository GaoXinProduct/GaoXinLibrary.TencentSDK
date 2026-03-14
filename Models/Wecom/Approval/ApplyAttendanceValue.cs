using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>假勤值（出差/外出/加班/请假）</summary>
public class ApplyAttendanceValue
{
    /// <summary>假勤组件时间选择范围</summary>
    [JsonPropertyName("date_range")] public ApplyDateRangeValue? DateRange { get; set; }

    /// <summary>假勤组件类型：1-请假；3-出差；4-外出；5-加班</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }

    /// <summary>时长分片信息（非必填）</summary>
    [JsonPropertyName("slice_info")] public ApplySliceInfo? SliceInfo { get; set; }
}

