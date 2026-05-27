using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Calendar.Expansion;

/// <summary>
/// 获取日历下的日程列表请求
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97723"/></para>
/// </summary>
public class GetScheduleListRequest
{
    /// <summary>日历 ID</summary>
    [JsonPropertyName("cal_id")]
    public string CalId { get; set; } = string.Empty;

    /// <summary>日程开始时间（Unix时间戳）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>日程结束时间（Unix时间戳）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>日程过滤类型（0-仅查询日历本身的日程 1-查询日历及其共享日历的全部日程）</summary>
    [JsonPropertyName("filter_type")]
    public int FilterType { get; set; }
}