using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>取消日程请求</summary>
public class CancelScheduleRequest
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string ScheduleId { get; set; } = string.Empty;
}
