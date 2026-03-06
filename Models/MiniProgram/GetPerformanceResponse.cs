using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取性能数据响应</summary>
public class GetPerformanceResponse : WechatBaseResponse
{
    /// <summary>默认的时间和值列表</summary>
    [JsonPropertyName("default_time_data")] public PerformanceTimeData? DefaultTimeData { get; set; }
    /// <summary>对比的时间和值列表</summary>
    [JsonPropertyName("compare_time_data")] public PerformanceTimeData? CompareTimeData { get; set; }
}

