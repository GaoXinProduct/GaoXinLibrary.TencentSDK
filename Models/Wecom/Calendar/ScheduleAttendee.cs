using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>日程参与者</summary>
public class ScheduleAttendee
{
    /// <summary>参与者userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>参与者状态，0-未处理，1-待定，2-已接受，3-已拒绝</summary>
    [JsonPropertyName("response_status")] public int ResponseStatus { get; set; }
}
