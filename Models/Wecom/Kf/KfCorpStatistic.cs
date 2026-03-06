using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>企业汇总统计数据</summary>
public class KfCorpStatistic
{
    /// <summary>数据统计日期（时间戳）</summary>
    [JsonPropertyName("stat_time")] public long StatTime { get; set; }

    /// <summary>统计数据</summary>
    [JsonPropertyName("statistic")] public KfCorpStatData? Statistic { get; set; }
}

