using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>获取日历请求</summary>
public class GetCalendarRequest
{
    /// <summary>日历 ID 列表</summary>
    [JsonPropertyName("cal_id_list")]
    public string[] CalIdList { get; set; } = [];
}
