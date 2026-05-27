using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 更新重复日程响应
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/96204"/></para>
/// </summary>
public class UpdateScheduleResponse : WecomBaseResponse
{
    /// <summary>日程 ID</summary>
    [JsonPropertyName("schedule_id")]
    public string? ScheduleId { get; set; }
}