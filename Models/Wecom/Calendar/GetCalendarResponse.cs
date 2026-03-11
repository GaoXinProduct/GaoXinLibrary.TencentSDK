using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>获取日历详情响应</summary>
public class GetCalendarResponse : WecomBaseResponse
{
    /// <summary>日历列表</summary>
    [JsonPropertyName("calendar_list")] public CalendarInfo[]? CalendarList { get; set; }
}
