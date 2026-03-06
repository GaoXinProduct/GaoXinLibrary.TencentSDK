using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取性能数据请求（POST /wxaapi/log/get_performance）
/// </summary>
public class GetPerformanceRequest
{
    /// <summary>耗时类型数组，如 [1001]（启动总耗时）</summary>
    [JsonPropertyName("cost_type")] public int[] CostType { get; set; } = [];
    /// <summary>查询的默认时间段起始（Unix 时间戳，毫秒）</summary>
    [JsonPropertyName("default_start_time")] public long DefaultStartTime { get; set; }
    /// <summary>查询的默认时间段结束（Unix 时间戳，毫秒）</summary>
    [JsonPropertyName("default_end_time")] public long DefaultEndTime { get; set; }
    /// <summary>设备型号（可选）</summary>
    [JsonPropertyName("device")] public string? Device { get; set; }
    /// <summary>是否下载网络类型（可选）</summary>
    [JsonPropertyName("is_download_code")] public bool? IsDownloadCode { get; set; }
    /// <summary>场景值（可选）</summary>
    [JsonPropertyName("scene")] public string? Scene { get; set; }
    /// <summary>网络类型（可选）</summary>
    [JsonPropertyName("networktype")] public string? NetworkType { get; set; }
}

