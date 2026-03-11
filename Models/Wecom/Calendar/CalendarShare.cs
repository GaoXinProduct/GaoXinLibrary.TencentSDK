using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>日历共享成员</summary>
public class CalendarShare
{
    /// <summary>共享成员的userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>共享成员的权限，1-可查看，2-可编辑</summary>
    [JsonPropertyName("readonly")] public int? ReadOnly { get; set; }
}
