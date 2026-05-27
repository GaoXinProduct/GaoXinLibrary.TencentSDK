using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 删除日程参与者请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97722"/></para>
/// </summary>
public class DeleteScheduleAttendeesRequest
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string ScheduleId { get; set; } = string.Empty;

    /// <summary>参与者 ID 列表（userid 或 externaluserid）</summary>
    [JsonPropertyName("attendees")]
    public string[] Attendees { get; set; } = [];
}