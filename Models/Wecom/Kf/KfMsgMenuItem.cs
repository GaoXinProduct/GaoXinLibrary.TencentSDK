using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>菜单项</summary>
public class KfMsgMenuItem
{
    /// <summary>菜单项类型：click / view / miniprogram</summary>
    [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;

    /// <summary>菜单 id（click 类型必填）</summary>
    [JsonPropertyName("click")] public KfMenuClick? Click { get; set; }

    /// <summary>链接（view 类型必填）</summary>
    [JsonPropertyName("view")] public KfMenuView? View { get; set; }

    /// <summary>小程序（miniprogram 类型必填）</summary>
    [JsonPropertyName("miniprogram")] public KfMenuMiniProgram? MiniProgram { get; set; }
}

