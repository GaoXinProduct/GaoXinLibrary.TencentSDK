using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>概况趋势响应（POST /datacube/getweanalysisappiddailysummarytrend）</summary>
public class DailySummaryTrendResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<DailySummaryTrendItem>? List { get; set; }
}

