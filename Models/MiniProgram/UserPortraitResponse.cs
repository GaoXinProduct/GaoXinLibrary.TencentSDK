using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>用户画像响应（POST /datacube/getweanalysisappiduserportrait）</summary>
public class UserPortraitResponse : WechatBaseResponse
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    /// <summary>新用户画像</summary>
    [JsonPropertyName("visit_uv_new")] public PortraitData? VisitUvNew { get; set; }
    /// <summary>活跃用户画像</summary>
    [JsonPropertyName("visit_uv")] public PortraitData? VisitUv { get; set; }
}

