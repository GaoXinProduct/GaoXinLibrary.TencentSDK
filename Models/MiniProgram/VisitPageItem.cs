using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>页面访问数据</summary>
public class VisitPageItem
{
    /// <summary>页面路径</summary>
    [JsonPropertyName("page_path")] public string? PagePath { get; set; }
    /// <summary>访问次数</summary>
    [JsonPropertyName("page_visit_pv")] public long PageVisitPv { get; set; }
    /// <summary>访问人数</summary>
    [JsonPropertyName("page_visit_uv")] public long PageVisitUv { get; set; }
    /// <summary>次均停留时长</summary>
    [JsonPropertyName("page_staytime_pv")] public double PageStaytimePv { get; set; }
    /// <summary>进入页次数</summary>
    [JsonPropertyName("entrypage_pv")] public long EntrypagePv { get; set; }
    /// <summary>退出页次数</summary>
    [JsonPropertyName("exitpage_pv")] public long ExitpagePv { get; set; }
    /// <summary>转发次数</summary>
    [JsonPropertyName("page_share_pv")] public long PageSharePv { get; set; }
    /// <summary>转发人数</summary>
    [JsonPropertyName("page_share_uv")] public long PageShareUv { get; set; }
}

