using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>性能数据点</summary>
public class PerformanceDataPoint
{
    /// <summary>时间戳（毫秒）</summary>
    [JsonPropertyName("time")] public long Time { get; set; }
    /// <summary>值</summary>
    [JsonPropertyName("value")] public double Value { get; set; }
}

