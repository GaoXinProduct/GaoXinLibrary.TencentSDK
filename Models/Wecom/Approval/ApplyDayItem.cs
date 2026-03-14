using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>某一天的时长分片</summary>
public class ApplyDayItem
{
    /// <summary>当天零点时间戳（东八区）</summary>
    [JsonPropertyName("daytime")] public long? Daytime { get; set; }

    /// <summary>某一天的时长（秒）</summary>
    [JsonPropertyName("duration")] public long? Duration { get; set; }
}
