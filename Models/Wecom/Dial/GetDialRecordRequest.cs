using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

/// <summary>获取公费电话通话记录请求</summary>
public class GetDialRecordRequest
{
    /// <summary>起始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>偏移量</summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}
