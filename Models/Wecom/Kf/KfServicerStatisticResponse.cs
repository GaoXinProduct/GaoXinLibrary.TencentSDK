using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取「客户数据」接待人员明细数据响应</summary>
public class KfServicerStatisticResponse : WecomBaseResponse
{
    /// <summary>统计数据列表</summary>
    [JsonPropertyName("statistic_list")] public KfServicerStatistic[]? StatisticList { get; set; }
}

