using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 取消日程请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97725"/></para>
/// </summary>
public class CancelScheduleRequest
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string ScheduleId { get; set; } = string.Empty;
}