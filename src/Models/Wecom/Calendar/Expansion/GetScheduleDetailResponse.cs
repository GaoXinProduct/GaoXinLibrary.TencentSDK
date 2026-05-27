using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 获取日程详情响应
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97724"/></para>
/// </summary>
public class GetScheduleDetailResponse : WecomBaseResponse
{
    /// <summary>日程列表</summary>
    [JsonPropertyName("schedule_list")]
    public ScheduleInfo[]? ScheduleList { get; set; }
}