using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>排班信息项</summary>
public class CheckinScheduleItem
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>排班名称</summary>
    [JsonPropertyName("yearmonth")] public int? YearMonth { get; set; }

    /// <summary>规则 id</summary>
    [JsonPropertyName("groupid")] public int? GroupId { get; set; }

    /// <summary>规则名称</summary>
    [JsonPropertyName("groupname")] public string? GroupName { get; set; }

    /// <summary>排班信息</summary>
    [JsonPropertyName("schedule")] public ScheduleDayInfo? Schedule { get; set; }
}

