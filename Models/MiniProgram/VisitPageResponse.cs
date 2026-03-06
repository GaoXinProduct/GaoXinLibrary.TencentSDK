using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>访问页面响应（POST /datacube/getweanalysisappidvisitpage）</summary>
public class VisitPageResponse : WechatBaseResponse
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("list")] public List<VisitPageItem>? List { get; set; }
}

