using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>假期控件值</summary>
public class ApplyVacationValue
{
    /// <summary>请假类型</summary>
    [JsonPropertyName("selector")] public ApplySelectorValue? Selector { get; set; }

    /// <summary>假期日期范围</summary>
    [JsonPropertyName("attendance")] public ApplyAttendanceValue? Attendance { get; set; }
}

