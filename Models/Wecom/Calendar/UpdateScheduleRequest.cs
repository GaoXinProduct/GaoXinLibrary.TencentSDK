using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>更新日程请求</summary>
public class UpdateScheduleRequest
{
    /// <summary>日程信息</summary>
    [JsonPropertyName("schedule")]
    public ScheduleInfo Schedule { get; set; } = new();
}
