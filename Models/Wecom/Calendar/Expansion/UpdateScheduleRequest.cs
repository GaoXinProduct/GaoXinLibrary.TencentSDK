using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 更新重复日程请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/96204"/></para>
/// </summary>
public class UpdateScheduleRequest
{
    /// <summary>日程信息</summary>
    [JsonPropertyName("schedule")]
    public ScheduleInfo Schedule { get; set; } = new();
}