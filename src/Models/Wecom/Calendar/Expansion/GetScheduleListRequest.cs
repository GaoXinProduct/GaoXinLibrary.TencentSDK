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

    /// <summary>起始偏移量，从 0 开始</summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

    /// <summary>每页数量，范围为 1 到 1000</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>旧版请求属性</summary>
    [Obsolete("日程列表接口仅支持按 Offset 和 Limit 分页。")]
    [JsonIgnore]
    public long StartTime { get; set; }

    /// <summary>旧版请求属性</summary>
    [Obsolete("日程列表接口仅支持按 Offset 和 Limit 分页。")]
    [JsonIgnore]
    public long EndTime { get; set; }

    /// <summary>旧版请求属性</summary>
    [Obsolete("日程列表接口仅支持按 Offset 和 Limit 分页。")]
    [JsonIgnore]
    public int FilterType { get; set; }
}
