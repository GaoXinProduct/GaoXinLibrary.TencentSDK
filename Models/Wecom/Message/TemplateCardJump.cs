using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>跳转指引样式</summary>
public class TemplateCardJump
{
    /// <summary>跳转链接类型：0/1=跳转url, 2=跳转小程序</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }

    /// <summary>跳转链接标题（建议不超过18个字）</summary>
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;

    /// <summary>跳转链接的 URL（type=0/1 时使用）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>跳转链接的小程序 appid（type=2 时使用）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>跳转链接的小程序页面路径（type=2 时使用）</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }
}

