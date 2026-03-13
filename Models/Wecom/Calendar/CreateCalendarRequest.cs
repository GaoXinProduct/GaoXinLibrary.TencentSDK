using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>创建日历请求</summary>
public class CreateCalendarRequest
{
    /// <summary>日历信息</summary>
    [JsonPropertyName("calendar")]
    public CalendarInfo Calendar { get; set; } = new();
}
