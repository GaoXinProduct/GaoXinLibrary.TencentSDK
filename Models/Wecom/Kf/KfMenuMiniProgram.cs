using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>菜单-小程序</summary>
public class KfMenuMiniProgram
{
    /// <summary>小程序 appid</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>小程序 pagepath</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }

    /// <summary>小程序内容</summary>
    [JsonPropertyName("content")] public string? Content { get; set; }
}

