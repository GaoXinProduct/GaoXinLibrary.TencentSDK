using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>控件属性</summary>
public class ControlProperty
{
    /// <summary>控件类型：Text, Textarea, Number, Money, Date, Selector, Contact, Tips, File, Table, Location, RelatedApproval, Formula, DateRange, Vacation, Attendance, PhoneNumber, BankAccount</summary>
    [JsonPropertyName("control")] public string? Control { get; set; }

    /// <summary>控件 id</summary>
    [JsonPropertyName("id")] public string? Id { get; set; }

    /// <summary>控件名称</summary>
    [JsonPropertyName("title")] public ApprovalText[]? Title { get; set; }

    /// <summary>控件说明</summary>
    [JsonPropertyName("placeholder")] public ApprovalText[]? Placeholder { get; set; }

    /// <summary>是否必填</summary>
    [JsonPropertyName("require")] public int? Require { get; set; }

    /// <summary>是否参与打印</summary>
    [JsonPropertyName("un_print")] public int? UnPrint { get; set; }
}

