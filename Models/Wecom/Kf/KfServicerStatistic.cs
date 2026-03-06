using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>接待人员明细统计数据</summary>
public class KfServicerStatistic
{
    /// <summary>数据统计日期（时间戳）</summary>
    [JsonPropertyName("stat_time")] public long StatTime { get; set; }

    /// <summary>统计数据</summary>
    [JsonPropertyName("statistic")] public KfServicerStatData? Statistic { get; set; }
}

