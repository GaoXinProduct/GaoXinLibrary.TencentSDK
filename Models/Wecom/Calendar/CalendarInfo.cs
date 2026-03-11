using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>日历信息</summary>
public class CalendarInfo
{
    /// <summary>日历ID</summary>
    [JsonPropertyName("cal_id")] public string? CalId { get; set; }

    /// <summary>日历标题</summary>
    [JsonPropertyName("summary")] public string? Summary { get; set; }

    /// <summary>日历颜色，RGB颜色编码16进制表示</summary>
    [JsonPropertyName("color")] public string? Color { get; set; }

    /// <summary>日历描述</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }

    /// <summary>日历组织者</summary>
    [JsonPropertyName("organizer")] public string? Organizer { get; set; }

    /// <summary>日历共享成员列表</summary>
    [JsonPropertyName("shares")] public CalendarShare[]? Shares { get; set; }
}
