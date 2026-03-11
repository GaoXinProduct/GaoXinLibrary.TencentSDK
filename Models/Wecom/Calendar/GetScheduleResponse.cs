using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>获取日程详情响应</summary>
public class GetScheduleResponse : WecomBaseResponse
{
    /// <summary>日程列表</summary>
    [JsonPropertyName("schedule_list")] public ScheduleInfo[]? ScheduleList { get; set; }
}
