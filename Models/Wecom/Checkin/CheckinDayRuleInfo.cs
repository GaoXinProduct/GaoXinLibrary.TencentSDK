using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>日报规则信息</summary>
public class CheckinDayRuleInfo
{
    /// <summary>打卡规则 id</summary>
    [JsonPropertyName("groupid")] public int? GroupId { get; set; }

    /// <summary>打卡规则名称</summary>
    [JsonPropertyName("groupname")] public string? GroupName { get; set; }

    /// <summary>班次 id</summary>
    [JsonPropertyName("scheduleid")] public int? ScheduleId { get; set; }

    /// <summary>班次名称</summary>
    [JsonPropertyName("schedulename")] public string? ScheduleName { get; set; }
}

