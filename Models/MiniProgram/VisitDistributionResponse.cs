using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>访问分布响应（POST /datacube/getweanalysisappidvisitdistribution）</summary>
public class VisitDistributionResponse : WechatBaseResponse
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("list")] public List<VisitDistributionItem>? List { get; set; }
}

