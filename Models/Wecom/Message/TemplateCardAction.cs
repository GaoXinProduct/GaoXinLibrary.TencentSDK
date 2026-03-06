using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>整体卡片点击跳转事件</summary>
public class TemplateCardAction
{
    /// <summary>跳转事件类型：1=跳转url, 2=打开小程序</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>跳转事件的 URL（type=1 时使用）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>跳转事件的小程序 appid（type=2 时使用）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>跳转事件的小程序页面路径（type=2 时使用）</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}

