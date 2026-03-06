using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>模版卡片按钮</summary>
public class TemplateCardButton
{
    /// <summary>按钮文字</summary>
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;

    /// <summary>按钮类型：1=点击事件, 2=外链</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>跳转外链地址（type=2 时必须）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>跳转的 appid（跳小程序时使用）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>跳转的小程序页面路径</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}

