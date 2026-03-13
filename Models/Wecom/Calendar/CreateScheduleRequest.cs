using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>创建日程请求</summary>
public class CreateScheduleRequest
{
    /// <summary>日程信息</summary>
    [JsonPropertyName("schedule")]
    public ScheduleInfo Schedule { get; set; } = new();
}
