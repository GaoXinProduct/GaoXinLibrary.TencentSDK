using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 删除日程参与者响应
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97722"/></para>
/// </summary>
public class DeleteScheduleAttendeesResponse : WecomBaseResponse
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string? ScheduleId { get; set; }
}