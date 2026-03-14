using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批控件值</summary>
public class ApplyContentValue
{
    /// <summary>Text / Textarea 控件值</summary>
    [JsonPropertyName("text")] public string? Text { get; set; }

    /// <summary>Number 控件值</summary>
    [JsonPropertyName("new_number")] public string? NewNumber { get; set; }

    /// <summary>Money 控件值</summary>
    [JsonPropertyName("new_money")] public string? NewMoney { get; set; }

    /// <summary>Date 控件值</summary>
    [JsonPropertyName("date")] public ApplyDateValue? Date { get; set; }

    /// <summary>Selector 控件值</summary>
    [JsonPropertyName("selector")] public ApplySelectorValue? Selector { get; set; }

    /// <summary>Contact 控件值：成员列表</summary>
    [JsonPropertyName("members")] public ApplyMember[]? Members { get; set; }

    /// <summary>Contact 控件值：部门列表</summary>
    [JsonPropertyName("departments")] public ApplyDepartment[]? Departments { get; set; }

    /// <summary>File 控件值</summary>
    [JsonPropertyName("files")] public ApplyFile[]? Files { get; set; }

    /// <summary>Table 控件值（明细）</summary>
    [JsonPropertyName("children")] public ApplyContent[][]? Children { get; set; }

    /// <summary>Vacation 控件值</summary>
    [JsonPropertyName("vacation")] public ApplyVacationValue? Vacation { get; set; }

    /// <summary>Location 控件值</summary>
    [JsonPropertyName("location")] public ApplyLocationValue? Location { get; set; }

    /// <summary>DateRange 控件值</summary>
    [JsonPropertyName("date_range")] public ApplyDateRangeValue? DateRange { get; set; }

    /// <summary>Attendance 假勤控件值</summary>
    [JsonPropertyName("attendance")] public ApplyAttendanceValue? Attendance { get; set; }

    /// <summary>RelatedApproval 关联审批单控件值</summary>
    [JsonPropertyName("related_approval")] public ApplyRelatedApprovalItem[]? RelatedApproval { get; set; }

    /// <summary>Formula 公式控件值（后台自动计算）</summary>
    [JsonPropertyName("formula")] public ApplyFormulaValue? Formula { get; set; }
}

