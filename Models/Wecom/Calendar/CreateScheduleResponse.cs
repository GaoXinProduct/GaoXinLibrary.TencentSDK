using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>创建日程响应</summary>
public class CreateScheduleResponse : WecomBaseResponse
{
    /// <summary>日程ID</summary>
    [JsonPropertyName("schedule_id")] public string? ScheduleId { get; set; }
}
