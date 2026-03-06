using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>左图右文样式</summary>
public class TemplateCardImageTextArea
{
    /// <summary>左图右文样式区域点击事件类型：0=不可点击, 1=跳转url, 2=跳转小程序</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }

    /// <summary>点击跳转的 URL（type=1 时使用）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>点击跳转的小程序 appid（type=2 时使用）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>点击跳转的小程序页面路径（type=2 时使用）</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }

    /// <summary>左图右文样式的标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>左图右文样式的描述</summary>
    [JsonPropertyName("desc")] public string? Desc { get; set; }

    /// <summary>左图右文样式的图片 URL</summary>
    [JsonPropertyName("image_url")] public string? ImageUrl { get; set; }
}

