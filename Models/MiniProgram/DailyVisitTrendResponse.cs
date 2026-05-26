using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>访问趋势响应（POST /datacube/getweanalysisappiddailyvisittrend）</summary>
public sealed class DailyVisitTrendResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<DailyVisitTrendItem>? List { get; set; }
}

