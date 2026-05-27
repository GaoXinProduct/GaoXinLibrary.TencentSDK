using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>性能时间数据</summary>
public sealed class PerformanceTimeData
{
    /// <summary>数据列表</summary>
    [JsonPropertyName("list")] public List<PerformanceDataPoint>? List { get; set; }
}

