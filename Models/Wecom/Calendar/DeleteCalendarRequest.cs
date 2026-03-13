using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>删除日历请求</summary>
public class DeleteCalendarRequest
{
    /// <summary>日历 ID</summary>
    [JsonPropertyName("cal_id")]
    public string CalId { get; set; } = string.Empty;
}
