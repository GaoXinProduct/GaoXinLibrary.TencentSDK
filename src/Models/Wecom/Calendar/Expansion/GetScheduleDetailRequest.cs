using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 获取日程详情请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97724"/></para>
/// </summary>
public class GetScheduleDetailRequest
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string ScheduleId { get; set; } = string.Empty;
}