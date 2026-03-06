using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>排班项</summary>
public class SetScheduleItem
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>每天对应的班次 id（31 天，0 表示休息）</summary>
    [JsonPropertyName("day")] public int Day { get; set; }

    /// <summary>班次 id</summary>
    [JsonPropertyName("schedule_id")] public int ScheduleId { get; set; }
}

