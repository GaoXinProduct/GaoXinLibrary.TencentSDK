using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 新增日程参与者请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97721"/></para>
/// </summary>
public class AddScheduleAttendeesRequest
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string ScheduleId { get; set; } = string.Empty;

    /// <summary>参与者列表</summary>
    [JsonPropertyName("attendees")]
    public ScheduleAttendee[] Attendees { get; set; } = [];
}