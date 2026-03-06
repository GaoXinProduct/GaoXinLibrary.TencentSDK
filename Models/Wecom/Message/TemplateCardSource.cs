using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>卡片来源样式信息</summary>
public class TemplateCardSource
{
    /// <summary>来源图片的 URL</summary>
    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }

    /// <summary>来源图片的描述（建议不超过13个字）</summary>
    [JsonPropertyName("desc")] public string? Desc { get; set; }

    /// <summary>来源文字的颜色，0=默认（灰色）, 1=黑色, 2=红色, 3=绿色</summary>
    [JsonPropertyName("desc_color")] public int? DescColor { get; set; }
}

