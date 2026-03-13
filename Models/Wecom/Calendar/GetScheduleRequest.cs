using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;

/// <summary>获取日程请求</summary>
public class GetScheduleRequest
{
    /// <summary>日程 ID 列表</summary>
    [JsonPropertyName("schedule_id_list")]
    public string[] ScheduleIdList { get; set; } = [];
}
