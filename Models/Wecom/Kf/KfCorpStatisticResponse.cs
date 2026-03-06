using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取「客户数据」企业汇总数据响应</summary>
public class KfCorpStatisticResponse : WecomBaseResponse
{
    /// <summary>统计数据列表</summary>
    [JsonPropertyName("statistic_list")] public KfCorpStatistic[]? StatisticList { get; set; }
}

