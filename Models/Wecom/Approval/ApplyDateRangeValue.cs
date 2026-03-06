using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>日期范围值</summary>
public class ApplyDateRangeValue
{
    /// <summary>日期类型：day / halfday / hour</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>开始时间戳（秒）</summary>
    [JsonPropertyName("new_begin")] public long? NewBegin { get; set; }

    /// <summary>结束时间戳（秒）</summary>
    [JsonPropertyName("new_end")] public long? NewEnd { get; set; }

    /// <summary>时长（秒）</summary>
    [JsonPropertyName("new_duration")] public long? NewDuration { get; set; }
}

