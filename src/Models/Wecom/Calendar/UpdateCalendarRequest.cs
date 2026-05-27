
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>更新日历请求</summary>
public sealed class UpdateCalendarRequest
{
    /// <summary>日历信息</summary>
    [JsonPropertyName("calendar")]
    public CalendarInfo Calendar { get; set; } = new();
}
