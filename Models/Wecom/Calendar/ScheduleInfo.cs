using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>日程信息</summary>
public class ScheduleInfo
{
    /// <summary>日程ID</summary>
    [JsonPropertyName("schedule_id")] public string? ScheduleId { get; set; }

    /// <summary>日程标题</summary>
    [JsonPropertyName("summary")] public string? Summary { get; set; }

    /// <summary>日程描述</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }

    /// <summary>日程组织者</summary>
    [JsonPropertyName("organizer")] public string? Organizer { get; set; }

    /// <summary>日程开始时间（Unix时间戳）</summary>
    [JsonPropertyName("start_time")] public long StartTime { get; set; }

    /// <summary>日程结束时间（Unix时间戳）</summary>
    [JsonPropertyName("end_time")] public long EndTime { get; set; }

    /// <summary>日程地点</summary>
    [JsonPropertyName("location")] public string? Location { get; set; }

    /// <summary>日程所属日历ID</summary>
    [JsonPropertyName("cal_id")] public string? CalId { get; set; }

    /// <summary>日程参与者列表</summary>
    [JsonPropertyName("attendees")] public ScheduleAttendee[]? Attendees { get; set; }
}
