using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>性能时间数据</summary>
public class PerformanceTimeData
{
    /// <summary>数据列表</summary>
    [JsonPropertyName("list")] public List<PerformanceDataPoint>? List { get; set; }
}

