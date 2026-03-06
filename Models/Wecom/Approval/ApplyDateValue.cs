using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>日期值</summary>
public class ApplyDateValue
{
    /// <summary>日期类型：day / hour</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>日期时间戳（秒）</summary>
    [JsonPropertyName("s_timestamp")] public string? STimestamp { get; set; }
}

