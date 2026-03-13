using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>按日历获取日程请求</summary>
public class GetScheduleByCalendarRequest
{
    /// <summary>日历 ID</summary>
    [JsonPropertyName("cal_id")]
    public string CalId { get; set; } = string.Empty;

    /// <summary>偏移量</summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }
}
