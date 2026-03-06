using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>特殊日期</summary>
public class SpeDay
{
    /// <summary>特殊日期时间戳</summary>
    [JsonPropertyName("timestamp")] public long Timestamp { get; set; }

    /// <summary>备注</summary>
    [JsonPropertyName("notes")] public string? Notes { get; set; }

    /// <summary>打卡时间</summary>
    [JsonPropertyName("checkintime")] public CheckinTime[]? CheckinTime { get; set; }
}

