using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 新增日程参与者响应
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97721"/></para>
/// </summary>
public class AddScheduleAttendeesResponse : WecomBaseResponse
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string? ScheduleId { get; set; }
}